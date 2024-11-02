using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;

namespace RepositoryPattern.StorageՕptions
{
    public class OnAdoNetExpression
    {

        public static string connectionString;

        public static Dictionary<string, string> _Tables = new()
        {
            { "Student", "Students" },
            { "Employer", "Employers" },
            { "Customer", "Customers" }
        };


        internal static IEnumerable<T> Load<T>() where T : class, new()
        {
            Expression<Func<IDataRecord, T>> convertExp = CreateDataRecordConverterExpression<T>();
            Func<IDataRecord, T> convert = convertExp.Compile();

            foreach (var item in AsEnumerable($"Select * from {_Tables[typeof(T).Name]}"))
            {
                yield return convert(item);
            }
        }


        public static IEnumerable<IDataRecord> AsEnumerable(string query)
        {
            using var conn = new SqlConnection(connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var comand = conn.CreateCommand();
            comand.CommandType = CommandType.Text;
            comand.CommandText = query;
            var reader = comand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                    yield return reader;
            }
        }

        static Expression<Func<IDataRecord, TModel>> CreateDataRecordConverterExpression<TModel>() where TModel : class, new()
        {
            Type destType = typeof(TModel);

            Dictionary<string, PropertyInfo> members = destType
                .GetProperties()
                .ToDictionary(p => p.Name);

            var indexatorMethod = typeof(IDataRecord).GetProperties()
                .First(p => p.GetIndexParameters()
                    .Any(p1 => p1.ParameterType == typeof(string)))
                    .GetMethod;

            var par = Expression.Parameter(typeof(IDataRecord), "<r>");

            var memberAssignments = new List<MemberAssignment>(members.Count);
            Type stringType = typeof(string);
            foreach (var item in members)
            {
                var indexatorMemberExp = Expression.Call(par, indexatorMethod, Expression.Constant(item.Key, stringType));
                var memberCastExp = Expression.Convert(indexatorMemberExp, item.Value.PropertyType);
                MemberAssignment memberAssignmentExp = Expression.Bind(members[item.Key], memberCastExp);
                memberAssignments.Add(memberAssignmentExp);
            }

            NewExpression model = Expression.New(destType);
            MemberInitExpression body = Expression.MemberInit(model, memberAssignments);

            return Expression.Lambda<Func<IDataRecord, TModel>>(body, par);
        }


        internal static void Write<T>(List<T> source)
        {
             IEnumerable<Expression<Func<T,IDataParameter>>> convertExp = CreateSqlParameterConverterExpression<T>();

            IEnumerable<Func<T, IDataParameter>> convert = convertExp.Select(e => e.Compile());

            // Establishing a connection to the database
            using SqlConnection connection = new SqlConnection(connectionString);

            // Opening the connection
            connection.Open();

            var ColumnNames = typeof(T).GetProperties().Select(e => e.Name).ToList();

            // SQL query to insert data into a table
            string insertQuery = $"INSERT INTO {_Tables[typeof(T).Name]} ({string.Join(", ", ColumnNames)}) VALUES ({$"@{String.Join(", @", ColumnNames)}"})";
            insertQuery = $" IF NOT EXISTS (SELECT 1 FROM {_Tables[typeof(T).Name]} WHERE ID = @ID) BEGIN {insertQuery} END";

            // Creating a command object with the SQL query and connection
            using SqlCommand command = new SqlCommand(insertQuery, connection);
            foreach (var item in source)
            {
                command.Parameters.AddRange(convert.Select(e => e.Invoke(item)).ToArray());
                // Executing the command
                int rowsAffected = command.ExecuteNonQuery();
                // Outputting the number of rows affected
               // Console.WriteLine("Rows Inserted: " + rowsAffected);

                command.Parameters.Clear();
            }
        }


        static IEnumerable<Expression<Func<TModel, IDataParameter>>> CreateSqlParameterConverterExpression<TModel>()
        {

              Type destType = typeof(TModel);

            Dictionary<string, PropertyInfo> members = destType
                .GetProperties()
                .ToDictionary(p => p.Name);

            //var indexatorMethod = typeof(SqlParameter).GetProperties().ToDictionary(p => p.Name);
            //    .First(p => p.GetIndexParameters().Any(p1 => p1.ParameterType == typeof(string)))
            //        .GetMethod;


            //var memberAssignments = new List<MemberAssignment>(members.Count);
            foreach (var item in members)
            {
                Expression<Func<TModel, IDataParameter>> Exp = s => new SqlParameter
                {
                    ParameterName = $"{item.Key}",
                    SqlDbType = GetSqlDbType(item.Value.PropertyType),
                    Value = item.Value.GetValue(s),
                    //Size= item.Value.PropertyType is string ? -1 : 0
                };

                yield return Exp;
                //var par = Expression.Parameter(typeof(SqlParameter), "<r>");

                //MemberExpression ParameterName = Expression.Property(par, "ParameterName");
                //MemberAssignment ParameterNameBind = Expression.Bind(ParameterName.Member, Expression.Constant(item.Key));

                ////MemberExpression SqlDbType = Expression.Property(par, "SqlDbType");
                ////MemberAssignment SqlDbTypeBind = Expression.Bind(SqlDbType.Member, Expression.Constant(item.Value.PropertyType));

                //MemberExpression Value = Expression.Property(par, "Value");
                //MemberAssignment ValueBind = Expression.Bind(Value.Member, Expression.Constant(item.Value));


                //NewExpression model = Expression.New(typeof(SqlParameter));
                //MemberInitExpression body = Expression.MemberInit(model, ParameterNameBind, ValueBind);


                //var result = Expression.Lambda<Func<TModel, IDataParameter>>(body, par);

                //var indexatorMemberExp = Expression.Call(par, indexatorMethod, Expression.Constant(item.Key, stringType));
                //var memberCastExp = Expression.Convert(indexatorMemberExp, item.Value.PropertyType);
                //MemberAssignment memberAssignmentExp = Expression.Bind(members[item.Key], memberCastExp);
                //memberAssignments.Add(memberAssignmentExp);
            }
        }

        public static SqlDbType GetSqlDbType(Type type)
        {
            if (type == typeof(string))
                return SqlDbType.NVarChar; // Or SqlDbType.VarChar based on your needs
            if (type == typeof(int))
                return SqlDbType.Int;
            if (type == typeof(long))
                return SqlDbType.BigInt;
            if (type == typeof(short))
                return SqlDbType.SmallInt;
            if (type == typeof(decimal))
                return SqlDbType.Decimal;
            if (type == typeof(float))
                return SqlDbType.Float;
            if (type == typeof(double))
                return SqlDbType.Float; // or SqlDbType.Real based on your needs
            if (type == typeof(bool))
                return SqlDbType.Bit;
            if (type == typeof(DateTime))
                return SqlDbType.DateTime;
            if (type == typeof(byte[]))
                return SqlDbType.VarBinary;

            throw new ArgumentException("Unsupported type: " + type.Name);
        }
    }
}

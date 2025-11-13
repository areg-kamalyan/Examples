using Core.Entitys;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Expressions
    {
        public static void Run()
        {
            Func<Student, bool> isTennAger = s => s.Age >= 18;
            bool result = isTennAger.Invoke(new Student() { Age = 15 });

            //****************************************************************************************************
            Expression<Func<Student, bool>> isTennAgerExpr = s => s.Age >= 18;
            result = isTennAgerExpr.Compile().Invoke(new Student() { Age = 15 });
            //****************************************************************************************************
            ParameterExpression student = Expression.Parameter(typeof(Student), "s`");
            MemberExpression property = Expression.Property(student, nameof(Student.Age));
            ConstantExpression ConstantExp = Expression.Constant(18);

            BinaryExpression Body = Expression.GreaterThanOrEqual(property, ConstantExp);
            Expression<Func<Student, bool>> lambda = Expression.Lambda<Func<Student, bool>>(Body, student);

            result = lambda.Compile().Invoke(new Student() { Age = 15 });
            //****************************************************************************************************

            Expression<Func<Student, bool>> Expr1 = s1 => s1.Age >= 18;
            Expression<Func<Student, bool>> Expr2 = s2 => s2.Age <= 50;
            Body = Expression.AndAlso(Expr1.Body, Expr2.Body);


            var VisitBody = new ParameterReplacer(student).Visit(Body);

            lambda = Expression.Lambda<Func<Student, bool>>(VisitBody, student);


            result = lambda.Compile().Invoke(new Student() { Age = 15 });

        }


        public class ParameterReplacer : ExpressionVisitor
        {
            readonly Dictionary<string, ParameterExpression> _parameters;
            public ParameterReplacer(params ParameterExpression[] parameters)
            {
                _parameters = parameters.ToDictionary(p => p.Type.Name, p => p);
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (_parameters.TryGetValue(node.Type.Name, out ParameterExpression parameter))
                    return base.VisitParameter(parameter);

                return base.VisitParameter(node);
            }
        }
    }
}

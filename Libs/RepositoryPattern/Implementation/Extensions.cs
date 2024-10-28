using Core;
using RepositoryPattern.FileImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RepositoryPattern.Implementation
{
    public enum StoreType { Xml, Entity, AdoNetExpression }
    public static class Extensions 
    {
        public static IEnumerable<T> Load<T>(StoreType type, string filename = "") where T : class, new()
        {
            switch (type)
            {
                case StoreType.Xml:
                    return FileImplementation.Xml.LoadFromFile<T>(filename);
                case StoreType.Entity:
                    return DBImplementation.Entity.LoadFromDB<T>();
                case StoreType.AdoNetExpression:
                    return DBImplementation.AdoNetExpression.LoadFromDB<T>();
                default:
                    throw new Exception();
            }
        }

        public static void Write<T>(List<T> source, StoreType type, string filename = "")
        {
            switch (type)
            {
                case StoreType.Xml:
                    FileImplementation.Xml.WriteToFile(source, filename);
                    break;
                case StoreType.Entity:
                    DBImplementation.Entity.WriteToDB(source);
                    break;
                case StoreType.AdoNetExpression:
                    DBImplementation.AdoNetExpression.WriteToDB(source);
                    break;
            }
        }
    }
}

﻿using DesignPatterns.Repository.StorageՕptions;

namespace DesignPatterns.Repository.Implementation
{
    public enum StoreType { OnXml, OnEntityFramework, OnAdoNetExpression, OnDapper }
    public static class Extensions
    {
        static Extensions()
        {
            string connectionString = @"Server=(localdb)\ProjectModels;Database=UniversityDb;Trusted_Connection=True;Integrated Security=True";

            OnEntityFramework.connectionString = connectionString;
            OnAdoNetExpression.connectionString = connectionString;
            OnDapper.connectionString = connectionString;
        }

        public static IEnumerable<T> Load<T>(StoreType type, string filename = "") where T : class, new()
        {
            switch (type)
            {
                case StoreType.OnXml:
                    return OnXml.Load<T>(filename);
                case StoreType.OnEntityFramework:
                    return OnEntityFramework.Load<T>();
                case StoreType.OnAdoNetExpression:
                    return OnAdoNetExpression.Load<T>();
                case StoreType.OnDapper:
                    return OnDapper.Load<T>();
                default:
                    throw new Exception();
            }
        }

        public static void Write<T>(List<T> source, StoreType type, string filename = "")
        {
            switch (type)
            {
                case StoreType.OnXml:
                    OnXml.Write(source, filename);
                    break;
                case StoreType.OnEntityFramework:
                    OnEntityFramework.Write(source);
                    break;
                case StoreType.OnAdoNetExpression:
                    OnAdoNetExpression.Write(source);
                    break;
                case StoreType.OnDapper:
                    OnDapper.Write(source);
                    break;
            }
        }
    }
}

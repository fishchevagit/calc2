using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CalcDB
{
    public static class ReflectionHelper
    {
        private static string[] excludeColumns = new string[] { "Id", "TableName" };

        public static string GetTableName(this Type type)
        {
            return $"[dbo].[{type.Name}]";
        }

        public static string[] GetColumns(this Type type)
        {
            return type
                .GetProperties()
                .Select(m => m.Name)
                .Except(excludeColumns)
                .OrderBy(it => it)
                .ToArray();
        }

        public static string[] GetColumns(this IEntity obj)
        {
            return obj.GetType().GetColumns();
        }

        public static string GetSerialData(this IEntity obj)
        {
            var props = obj.GetType().GetProperties();

            var values = new Dictionary<string, string>();

            foreach (var prop in props.OrderBy(p => p.Name))
            {
                if (excludeColumns.Contains(prop.Name))
                {
                    continue;
                }

                var propValue = prop.GetValue(obj);
                var str = "";

                if (propValue == null)
                {
                    str = "NULL";
                }
                else if (propValue is string)
                {
                    str = $"N'{propValue}'";
                }
                else if (propValue is double)
                {
                    var doubleValue = (double)propValue;
                    str = $"{doubleValue.ToString(CultureInfo.InvariantCulture)}";
                }
                else if (propValue is DateTime)
                {
                    var doubleValue = (DateTime)propValue;
                    str = $"N'{doubleValue.ToString(CultureInfo.InvariantCulture)}'";
                }
                else
                {
                    str = $"{propValue}";
                }

                values.Add(prop.Name, str);
            }

            return obj.Id > 0
                ? string.Join(", ", values.Select(kv => $"[{kv.Key}] = {kv.Value}"))
                : string.Join(", ", values.Values);
        }

        public static T GetObject<T>(this SqlDataReader reader)
            where T : IEntity
        {
            var obj = Activator.CreateInstance<T>();

            var props = typeof(T).GetProperties();
            var dbNullType = typeof(DBNull);
            foreach (var prop in props)
            {
                var val = reader[prop.Name];
                if (val != null && val.GetType() != dbNullType)
                {
                    prop.SetValue(obj, val);
                }
            }

            return obj;
        }
    }
}

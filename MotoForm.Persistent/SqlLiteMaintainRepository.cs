
namespace MotoForm.Persistent
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Dapper;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;

    public class SqlLiteMaintainRepository : IMaintainRepository
    {
        private string filePath;

        private string connectionString;

        public SqlLiteMaintainRepository(string filePath)
        {
            this.filePath = $"{Environment.CurrentDirectory}\\{filePath}";
            this.connectionString = $"Data source={filePath}";
        }

        public Tuple<Exception> InstanceCheck()
        {
            try
            {
                if (!File.Exists(this.filePath))
                {
                    SQLiteConnection.CreateFile(this.filePath);
                }

                string sqlStr = string.Empty;
                var columns = new List<string>();
                foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
                {
                    var domainTypes = Assembly.Load(assemblyName).GetTypes()
                        .Where(p => p.IsClass && p.Namespace == "MotoForm.Domain.Model");

                    if (domainTypes.Any())
                    {
                        foreach (var type in domainTypes)
                        {
                            sqlStr += GenerateTableSqlString(type);
                            columns.AddRange(GenerateColumnSqlString(type));
                        }
                    }
                }

                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(sqlStr);
                    foreach(var column in columns)
                    {
                        try
                        {
                            cn.Execute(column);
                        }
                        catch
                        {
                        }
                    }
                }

                return Tuple.Create<Exception>(null);
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception>(ex);
            }
        }

        private string GenerateTableSqlString(Type T)
        {
            string result = string.Empty;
            var columns = new List<string>();
            var tableName = T.Name;
            result += $"CREATE TABLE IF NOT EXISTS {tableName}(";
            foreach (var prop in T.GetProperties())
            {
                var propName = prop.Name;
                if (object.ReferenceEquals(prop.PropertyType, typeof(int)))
                {
                    if (prop.Name == $"{tableName}Id")
                    {
                        columns.Add($"{prop.Name} INTEGER PRIMARY KEY AUTOINCREMENT");
                    }
                    else
                    {
                        columns.Add($"{prop.Name} INTEGER");
                    }
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(string)))
                {
                    columns.Add($"{prop.Name} TEXT");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(DateTime)))
                {
                    columns.Add($"{prop.Name} NUMERIC");
                }
                else if(object.ReferenceEquals(prop.PropertyType, typeof(bool)))
                {
                    columns.Add($"{prop.Name} INTEGER");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(long)))
                {
                    columns.Add($"{prop.Name} INTEGER");
                }
                else if(object.ReferenceEquals(prop.PropertyType, typeof(GenderType)) 
                    || object.ReferenceEquals(prop.PropertyType, typeof(MotoPowerSource)))
                {
                    columns.Add($"{prop.Name} INTEGER");
                }
            }

            result += string.Join(",", columns);
            result += ") ";
            return result;
        }

        private IEnumerable<string> GenerateColumnSqlString(Type T)
        {
            var result = new List<string>();
            var tableName = T.Name;
            foreach (var prop in T.GetProperties())
            {
                var propName = prop.Name;
                if (object.ReferenceEquals(prop.PropertyType, typeof(int)))
                {
                    if (prop.Name != $"{tableName}Id")
                    {
                        result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name} INTEGER");
                    }
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(string)))
                {
                    result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name} TEXT");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(DateTime)))
                {
                    result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name}  NUMERIC");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(bool)))
                {
                    result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name} INTEGER");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(long)))
                {
                    result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name} INTEGER");
                }
                else if (object.ReferenceEquals(prop.PropertyType, typeof(GenderType))
                    || object.ReferenceEquals(prop.PropertyType, typeof(MotoPowerSource)))
                {
                    result.Add($"ALTER TABLE {tableName} ADD COLUMN {prop.Name} INTEGER");
                }
            }

            return result;
        }
    }
}

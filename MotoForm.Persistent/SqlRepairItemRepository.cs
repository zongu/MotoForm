
namespace MotoForm.Persistent
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using Dapper;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;

    public class SqlRepairItemRepository : IRepairItemRepository
    {
        private string connectionString;

        public SqlRepairItemRepository(string filePath)
        {
            this.connectionString = $"Data source={filePath}";
        }

        public Tuple<Exception> Disable(int repairItemId)
        {
            try
            {
                string sqlStr = @"UPDATE RepairItem SET Enable = 0 WHERE RepairItemId = @RepairItemId";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            RepairItemId = repairItemId
                        });

                    return Tuple.Create<Exception>(null);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception>(ex);
            }
        }

        public Tuple<Exception, IEnumerable<RepairItem>> GetAll()
        {
            try
            {
                string sqlStr = @"SELECT * FROM RepairItem WHERE Enable = 1";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<RepairItem>(sqlStr);

                    return Tuple.Create<Exception, IEnumerable<RepairItem>>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, IEnumerable<RepairItem>>(ex, null);
            }
        }

        public Tuple<Exception> InsertOne(RepairItem item)
        {
            try
            {
                var columns = typeof(RepairItem).GetProperties()
                    .Where(p => p.Name != "RepairItemId" && p.Name != "CategoryDisplayName")
                    .Select(p => p.Name);
                var values = columns.Select(p => $"@{p}");
                string sqlStr = $"INSERT INTO RepairItem({string.Join(",", columns)}) " +
                                $"VALUES({string.Join(",", values)})";

                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            item.ItemName,
                            item.Category,
                            item.Price,
                            Enable = true
                        });

                    return Tuple.Create<Exception>(null);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception>(ex);
            }
        }

        public Tuple<Exception> UpdateOne(RepairItem item)
        {
            try
            {
                var columns = typeof(RepairItem).GetProperties()
                    .Where(p => p.Name != "RepairItemId" && p.Name != "CategoryDisplayName" && p.Name != "Enable")
                    .Select(p => $"{p.Name} = @{p.Name}");
                string sqlStr = $"UPDATE RepairItem SET {string.Join(",", columns)} WHERE RepairItemId = @RepairItemId";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            item.RepairItemId,
                            item.ItemName,
                            item.Category,
                            item.Price
                        });

                    return Tuple.Create<Exception>(null);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception>(ex);
            }
        }
    }
}

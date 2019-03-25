
namespace MotoForm.Persistent
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using Dapper;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;

    public class SqlRepairRecordRepository : IRepairRecordRepository
    {
        private string connectionString;

        public SqlRepairRecordRepository(string filePath)
        {
            this.connectionString = $"Data source={filePath}";
        }

        public Tuple<Exception, int> GetTodayRepairCount()
        {
            try
            {
                var startDateTimeStamp = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 00:00:00").Ticks;
                var endDateTimeStamp = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 23:59:59").Ticks;

                string sqlStr = @"SELECT COUNT(1) FROM RepairRecord WHERE CreateDateTimeStamp BETWEEN @StartDateTimeStamp AND @EndDateTimeStamp";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<int>(
                        sqlStr,
                        new
                        {
                            StartDateTimeStamp = startDateTimeStamp,
                            EndDateTimeStamp = endDateTimeStamp
                        });

                    return Tuple.Create<Exception, int>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, int>(ex, 0);
            }
        }

        public Tuple<Exception> Insert(RepairRecord record)
        {
            try
            {
                var columns = typeof(RepairRecord).GetProperties().Where(p=> p.Name != "RepairRecordId").Select(p => p.Name);
                var values = columns.Select(p => $"@{p}");
                string sqlStr = $"INSERT INTO RepairRecord({string.Join(",", columns)}) " +
                                $"VALUES({string.Join(",", values)})";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            record.MotoId,
                            record.Principal,
                            record.LastMaintainceMileage,
                            record.Memo,
                            record.ReceivableAmount,
                            record.ActualHarvestAmount,
                            record.CreateDateTimeStamp,
                            record.ContainString
                        });

                    return Tuple.Create<Exception>(null);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception>(ex);
            }
        }

        public Tuple<Exception, IEnumerable<RepairRecord>> QueryByDateTime(DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                string sqlStr = @"SELECT * FROM RepairRecord 
                                  WHERE CreateDateTimeStamp BETWEEN @StartDateTimeStamp AND @EndDateTimeStamp
                                  ORDER BY CreateDateTimeStamp DESC";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<RepairRecord>(
                        sqlStr,
                        new
                        {
                            StartDateTimeStamp = startDateTime.Ticks,
                            EndDateTimeStamp = endDateTime.Ticks
                        });

                    return Tuple.Create<Exception, IEnumerable<RepairRecord>>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, IEnumerable<RepairRecord>>(ex, null);
            }
        }

        public Tuple<Exception, IEnumerable<RepairRecord>> QueryByMotoId(int motoId)
        {
            try
            {
                string sqlStr = @"SELECT * FROM RepairRecord WHERE MotoId = @MotoId ORDER BY CreateDateTimeStamp DESC";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<RepairRecord>(
                        sqlStr,
                        new
                        {
                            MotoId = motoId
                        });

                    return Tuple.Create<Exception, IEnumerable<RepairRecord>>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, IEnumerable<RepairRecord>>(ex, null);
            }
        }

        public Tuple<Exception> Update(RepairRecord record)
        {
            try
            {
                string sqlStr = @"UPDATE RepairRecord SET ContainString = @ContainString WHERE RepairRecordId = @RepairRecordId";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            record.RepairRecordId,
                            record.ContainString
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

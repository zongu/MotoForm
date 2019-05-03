
namespace MotoForm.Persistent
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using Dapper;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;

    public class SqlMotoRepository : IMotoRepository
    {
        private string connectionString;

        public SqlMotoRepository(string filePath)
        {
            this.connectionString = $"Data source={filePath}";
        }

        public Tuple<Exception, bool> Disable(int motoId)
        {
            try
            {
                string sqlStr = @"UPDATE Moto SET Enable = 0 WHERE MotoId = @MotoId";

                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            MotoId = motoId
                        });

                    return Tuple.Create<Exception, bool>(null, true);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, bool>(ex, false);
            }
        }

        public Tuple<Exception, Moto> FindByMotoNumber(string motoNumber)
        {
            try
            {
                string sqlStr = @"SELECT * FROM Moto WHERE MotoNumber = @MotoNumber AND Enable = 1";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<Moto>(
                        sqlStr,
                        new
                        {
                            MotoNumber = motoNumber
                        });

                    return Tuple.Create<Exception, Moto>(null, result.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, Moto>(ex, null);
            }
        }

        public Tuple<Exception, IEnumerable<Moto>> FuzzyQueryByOwnerName(string ownerName)
        {
            try
            {
                string sqlStr = $"SELECT * FROM Moto WHERE OwnerName like '%{ownerName}%' AND Enable = 1";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<Moto>(
                        sqlStr);

                    return Tuple.Create<Exception, IEnumerable<Moto>>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, IEnumerable<Moto>>(ex, null);
            }
        }

        public Tuple<Exception, bool> InsertOne(Moto moto)
        {
            try
            {
                var columns = typeof(Moto).GetProperties().Select(p => p.Name).Where(p => p != "MotoId");
                var values = columns.Select(p => $"@{p}");
                string sqlStr = $"INSERT INTO Moto({string.Join(",", columns)}) " +
                                $"VALUES({string.Join(",", values)})";

                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            moto.OwnerName,
                            moto.TelPhone,
                            moto.MotoNumber,
                            moto.Tel,
                            moto.Address,
                            moto.Line,
                            moto.Label,
                            moto.EngineNumber,
                            moto.ExhaustVolume,
                            moto.PowerSource,
                            moto.Color,
                            moto.Type,
                            moto.Gender,
                            moto.Enable,
                            moto.CreateDateTimeStamp
                        });

                    return Tuple.Create<Exception, bool>(null, true);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, bool>(ex, false);
            }
        }

        public Tuple<Exception, IEnumerable<Moto>> QueryByTelPhone(string telPhone)
        {
            try
            {
                string sqlStr = @"SELECT * FROM Moto WHERE TelPhone = @TelPhone AND Enable = 1";

                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    var result = cn.Query<Moto>(
                        sqlStr,
                        new
                        {
                            TelPhone = telPhone
                        });

                    return Tuple.Create<Exception, IEnumerable<Moto>>(null, result);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, IEnumerable<Moto>>(ex, null);
            }
        }

        public Tuple<Exception, bool> UpdateOne(Moto moto)
        {
            try
            {
                var columns = typeof(Moto).GetProperties().Select(p => p.Name).Where(p => p != "MotoId" && p != "Enable" && p != "CreateDateTimeStamp").Select(p => $"{p} = @{p}");
                string sqlStr = $"UPDATE Moto SET {string.Join(",", columns)} WHERE MotoId = @MotoId";
                using (var cn = new SQLiteConnection(this.connectionString))
                {
                    cn.Execute(
                        sqlStr,
                        new
                        {
                            moto.MotoId,
                            moto.OwnerName,
                            moto.TelPhone,
                            moto.MotoNumber,
                            moto.Tel,
                            moto.Address,
                            moto.Line,
                            moto.Label,
                            moto.EngineNumber,
                            moto.ExhaustVolume,
                            moto.PowerSource,
                            moto.Color,
                            moto.Type,
                            moto.Gender,
                        });

                    return Tuple.Create<Exception, bool>(null, true);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create<Exception, bool>(ex, false);
            }
        }
    }
}

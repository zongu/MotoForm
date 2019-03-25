
namespace Domain.Persistent.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Persistent;

    [TestClass]
    public class SqlRepairRecordRepositoryTests
    {
        private IRepairRecordRepository repo;

        [TestInitialize]
        public void Init()
        {
            if (File.Exists($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}"))
            {
                File.Delete($"{Environment.CurrentDirectory}\\{Applibs.ConfigHelper.FilePath}");
            }
            var maintainceRepo = new SqlLiteMaintainRepository(Applibs.ConfigHelper.FilePath);
            var checkResult = maintainceRepo.InstanceCheck();
            Assert.IsNull(checkResult.Item1);

            this.repo = new SqlRepairRecordRepository(Applibs.ConfigHelper.FilePath);
        }

        [TestMethod]
        public void InsertTests()
        {
            var record = new RepairRecord()
            {
                MotoId = 1,
                Principal = "王大槌",
                LastMaintainceMileage = 30,
                Memo = "Memo -",
                ReceivableAmount = 1000,
                ActualHarvestAmount = 1000,
                CreateDateTimeStamp = DateTime.Now.Ticks
            };

            record.GenerateContainString(new List<RepairItemDetail>()
            {
                new RepairItemDetail()
                {
                    Category = RepairCategory.Battery,
                    ItemName = "ItemName -",
                    Price = 1000,
                    Qty = 1
                }
            });

            var insertResult = this.repo.Insert(record);
            Assert.IsNull(insertResult.Item1);
        }

        [TestMethod]
        public void QueryByDateTimeTests()
        {
            Enumerable.Range(1, 15).Select(index =>
                new RepairRecord()
                {
                    MotoId = index,
                    Principal = "王大槌",
                    LastMaintainceMileage = 30,
                    Memo = $"{index}Memo -",
                    ReceivableAmount = index * 1000,
                    ActualHarvestAmount = index * 1000,
                    CreateDateTimeStamp = index > 10 ? DateTime.Now.Ticks : DateTime.Now.AddDays(-1).Ticks
                }
            ).ToList().ForEach(record =>
            {
                record.GenerateContainString(new List<RepairItemDetail>()
                {
                    new RepairItemDetail()
                    {
                        Category = RepairCategory.Battery,
                        ItemName = "ItemName -",
                        Price = record.MotoId * 1000,
                        Qty = 1
                    }
                });

                var insertResult = this.repo.Insert(record);
                Assert.IsNull(insertResult.Item1);
            });

            var startDateTime = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 00:00:00");
            var endDateTime = DateTime.Parse($"{DateTime.Now.ToString("yyyy-MM-dd")} 23:59:59");

            var queryResult = this.repo.QueryByDateTime(startDateTime, endDateTime);
            Assert.IsNull(queryResult.Item1);
            Assert.IsNotNull(queryResult.Item2);
            Assert.AreEqual(queryResult.Item2.Count(), 5);
        }

        [TestMethod]
        public void QueryByMotoIdTest()
        {
            Enumerable.Range(1, 15).Select(index =>
               new RepairRecord()
               {
                   MotoId = index,
                   Principal = "王大槌",
                   LastMaintainceMileage = 30,
                   Memo = $"{index}Memo -",
                   ReceivableAmount = index * 1000,
                   ActualHarvestAmount = index * 1000,
                   CreateDateTimeStamp = index > 10 ? DateTime.Now.Ticks : DateTime.Now.AddDays(-1).Ticks
               }
           ).ToList().ForEach(record =>
           {
               record.GenerateContainString(new List<RepairItemDetail>()
               {
                    new RepairItemDetail()
                    {
                        Category = RepairCategory.Battery,
                        ItemName = "ItemName -",
                        Price = record.MotoId * 1000,
                        Qty = 1
                    }
               });

               var insertResult = this.repo.Insert(record);
               Assert.IsNull(insertResult.Item1);
           });

            var queryResult = this.repo.QueryByMotoId(1);
            Assert.IsNull(queryResult.Item1);
            Assert.IsNotNull(queryResult.Item2);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Enumerable.Range(1, 15).Select(index =>
               new RepairRecord()
               {
                   MotoId = index,
                   Principal = "王大槌",
                   LastMaintainceMileage = 30,
                   Memo = $"{index}Memo -",
                   ReceivableAmount = index * 1000,
                   ActualHarvestAmount = index * 1000,
                   CreateDateTimeStamp = index > 10 ? DateTime.Now.Ticks : DateTime.Now.AddDays(-1).Ticks
               }
           ).ToList().ForEach(record =>
           {
               record.GenerateContainString(new List<RepairItemDetail>()
               {
                    new RepairItemDetail()
                    {
                        Category = RepairCategory.Battery,
                        ItemName = "ItemName -",
                        Price = record.MotoId * 1000,
                        Qty = 1
                    }
               });

               var insertResult = this.repo.Insert(record);
               Assert.IsNull(insertResult.Item1);
           });

            var updateData = new RepairRecord()
            {
                RepairRecordId = 1,
                ContainString = string.Empty
            };

            var updateResult = this.repo.Update(updateData);
            Assert.IsNull(updateResult.Item1);
        }
    }
}

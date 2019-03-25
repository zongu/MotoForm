
namespace Domain.Persistent.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MotoForm.Domain.Model;
    using MotoForm.Domain.Repository;
    using MotoForm.Persistent;

    [TestClass]
    public class SqlMotoRepositoryTests
    {
        private IMotoRepository repo;

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

            this.repo = new SqlMotoRepository(Applibs.ConfigHelper.FilePath);
        }

        [TestMethod]
        public void InsertOneTest()
        {
            var insertOneResult = this.repo.InsertOne(new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = "MotoNumber -",
                OwnerName = "OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            });

            Assert.IsNull(insertOneResult.Item1);
            Assert.IsTrue(insertOneResult.Item2);
        }

        [TestMethod]
        public void FindByMotoNumberTests()
        {
            var insertOneResult = this.repo.InsertOne(new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = "MotoNumber -",
                OwnerName = "OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            });

            Assert.IsNull(insertOneResult.Item1);
            Assert.IsTrue(insertOneResult.Item2);

            var findResult = this.repo.FindByMotoNumber("MotoNumber -");
            Assert.IsNull(findResult.Item1);
            Assert.IsNotNull(findResult.Item2);
        }

        [TestMethod]
        public void QueryByTelPhoneTest()
        {
            var insertOneResult = this.repo.InsertOne(new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = "MotoNumber -",
                OwnerName = "OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            });

            Assert.IsNull(insertOneResult.Item1);
            Assert.IsTrue(insertOneResult.Item2);

            var findResult = this.repo.QueryByTelPhone("TelPhone -");
            Assert.IsNull(findResult.Item1);
            Assert.IsNotNull(findResult.Item2);
        }

        [TestMethod]
        public void FuzzyQueryByOwnerNameTest()
        {
            Enumerable.Range(1, 5).Select(p => new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = $"{p}MotoNumber -",
                OwnerName = $"{p}OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            }).ToList().ForEach(moto =>
            {
                var insertResult = this.repo.InsertOne(moto);
                Assert.IsNull(insertResult.Item1);
                Assert.IsTrue(insertResult.Item2);
            });

            var queryResult = this.repo.FuzzyQueryByOwnerName("OwnerName");
            Assert.IsNull(queryResult.Item1);
            Assert.IsNotNull(queryResult.Item2);
            Assert.AreEqual(queryResult.Item2.Count(), 5);
        }

        [TestMethod]
        public void DisableTest()
        {
            var insertOneResult = this.repo.InsertOne(new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = "MotoNumber -",
                OwnerName = "OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            });

            Assert.IsNull(insertOneResult.Item1);
            Assert.IsTrue(insertOneResult.Item2);

            var disableResult = this.repo.Disable(1);
            Assert.IsNull(disableResult.Item1);
            Assert.IsTrue(disableResult.Item2);
        }

        [TestMethod]
        public void UpdateOneTest()
        {
            var data = new Moto()
            {
                Address = "Address-",
                Color = "Color-",
                EngineNumber = "EngineNumber-",
                ExhaustVolume = 3000,
                Gender = GenderType.NotExist,
                Label = "Label -",
                Line = "Line -",
                MotoNumber = "MotoNumber -",
                OwnerName = "OwnerName -",
                PowerSource = MotoPowerSource.Electric,
                Tel = "Tel -",
                TelPhone = "TelPhone -",
                Type = "Type "
            };

            var insertOneResult = this.repo.InsertOne(data);
            Assert.IsNull(insertOneResult.Item1);
            Assert.IsTrue(insertOneResult.Item2);

            data.MotoId = 1;
            data.Address += "Update";
            data.Color += "Update";
            data.EngineNumber += "Update";
            data.Label += "Update";
            data.Line += "Update";
            data.MotoNumber += "Update";
            data.OwnerName += "Update";
            data.Tel += "Update";
            data.TelPhone += "Update";
            data.Type += "Update";

            var updateResult = this.repo.UpdateOne(data);
            Assert.IsNull(updateResult.Item1);
            Assert.IsTrue(updateResult.Item2);
        }
    }
}

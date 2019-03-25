
namespace MotoForm.Domain.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairRecord
    {
        public int RepairRecordId { get; set; }

        public int MotoId { get; set; }

        public string Principal { get; set; }

        public long LastMaintainceMileage { get; set; }

        public string Memo { get; set; }

        public int ReceivableAmount { get; set; }

        public int ActualHarvestAmount { get; set; }

        public long CreateDateTimeStamp { get; set; }

        public string ContainString { get; set; }

        public IEnumerable<RepairItemDetail> Contains()
            => JsonConvert.DeserializeObject<IEnumerable<RepairItemDetail>>(ContainString);

        public void GenerateContainString(IEnumerable<RepairItemDetail> details)
            => ContainString = JsonConvert.SerializeObject(details);
    }
}

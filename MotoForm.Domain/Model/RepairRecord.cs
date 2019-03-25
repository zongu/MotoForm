
namespace MotoForm.Domain.Model
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class RepairRecord
    {
        public int RepairRecordId { get; set; }

        public string Principal { get; set; }

        public long LastMaintainceMileage { get; set; }

        public string Memo { get; set; }

        public int Receivable { get; set; }

        public int ActualHarvest { get; set; }

        public long CreateDateTimeStamp { get; set; }

        public string ContainString { get; set; }

        public IEnumerable<RepairItemDetail> Contains()
            => JsonConvert.DeserializeObject<IEnumerable<RepairItemDetail>>(ContainString);
    }
}

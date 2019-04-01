
namespace MotoForm.Model
{
    using System;
    using MotoForm.Domain.Model;

    public class CustomRepairRecord: RepairRecord
    {
        public string DateTimeString { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}


namespace MotoForm.Model
{
    using System.Collections.Generic;
    using MotoForm.Domain.Model;
    using Newtonsoft.Json;

    public class CustomRepairRecord: RepairRecord
    {
        public string DateTimeString { get; set; }
    }
}

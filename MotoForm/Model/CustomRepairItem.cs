
namespace MotoForm.Model
{
    using MotoForm.Domain.Model;
    using Newtonsoft.Json;

    public class CustomRepairItem : RepairItem
    {
        public string CategoryDisplayName { get; set; }

        public int Qty { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}

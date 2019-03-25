
namespace MotoForm.Domain.Model
{
    using Newtonsoft.Json;

    public class RepairItemDetail
    {
        public string ItemName { get; set; }

        public RepairCategory Category { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}

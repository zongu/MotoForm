
namespace MotoForm.Domain.Model
{
    using System;

    public class Moto
    {
        public Moto()
        {
            Enable = true;
            CreateDateTimeStamp = DateTime.Now.Ticks;
        }

        public int MotoId { get; set; }

        public string OwnerName { get; set; }

        public string TelPhone { get; set; }

        public string MotoNumber { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string Line { get; set; }

        public string Label { get; set; }

        public string EngineNumber { get; set; }

        public int ExhaustVolume{ get; set; }

        public MotoPowerSource PowerSource { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public GenderType Gender { get; set; }

        public bool Enable { get; set; }

        public long CreateDateTimeStamp { get; set; }

        public DateTime CreateDateTime()
            => new DateTime(CreateDateTimeStamp);
    }
}

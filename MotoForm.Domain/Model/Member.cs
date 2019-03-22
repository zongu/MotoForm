
using System;

namespace MotoForm.Domain.Model
{
    public class Member
    {
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public string TelPhone { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}

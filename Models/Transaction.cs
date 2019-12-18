using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZXWebApps.Models
{
    public class Transaction
    {
        public int No { get; set; }
        public int NoTransDetail { get; set; }
        public int Tanggal { get; set; }
        public int KodeWarna { get; set; }
        public int StatusMesin { get; set; }
    }
}

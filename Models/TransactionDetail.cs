using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZXWebApps.Models
{
    public class TransactionDetail
    {
        [Key]
        public int NoTrans { get; set; }
        [Required]
        public string Periode { get; set; }
        public int NoOperator { get; set; }
    }
}

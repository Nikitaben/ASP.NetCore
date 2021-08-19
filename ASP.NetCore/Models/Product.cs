using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Models
{
    public class Product
    {
        [DisplayName("Code")]
        public string P_Code { get; set; }


        [DisplayName("Description")]
        public string P_descript { get; set; }


        [DisplayName("Date")]
        public DateTime P_InDate { get; set; }


        [DisplayName("Qoh")]
        public int P_QOH { get; set; }

        [DisplayName("Min")]
        public int P_Min { get; set; }

        [DisplayName("Price")]
        public double P_Price { get; set; }

        [DisplayName("Discount")]
        public double P_Discount { get; set; }

        [DisplayName("Vendor")]
        public int? V_code { get; set; }
        public Vendor Vendor { get; set; }
    }
}

using ASP.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Data.Interfaces
{
   public interface IVendorRepo
    {
        IEnumerable<Vendor> GetAllVendors();
        void CreateVendor(Vendor input);

    }
}

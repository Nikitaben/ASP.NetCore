using ASP.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Data.Interfaces
{
    public interface IitemRepo
    {
        IEnumerable<Item> GetAllitems();
        Item GetItemById(int id);
        void CreateItem(Item input);
        void UdateItem(Item input);
        void DeleteItem(int id);

        bool SaveChanges();

    }
}

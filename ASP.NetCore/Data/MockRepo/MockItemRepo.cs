using ASP.NetCore.Data.Interfaces;
using ASP.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Data.MockRepo
{
    public class MockItemRepo : IitemRepo
    {

        private readonly static List<Item> items = new List<Item>
        {
            new Item {Id = 101, Name = "Boiled water", Price = 15.55},
            new Item {Id = 102, Name = "Fresh stones", Price = 19.99},
            new Item {Id = 103, Name = "White paper", Price = 2.22},
        };
        public void CreateItem(Item input)
        {
            items.Add(input);
        }

        public void DeleteItem(int id)
        {
           var itemToDelete = items.FirstOrDefault(i => i.Id == id);
            if (itemToDelete != null)
                items.Remove(itemToDelete);
        }

        public IEnumerable<Item> GetAllitems()
        {
            return items;
        }

        public Item GetItemById(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UdateItem(Item input)
        {
            var itemInTheList = items.FirstOrDefault(i => i.Id == input.Id);

            if (itemInTheList != null)
            {
                //itemToUpDate = input; // The Bug!!!!!!!!!!!!!!!!
                /*
                items.Remove(itemInTheList);
                items.Add(input);
                items.Sort((a, b) => (a.Id).CompareTo(b.Id));
                */
                itemInTheList.Name = input.Name;
                itemInTheList.Price = input.Price;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CoffeeShopCrud.Repository;
using System.Data;

namespace CoffeeShopCrud.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool Add(string name, double price)
        {
            return _itemRepository.Add(name, price);
        }

        public bool IsNameExist(string name)
        {
            return _itemRepository.IsNameExist(name);
        }
    }
}

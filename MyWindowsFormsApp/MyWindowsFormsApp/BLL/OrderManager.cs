using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyWindowsFormsApp.Repository;

namespace MyWindowsFormsApp.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Add(string itemName,string price)
        {
            return _orderRepository.Add(itemName,price);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public bool Update(string name, string price, int id)
        {
            return _orderRepository.Update(name, price, id);
        }
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
        }
    }
}

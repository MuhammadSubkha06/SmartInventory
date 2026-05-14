using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory
{
    public static class koneksi
    {
        public static string conString = "Data Source=subha\\SQLEXPRESS;Initial Catalog=db_inventory;Integrated Security=True";
    }

    public static class GlobalSession
    {
        public static string username;
    }
}

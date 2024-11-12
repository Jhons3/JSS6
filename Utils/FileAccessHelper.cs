using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSS6.Utils
{
    public class FileAccessHelper
    {
        private string connectionString = "Server=localhost;Port=3306;Database=persona;User ID=root;Password=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
    


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace corridor_danil_shafiev.Model
{
    public class DBHelper
    {
        MySqlConnection conn = null;

        public DBHelper()
        {
            string connStr = "server=localhost;port=3306;user=root;password=root;database=coridor";
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
            }
            catch
            {
                LoadData();
            }
        }

        public List<Stone> LoadData()
        {
            try
            {
                List<Stone> myStones = new List<Stone>();

                using (var cmd = conn.CreateCommand())
                {
                    if (cmd == null) return null;
                    cmd.CommandText = "SELECT * FROM shariki";
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            myStones.Add(
                                new Stone()
                                {
                                    X = reader.GetInt32(0),
                                    Y = reader.GetInt32(1),
                                    Margin = reader.GetString(2)
                                });
                        }
                    }
                }

                return myStones;
            }
            catch
            {
                return null;
            }
        }
    }
}

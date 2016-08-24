using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SQLite;
using PetaPoco;

namespace ConsoleApplication1
{
    public class t
    {
        [Column]
        public int x { get; set; }
        public int y { get; set; }
        public string z { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source=test.db"))
            {
                conn.Open();
                var db = new Database(conn);
                db.Execute("CREATE TABLE IF NOT EXISTS t(x, y, z);");
                db.Insert("t", new t() { x = 1, y = 5, z = "abc" });
                foreach (var v in db.Query<t>("select * from t"))
                {
                    Console.WriteLine(v.y);
                }
            }
            Console.ReadLine();
        }

    }
}

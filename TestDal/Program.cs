using DAL;
using System;
//using System.Data.SqlClient;
//using System.WebConfigurationManager;

namespace TestDal
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Database db = new Database("NorthWind");
            db.Open();
            int count = db.ExecuteScalar<int>("select count(*) from[dbo].[Categories]");
            Console.WriteLine(count);
            db.Close();

        }
    }
}

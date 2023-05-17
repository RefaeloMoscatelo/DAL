using BL;
using Entities;
//using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDalll
{
    class Program
    {
        static void Main(string[] args)
        {
            string j = null;

           

            Console.WriteLine(j);
            // read
            //RegionManager rg = new RegionManager();
            // var q = rg.GetAll();
            //foreach (var item in q)
            //{
            //    Console.WriteLine("{0} {1} {2}", item.RegionID, item.RegionDescription, item.Version);
            //}

            //delete by id
            //RegionManager del1 = new RegionManager();
            //del1.Delete(10);

            //update by id
            //RegionManager upd1 = new RegionManager();
            //Region r = new Region();
            //r.RegionID = 8;
            //r.RegionDescription = "didia";
            //upd1.Update(r);


            CategoryManager cm = new CategoryManager();
            var q = cm.GetAll();
            foreach (var item in q)
            {
                Console.WriteLine("{0} {1} {2}", item.CategoryID, item.CategoryName, item.Version);
            }
            //Category cg = new Category();

            //Category c = new Category();
            //c.CategoryName = "dddd";
            //c.Description = "ass";
            //c.Version = null;
            //int num = cm.Add(c);
            //Console.WriteLine(num);


            //  Console.WriteLine(c.CategoryID);
            //add reference to DAL
            // Database db = new Database("NorthWind");
            // db.Open();

            #region executescalar
            //int num = db.ExecuteScalar<int>("select Count(*) from [Northwind].[dbo].[Categories];");
            //Console.WriteLine(num); 
            #endregion

            #region ExecuteReader
            //SqlDataReader reader = db.ExecuteReader(@"SELECT  [CategoryID]
            //                                          ,[CategoryName]
            //                                            FROM[Northwind].[dbo].[Categories]");
            //while (reader.Read())
            //{
            //    Console.WriteLine("{0} {1}",reader[0],reader[1]);
            //} 
            #endregion

            #region ExecuteNonQuery
            //int id = int.Parse(Console.ReadLine());
            //string region = Console.ReadLine();

            //int effected = db.ExecuteNonQuery(@"insert into [Northwind].[dbo].[Region]
            //                                ([RegionID],[RegionDescription]) 
            //                                  values(@id,@region);"
            //                                ,db.CreateParameter("@id", id.ToString())
            //                                ,db.CreateParameter("@region",region));
            //Console.WriteLine(effected); 
            #endregion
        }
    }
}

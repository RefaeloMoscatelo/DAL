using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductManager
    {
        private Database db;
        public ProductManager()
        {
            db = new Database("NorthWind");
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            db.Open();
            var reader = db.ExecuteReader("select * from [Northwind].[dbo].[Products]");
            while (reader.Read())
            {
                Product tmp = new Product();
                tmp.ProductID = (int)reader[0];
                if (!reader.IsDBNull(1))
                {
                    tmp.ProductName = (string)reader[1];
                }

                list.Add(tmp);
            }
            reader.Close();
            db.Close();
            return list;
        }

        public List<Product> GetByCategoryID(int categoryId)
        {
            List<Product> list = new List<Product>();
            db.Open();
            string query = "select [ProductID],[ProductName] from [Northwind].[dbo].[Products] where [CategoryID]=@CategoryID";
            var reader = db.ExecuteReader(query, db.CreateParameter("@CategoryID", categoryId.ToString()));
            while (reader.Read())
            {
                Product tmp = new Product();
                tmp.ProductID = (int)reader[0];
                if (!reader.IsDBNull(1))
                {
                    tmp.ProductName = (string)reader[1];
                }

                list.Add(tmp);
            }
            reader.Close();
            db.Close();
            return list;
        }




        public void Delete(int Itemid)
        {
            try
            {
                db.Open();
                string query = "Delete from [Northwind].[dbo].[Product] where ProductID=@id";
                var affected = db.ExecuteNonQuery(query, db.CreateParameter("@id", Itemid.ToString()));
                if (affected == 0)
                {
                    throw new Exception("No rows affected");
                }
            }
           finally
            {
                db.Close();
            }
            
        }
        public void Delete(Product item)
        {
            try
            {
                db.Open();
                string query = "Delete from [Northwind].[dbo].[Product] where ProductID=@id";
                var affected = db.ExecuteNonQuery(query, db.CreateParameter("@id", item.ProductID.ToString()));
                if (affected == 0)
                {
                    throw new Exception("No rows affected");
                }
            }
            finally
            {
                db.Close();
            }

        }
        public void Update(Product item)
        {
            try
            {
                db.Open();
                string query = "Update [Northwind].[dbo].[Product] set [ProductName]=@Description where ProductID=@id";
                var affected = db.ExecuteNonQuery(query, db.CreateParameter("@id", item.ProductID.ToString())
                                                        ,db.CreateParameter("@Description",item.ProductName));
                if (affected == 0)
                {
                    throw new Exception("No rows affected");
                }
            }
            finally
            {
                db.Close();
            }

        }

    }
}

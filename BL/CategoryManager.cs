using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    


    public class CategoryManager
    {
        private Database db;
        public CategoryManager()
        {
            db = new Database("NorthWind");
        }

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            SqlDataReader reader = null;
            try
            {
                db.Open();
                reader = db.ExecuteReader("select [CategoryID], [CategoryName],[Description],[Version] from [Northwind].[dbo].[Categories]");
                while (reader.Read())
                {
                    Category tmp = new Category();
                    tmp.CategoryID = (int)reader[0];
                    if (!reader.IsDBNull(1))
                        tmp.CategoryName = (string)reader[1];
                    if (!reader.IsDBNull(2))
                        tmp.Description = (string)reader[2];
                    tmp.Version = reader.GetNullable<int>(3);
                    list.Add(tmp);
                }
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }
                db.Close();
            }
           
            return list;
        }

        public void Delete(int Itemid)
        {
            try
            {
                db.Open();
                string query = "Delete from [Northwind].[dbo].[Categories] where [CategoryID]=@id";
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
        public void Delete(Category item)
        {
            try
            {
                db.Open();
                string query = "Delete from [Northwind].[dbo].[Categories] where RegionID=@id";
                var affected = db.ExecuteNonQuery(query, db.CreateParameter("@id", item.CategoryID.ToString()));
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
        public void Update(Category item)
        {
            try
            {
                db.Open();
                string query = "Update [Northwind].[dbo].[Categories] set [RegionDescription]=@Description where [CategoryID]=@id";
                var affected = db.ExecuteNonQuery(query, db.CreateParameter("@id", item.CategoryID.ToString())
                                                        , db.CreateParameter("@CategoryName", item.CategoryName)
                                                        , db.CreateParameter("@Description", item.Description)
                                                        , db.CreateParameter("@Version ", item.Version.ToString()));
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
        public int Add(Category item)
        {
           
            var query = @"insert into[Northwind].[dbo].[Categories]([CategoryName],[Description],[Version])
	                                                          values(@CategoryName, @Description, @Version);
                                                               SELECT @newID = @@IDENTITY;";
            SqlParameter newIdParameter = db.CreateParameter("@newID", 0);
            newIdParameter.Direction = System.Data.ParameterDirection.Output;
            try
            {
                db.Open();  
                var affected = db.ExecuteNonQuery(query /*db.CreateParameter("@id", item.CategoryID.ToString())*/
                                                        , db.CreateParameter("@CategoryName", item.CategoryName)
                                                        , db.CreateParameter("@Description", item.Description)
                                                            , db.CreateParameter("@Version ", item.Version.ToString())
                                                            , newIdParameter);
                if (affected == 0)                
                    throw new Exception("No rows affected");



               item.CategoryID = (int)newIdParameter.Value;

            }
            finally
            {
                db.Close();
            }
            return item.CategoryID;
       }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
      public static class Extensions
    {
        public static Nullable<T> GetNullable<T>(this SqlDataReader reader, int index) where T : struct
        {
            if (reader.IsDBNull(index))
                return null;

            return (T)reader[index];

        }
    }
}

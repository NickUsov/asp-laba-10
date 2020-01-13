using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4.Models
{
    public class GoodHandler
    {
        private SqlConnection conn;
        private void createConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["mssqlConnString"].ConnectionString;
        }
        public bool Create(Good good)
        {
            createConnection();
            string query = "insert into Goods(Title, Category, Price) values(@title, @category, @price)";
            int count = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query,conn);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@title";
                param1.SqlDbType = SqlDbType.NVarChar;
                param1.Value = good.Title;
                command.Parameters.Add(param1);
                SqlParameter param2 = command.Parameters.Add("@category", SqlDbType.NVarChar, 50, "Category");
                param2.Value = good.Category;
                SqlParameter param3 = command.Parameters.Add("@price", SqlDbType.Float);
                param3.Value = good.Price;
                count = command.ExecuteNonQuery();
            }
            finally
            {
                conn?.Close();
            }
            return count > 0;
        }
        public bool Update(Good good)
        {
            createConnection();
            string query = "update Goods set Title=@title, Category=@category, Price=@price where Id=@id";
            int count = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@title";
                param1.SqlDbType = SqlDbType.NVarChar;
                param1.Value = good.Title;
                command.Parameters.Add(param1);
                SqlParameter param2 = command.Parameters.Add("@category", SqlDbType.NVarChar, 50, "Category");
                param2.Value = good.Category;
                SqlParameter param3 = command.Parameters.Add("@price", SqlDbType.Float);
                param3.Value = good.Price;
                SqlParameter param4 = command.Parameters.Add("@id", SqlDbType.Int);
                param4.Value = good.Id;
                count = command.ExecuteNonQuery();
            }
            finally
            {
                conn?.Close();
            }
            return count > 0;
        }
        public bool Delete(int id)
        {
            createConnection();
            string query = "delete from Goods where Id=@id";
            int count = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlParameter param1 = command.Parameters.Add("@id", SqlDbType.Int);
                param1.Value = id;
                count = command.ExecuteNonQuery();
            }
            finally
            {
                conn?.Close();
            }
            return count > 0;
        }
        public List<Good> GetGoods()
        {
            createConnection();
            List<Good> goods = new List<Good>();
            string query = "select * from Goods";
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            finally
            {
                conn?.Close();
            }
            foreach(DataRow row in dt.Rows)
            {
                Good good = new Good();
                good.Id = Convert.ToInt32( row["id"]);
                good.Title = row["title"].ToString();
                good.Category = row["category"].ToString();
                good.Price = Convert.ToDouble(row["price"]);
                goods.Add(good);
            }
            return goods;
        }
    }
}
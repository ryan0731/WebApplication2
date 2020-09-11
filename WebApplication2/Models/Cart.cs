using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Net.Mime;

namespace WebApplication2.Models
{
    public class Data
    {
        public int id { get; set; }
        public string productname { get; set; }
        public string price { get; set; }
        public string productdescribe { get; set; }
        public string image { get; set; }
    }
    public class Cart
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;
        public string connstr = @"Data Source=LCC-PC\SQLEXPRESS;Initial Catalog=account;Persist Security Info=True;User ID=ryan; Password = 123456";
        public List<Data> DataList = new List<Data>();
        public Cart()
        {
            connection = new SqlConnection(connstr);
        }
        public void Select(int id)
        {
            connection.Open();
            command = new SqlCommand($"select * from [product] where [id] = '"+ id+"'", connection);
            //command = new SqlCommand(connStr, connection);

            reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    Data data = new Data
                    {
                        id = (int)reader["id"],
                        productname = reader["productname"].ToString(),
                        price = reader["price"].ToString(),
                        productdescribe = reader["productdescribe"].ToString(),
                        image = reader["image"].ToString(),


                    };
                    DataList.Add(data);

                }

                
            }
            connection.Close();

        }
           
    }


}

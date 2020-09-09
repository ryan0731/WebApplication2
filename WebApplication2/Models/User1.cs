using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mime;

namespace WebApplication2.Models
{
    public class User1
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;
        public string connstr = @"Data Source=LCC-PC\SQLEXPRESS;Initial Catalog=account;Persist Security Info=True;User ID=ryan; Password = 123456";
        public User1()
        {
            connection = new SqlConnection(connstr);
        }
        public string name { get; set; } = "ryan";
        public int age { get; set; } = 30;
        public bool loginCheck(string username, string passwd)
        {
            connection.Open();
            string commandStr = $"select * from dbo.customers where username='" +username+"'";

            command = new SqlCommand(commandStr,connection);
            
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if ( passwd== reader["passwd"].ToString())
                    {
                        //Session["loginState"] = "1";
                        //Session["user"] = user.Text;
                        //Server.Transfer("product.aspx");
                        connection.Close();
                        return true;
                    }
                    else
                    {

                        //state.Text = "密碼不正確";
                        
                        connection.Close();
                        return false;
                        
                    }
                }
            }

            else
            {
                //state.Text = "無此帳戶";
                connection.Close();
                return false;
            }
            connection.Close();
            return false;
        }
        public bool regCheck(string username, string passwd, string name, string email)
        {
            connection.Open();
            string commandStr = $"insert into dbo.customers(username,passwd,name,email) values ('{username}', '{passwd}', '{name}','{email}')";
            command = new SqlCommand(commandStr, connection);
            try
            {
                command.ExecuteNonQuery().ToString();
                connection.Close();
                return true;
            }
            catch (Exception )
            {
                connection.Close();
                return false;
            }

        }
    }
}

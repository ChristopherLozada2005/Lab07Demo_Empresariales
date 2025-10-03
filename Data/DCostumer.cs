using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCostumer
    {
        public void Create(Costumer costumer)
        {
            using (SqlConnection conn = new SqlConnection(Constant._connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_insert_customer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", costumer.Name);
                cmd.Parameters.AddWithValue("@address", costumer.Address);
                cmd.Parameters.AddWithValue("@phone", costumer.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Costumer> Read()
        {
            var customers = new List<Costumer>();

            using (SqlConnection conn = new SqlConnection(Constant._connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_list_customers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var costumer = new Costumer
                        {
                            CustomerID = reader.GetInt32(reader.GetOrdinal("customer_id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Address = reader.GetString(reader.GetOrdinal("address")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            Active = reader.GetBoolean(reader.GetOrdinal("active"))
                        };
                        customers.Add(costumer);
                    }
                }
            }

            return customers;
        }

        public void Update(Costumer costumer)
        {
            using (SqlConnection conn = new SqlConnection(Constant._connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_update_customer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", costumer.CustomerID);
                cmd.Parameters.AddWithValue("@name", costumer.Name);
                cmd.Parameters.AddWithValue("@address", costumer.Address);
                cmd.Parameters.AddWithValue("@phone", costumer.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Costumer costumer)
        {
            using (SqlConnection conn = new SqlConnection(Constant._connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_delete_customer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", costumer.CustomerID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
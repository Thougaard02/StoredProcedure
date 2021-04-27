using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure
{
    class DalManager
    {
        private static string cs = @"Server=ZBC-E-RO-23239\MSSQLSERVER01;Database=ERD_TestDB;Trusted_Connection=True;";


        public void SelectAllCustomers()
        {
            //Stored procedure name
            string spName = @"[dbo].[SP_GetAllCustomers]";

            
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(spName, conn);

                //Sets cmd.CommandType to storedProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Prints firstname and lastname from stored procedure
                    Console.WriteLine($"{rdr["FirstName"]} {rdr["LastName"]}");
                }
            }
        }

        /// <summary>
        /// Search customers in the database by a stored procedure
        /// </summary>
        /// <param name="customerF">Customer firstname</param>
        /// <param name="customerL">Customer Lastname</param>
        public void SearchCustomersName(string customerF, string customerL)
        {
            //Stored procedure name
            string spName = @"[dbo].[SP_GetCostumersName]";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                //Opens connection to datebase
                conn.Open();
                //takes stored procedure and connection as parameters
                SqlCommand cmd = new SqlCommand(spName, conn);

                //Sets cmd.CommandType to storedProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add the new instance sqlparametet
                cmd.Parameters.Add(new SqlParameter(@"FirstName", customerF));
                cmd.Parameters.Add(new SqlParameter(@"LastName", customerL));

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Prints the customer first- and lastname
                    Console.WriteLine($"{rdr["FirstName"]} {rdr["LastName"]}");
                }
            }
        }
        /// <summary>
        /// Search customer first-, last-, and product-name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="product"></param>
        public void SearchCustomersProduct(string firstName, string lastName, string product)
        {
            //Stored procedure name
            string spName = @"[dbo].[SP_GetCustomersProduct]";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //Opens connection to datebase
                conn.Open();
                //takes stored procedure and connection as parameters
                SqlCommand cmd = new SqlCommand(spName, conn);

                //Sets cmd.CommandType to storedProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add the new instance sqlparametet
                cmd.Parameters.Add(new SqlParameter(@"FirstName", firstName));
                cmd.Parameters.Add(new SqlParameter(@"LastName", lastName));
                cmd.Parameters.Add(new SqlParameter(@"ProductName", product));

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Prints the customer first-, last-, and product-name
                    Console.WriteLine($"{rdr["FirstName"]} {rdr["LastName"]} {rdr["ProductName"]}");
                }
            }
        }
    }
}

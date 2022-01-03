using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_Sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listEmloyee = new List<Employee>();
            string conctionString = "Data Source=LAPTOP-A88V89UT;Initial Catalog=Office;Integrated Security=True;Pooling=False";
            ShowAllEmployees(conctionString);
            AddEmployeeToTable(conctionString);
            DeleteEmployeeFromTable(1, conctionString);
        }

        private static void ShowAllEmployees(string conctionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conctionString))
                {
                    connection.Open();
                    string query = @"SELECT * From Employee";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataFromDataBase = command.ExecuteReader();

                    if (dataFromDataBase.HasRows)
                    {

                        while (dataFromDataBase.Read())
                        {
                            Console.WriteLine(

                                dataFromDataBase.GetString(1) +
                                dataFromDataBase.GetString(2) +
                                dataFromDataBase.GetString(3) +
                                dataFromDataBase.GetInt32(4)
                                );
                        }
                    }
                    else
                    {
                        Console.WriteLine("no rows in table");
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception)
            {
                Console.WriteLine("no row ");
            }




        }
        private static void AddEmployeeToTable(string connectionString)
        {
            string Name = Console.ReadLine();
            string brithDay = Console.ReadLine();
            string email = Console.ReadLine();
            int payment = int.Parse(Console.ReadLine());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO Employee(Name,brithDay,email,payment)
                                   VALUES('{Name}','{brithDay}','{email}',{payment})";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

        private static void DeleteEmployeeFromTable( int id ,string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE FROM Employee WHERE ID = { id}";
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }


        }

    }
}


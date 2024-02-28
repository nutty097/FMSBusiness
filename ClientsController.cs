using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text.Json;

using static System.Runtime.InteropServices.JavaScript.JSType;

using FMSConsult.Models.UserDetail;
namespace FMSConsult.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult UserDetail()
        {
            return View();
        }
        public IActionResult AddItem()
        {
            return View();
        }
        public IActionResult ItemDetail()
        {
            return View();
        }

        [HttpPost]
        public string InsertUser()
        {
            string Username = Request.Form["Username"];
            string address = Request.Form["address"];
            string PhoneNumber = Request.Form["PhoneNumber"];
            string FaxNumber = Request.Form["FaxNumber"];

             string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 using (SqlCommand cmd = new SqlCommand("INSERT INTO UserDetail(UserName,Address,PhoneNumber,FaxNumber) VALUES(@Username,@address,@PhoneNumber,@FaxNumber)", connection))
                 {
                     cmd.Parameters.AddWithValue("@Username", Username);
                     cmd.Parameters.AddWithValue("@address", address);
                     cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                     cmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);


                     connection.Open();

                     cmd.ExecuteNonQuery();

                     if (connection.State == System.Data.ConnectionState.Open)
                         connection.Close();
                 }
             }
            return "Insert SuccessFully";
        }

        [HttpPost]
        public string UpdateUser()
        {
            
            string UserID = Request.Form["UpdateUserID"];
            string Username = Request.Form["UpdateUsername"];
            string address = Request.Form["Updateaddress"];
            string PhoneNumber = Request.Form["UpdatePhoneNumber"];
            string FaxNumber = Request.Form["UpdateFaxNumber"];


            string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE UserDetail SET UserName = @Username, Address = @address, PhoneNumber = @PhoneNumber, FaxNumber = @FaxNumber WHERE UserID = @UserID", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@FaxNumber", FaxNumber);
                    cmd.Parameters.AddWithValue("@UserID", UserID);


                    connection.Open();

                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return "Update SuccessFully";

        }

        [HttpPost]
        public string DeleteUser()
        {

            string UserID = Request.Form["DeleteUserID"];
            


            string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM UserDetail WHERE UserID = @UserID", connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    


                    connection.Open();

                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return "Delete SuccessFully";

        }

        public string DataTableAsJsonUserDetail()
        {
            {
                string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";
                string query = "SELECT * FROM UserDetail";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            DataTable dataTable = new DataTable();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            dataAdapter.Fill(dataTable);

                            // Convert DataTable to list of dictionaries
                            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                Dictionary<string, object> rowData = new Dictionary<string, object>();
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    rowData.Add(column.ColumnName, row[column]);
                                }
                                rows.Add(rowData);
                            }

                            // Serialize list of dictionaries to JSON
                            string jsonData = JsonSerializer.Serialize(rows);

                            return jsonData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    return $"Error: {ex.Message}";
                }
            }
        }

        [HttpPost]
        public string InsertItem()
        {

            string Itemname = Request.Form["AddItemname"];
            string Price = Request.Form["AddPrice"];
            string Total = Request.Form["AddTotal"];
            


            string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ItemDetail(ItemName,Price,Total)VALUES(@Itemname,@Price,@Total)", connection))
                {
                    cmd.Parameters.AddWithValue("@Itemname", Itemname);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    
                    connection.Open();

                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return "Insert SuccessFully";

        }

        [HttpPost]
        public string UpdateItem()
        {
            string ItemID = Request.Form["UpdateItemID"];
            string ItemName = Request.Form["UpdateItemName"];
            string Price = Request.Form["UpdatePrice"];
            string Total = Request.Form["UpdateTotal"];



            string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE ItemDetail SET ItemName = @Itemname ,Price = @Price, Total = @Total WHERE ItemID = @ItemID", connection))
                {
                    cmd.Parameters.AddWithValue("@Itemname", ItemName);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Total", Total);
                    cmd.Parameters.AddWithValue("@ItemID", ItemID);


                    connection.Open();

                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return "Update SuccessFully";

        }

        [HttpPost]
        public string DeleteItem()
        {
            string ItemID = Request.Form["DeleteItemID"];
            
            string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ItemDetail WHERE ItemID = @ItemID", connection))
                {
                    
                    cmd.Parameters.AddWithValue("@ItemID", ItemID);


                    connection.Open();

                    cmd.ExecuteNonQuery();

                    if (connection.State == System.Data.ConnectionState.Open)
                        connection.Close();
                }
            }
            return "Delete SuccessFully";

        }

        public string DataTableAsJsonItemDetail()
        {
            {
                string connectionString = "Data Source=NUTKININOTO\\SQLEXPRESS;Initial Catalog=FMSBusiness;Integrated Security=True;";
                string query = "SELECT * FROM ItemDetail";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            DataTable dataTable = new DataTable();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            dataAdapter.Fill(dataTable);

                            // Convert DataTable to list of dictionaries
                            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                Dictionary<string, object> rowData = new Dictionary<string, object>();
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    rowData.Add(column.ColumnName, row[column]);
                                }
                                rows.Add(rowData);
                            }

                            // Serialize list of dictionaries to JSON
                            string jsonData = JsonSerializer.Serialize(rows);

                            return jsonData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    return $"Error: {ex.Message}";
                }
            }
        }


    }
}

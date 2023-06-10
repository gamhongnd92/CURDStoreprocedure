using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CURDStoreprocedure.Models;

namespace CURDStoreprocedure.Data_Access_Layer
{
    public class db
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        
        public void AddRecord(Employee emp)
        {
            SqlCommand command = new SqlCommand("Sp_Add_Employee", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", emp.Name);
            command.Parameters.AddWithValue("@Address", emp.Address );
            command.Parameters.AddWithValue("@City",emp.City);
            command.Parameters.AddWithValue("@Pin_Code",emp.Pin_Code);
            command.Parameters.AddWithValue("@Designation",emp.Designation);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateRecord(Employee emp)
        {
            SqlCommand command = new SqlCommand("Sp_Update_Employee", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Emp_id", emp.Emp_Id);
            command.Parameters.AddWithValue("@Name", emp.Name);
            command.Parameters.AddWithValue("@Address", emp.Address);
            command.Parameters.AddWithValue("@City", emp.City);
            command.Parameters.AddWithValue("@Pin_Code", emp.Pin_Code);
            command.Parameters.AddWithValue("@Designation", emp.Designation);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet ShowData()
        {
            SqlCommand command = new SqlCommand("Sp_Employee_All", connection);
            command.CommandType= CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);  
            return dataSet;

        }

        public DataSet ShowRecordById(int id)
        {
            SqlCommand command = new SqlCommand("Sp_Employee_id", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Emp_id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Employee");
            return dataSet;
        }

        public void DeleteRecord(int id)
        {
            SqlCommand command = new SqlCommand("Sp_Delete_Employee", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Emp_id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
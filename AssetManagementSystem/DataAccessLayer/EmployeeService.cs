using AssetManagementSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.DataAccessLayer
{
    public class EmployeeService
    {
        int result;
        MySqlConnection conn;
        string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=cmdb;port=3306";

        public bool CheckIfUserAlreadyExist(string empId)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM employee WHERE empId = @empId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@empId", empId);


            Employee objemployee = new Employee();
            MySqlDataReader mySqlDataReader = command.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                objemployee.empId = mySqlDataReader[1].ToString();
            }



            connection.Close();

            if (empId == objemployee.empId)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int AddEmployee(Employee employee)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO employee(empId,empName,cubicalNo,contactNo,emailId,isDeleted)VALUES(@empId,@empName,@cubicalNo,@contactNo,@emailId,@isDeleted)";
                //cmd.Parameters.AddWithValue("@srNo", employee.srNo);
                cmd.Parameters.AddWithValue("@empId", employee.empId);
                cmd.Parameters.AddWithValue("@empName", employee.empName);
                cmd.Parameters.AddWithValue("@cubicalNo", employee.cubicalNo);
                cmd.Parameters.AddWithValue("@contactNo", employee.contactNo);
                cmd.Parameters.AddWithValue("@emailId", employee.emailId);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return result;

        }

        public List<Employee> GetAllEmployee()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string connectionString;
            List<Employee> list = new List<Employee>();
            connectionString = "server=127.0.0.1;uid=root;pwd=root;database=cmdb;port=3306";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from employee where isDeleted = 0 ";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.srNo = Convert.ToInt32(reader[0]);
                    emp.empId = Convert.ToString(reader[1]);
                    emp.empName = Convert.ToString(reader[2]);
                    emp.cubicalNo = Convert.ToInt32(reader[3]);
                    emp.contactNo = Convert.ToString(reader[4]);
                    emp.emailId = Convert.ToString(reader[5]);
                    list.Add(emp);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
            }

            return list;
        }
        public int EditEmployee(Employee employee)
        {

            int res = 0;
            string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=cmdb;port=3306";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update employee set empId=@empId,empName=@empName,cubicalNo=@cubicalNo,contactNo=@contactNo,emailId=@emailId where srNo=@srNo";
                cmd.Parameters.AddWithValue("@srNo", employee.srNo);
                cmd.Parameters.AddWithValue("@empId", employee.empId);
                cmd.Parameters.AddWithValue("@empName", employee.empName);
                cmd.Parameters.AddWithValue("@cubicalNo", employee.cubicalNo);
                cmd.Parameters.AddWithValue("@contactNo", employee.contactNo);
                cmd.Parameters.AddWithValue("@emailId", employee.emailId);
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
            }

            return result;
        }
        public Employee GetEmployeeBySrNo(int srNo)
        {
            string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=cmdb;port=3306";
            Employee emp = new Employee();
            try
            {

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from employee where srNo = @srNo";
                cmd.Parameters.AddWithValue("@srNo", srNo);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    emp.srNo = Convert.ToInt32(reader[0]);
                    emp.empId = Convert.ToString(reader[1]);
                    emp.empName = Convert.ToString(reader[2]);
                    emp.cubicalNo = Convert.ToInt32(reader[3]);
                    emp.contactNo = Convert.ToString(reader[4]);
                    emp.emailId = Convert.ToString(reader[5]);
                    conn.Close();
                }


            }
            catch (Exception ex)
            {
            }
            return emp;

        }

        public int DeleteEmployeeBySrNo(int srNo)
        {
            string ConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=cmdb;port=3306";

            Employee employee  = new Employee();
          
            int result = 0;
            try
            {
               
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update employee set IsDeleted = 1 where srNo = @srNo;";
              
                cmd.Parameters.AddWithValue("@srNo", srNo);
                //cmd.Parameters.AddWithValue("@", string.Empty);

                result = cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Rail
{
    interface IPerson
    {
        void Data();
        void Quantity();
        void Privilege()
        {
            MessageBox.Show("Только клиент имеет привелегию");
        }
        void AddUser();
        void DeleteUser();
    }
    class ConnectionDB
    {
        public static MySqlConnection ConnDB()
        {
            string host = "10.90.12.113";
            string port = "333333";
            string database = "is_3_19_st10_KURS";
            string username = "st_3_19_10";
            string password = "22926640";

            string connString = $"server={host};port={port};user={username};database={database};password={password}";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
    class Persons : IPerson
    {
        public void Data()
        {
            MessageBox.Show("У сотрудников и клиентов есть общие данные");
        }
        public void Quantity()
        {
            MessageBox.Show("Общее количество людей");
        }
        public void AddUser()
        {
            MessageBox.Show("Добавить пользователя");
        }
        public void DeleteUser()
        {
            MessageBox.Show("Удалить пользователя");
        }
        static public void SelectUsers(ListBox lv, MySqlConnection conn) { }
    }

    class Employees : Persons, IPerson
    {
        public bool InsertEmployees(string fio_employee, string position_employee, MySqlConnection conn)
        {
            int InsertCount = 0;
            bool result = false;
            conn.Open();
            string query = $"INSERT INTO employees (fio_employee, position_employee) VALUES ('{fio_employee}', '{position_employee}')";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                InsertCount = command.ExecuteNonQuery();
            }
            catch
            {
                InsertCount = 0;
            }
            finally
            {
                conn.Close();
                if (InsertCount != 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public void UpdateEmployees(string id, string fio, string position, MySqlConnection conn)
        {
            string id_employee = id;
            string new_fio = fio;
            string new_position = position;
            if (String.IsNullOrWhiteSpace(id) || String.IsNullOrWhiteSpace(fio) || String.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string query2 = $"UPDATE employees SET fio_employee = '{new_fio}', position_employee = '{new_position}' WHERE id_employee = {id_employee}";
                    MySqlCommand command = new MySqlCommand(query2, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменение прошло успешно.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        static public new void SelectUsers(ListBox lv, MySqlConnection conn)
        {
            lv.Items.Clear();
            conn.Open();
            string sql = $"SELECT * FROM employees";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id_employee = reader[0].ToString();
                string fio_employee = reader[1].ToString();
                string position_employee = reader[2].ToString();
                lv.Items.Add($"{id_employee}) {fio_employee} - {position_employee}");
            }
            reader.Close();
            conn.Close();
        }
    }
    class Clients : Persons, IPerson
    {
        public bool InsertClients(string fio_client, string pass_client, string privilege_client, MySqlConnection conn)
        {
            int InsertCount = 0;
            bool result = false;
            conn.Open();
            string query = $"INSERT INTO clients (fio_client, pass_client, id_privilege) VALUES ('{fio_client}', '{pass_client}', '{privilege_client}')";
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                InsertCount = command.ExecuteNonQuery();
            }
            catch
            {
                InsertCount = 0;
            }
            finally
            {
                conn.Close();
                if (InsertCount != 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public void UpdateClients(string id, string fio, string pass, string privilege, MySqlConnection conn)
        {
            string id_client = id;
            string new_fio = fio;
            string new_pass = pass;
            string new_privilege = privilege;
            if (String.IsNullOrWhiteSpace(id) || String.IsNullOrWhiteSpace(fio) || String.IsNullOrWhiteSpace(pass) || String.IsNullOrWhiteSpace(privilege))
            {
                MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string query2 = $"UPDATE clients SET fio_client = '{new_fio}', pass_client = '{new_pass}', id_privilege = '{new_privilege}' WHERE id_client = {id_client}";
                    MySqlCommand command = new MySqlCommand(query2, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменение прошло успешно.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Введите данные!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        static public new void SelectUsers(ListBox lv, MySqlConnection conn)
        {
            lv.Items.Clear();
            conn.Open();
            string sql = $"SELECT * FROM clients";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id_client = reader[0].ToString();
                string fio_client = reader[1].ToString();
                string pass_client = reader[2].ToString();
                string privilege_client = reader[3].ToString();
                lv.Items.Add($"{id_client}) {fio_client} - {pass_client} - {privilege_client}");
            }
            reader.Close();
            conn.Close();
        }
    }
}
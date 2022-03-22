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
    public partial class Menu : Form
    {
        // Класс ConnectDB

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

        // Интерфейс и класс Person с наследниками

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

        class Person : IPerson
        {
            public void Data ()
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
        }

        class Employee : Person, IPerson
        {
            public new void Data()
            {
                MessageBox.Show("У сотрудников есть свои собственные данные");
            }
            public new void Quantity()
            {
                MessageBox.Show("Количество сотрудников");
            }
            public new void AddUser()
            {
                MessageBox.Show("Добавить сотрудника");
            }
            public new void DeleteUser()
            {
                MessageBox.Show("Уволить сотрудника");
            }
        }

        class Clients : Person, IPerson
        {
            public new void Data()
            {
                MessageBox.Show("У клиентов есть свои собственные данные");
            }
            public new void Quantity()
            {
                MessageBox.Show("Количество клиентов");
            }
            public void Privilege() { }
            public new void AddUser()
            {
                MessageBox.Show("Добавить клиента");
            }
            public new void DeleteUser()
            {
                MessageBox.Show("Удалить клиента");
            }
        }
        public Menu()
        {
            InitializeComponent();
        }

    }
}
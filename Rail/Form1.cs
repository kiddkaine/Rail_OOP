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
    public partial class Form1 : Form
    {
        // Интерфейсы

        interface IData
        {
            void Data();
            void Quantity();
            void Privilege()
            {
                MessageBox.Show("Только клиент имеет привелегию");
            }
        }

        interface IAccounting
        {
            void Income();
            void Expenses();
            void NumberSales();
            void NumberPurchases();
        }
        
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

        // Класс Person и его наследники

        class Person : IData
        {
            public void Data ()
            {
                MessageBox.Show("У сотрудников и клиентов есть общие данные");
            }
            public void Quantity()
            {
                MessageBox.Show("Общее количество людей");
            }
        }

        class Employee : Person, IData
        {
            public new void Data()
            {
                MessageBox.Show("У сотрудников есть свои собственные данные");
            }
            public new void Quantity()
            {
                MessageBox.Show("Количество сотрудников");
            }
        }

        class Clients : Person, IData
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
        }
        public Form1()
        {
            InitializeComponent();
        }

    }
}
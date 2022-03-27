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
        MySqlConnection connDB = ConnectionDB.ConnDB();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            connDB.Open();

            string fioEmp = textBox1.Text;
            string posEmp = textBox2.Text;

            Employees emp = new Employees();
            emp.InsertEmployees(fioEmp, posEmp, connDB);

            connDB.Close();
        }
    }
}
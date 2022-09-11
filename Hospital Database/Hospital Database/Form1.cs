using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Database
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Andrei\\source\\repos\\Hospital Database\\Hospital Database\\Hospital Database.mdf\";Integrated Security=True;Connect Timeout=30");
        }

        private void mediciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mediciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_DatabaseDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.hospital_DatabaseDataSet.Radiografii);
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.hospital_DatabaseDataSet.Pacienti);
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Medici' table. You can move, or remove it, as needed.
            this.mediciTableAdapter.Fill(this.hospital_DatabaseDataSet.Medici);

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.ToString();
            string pass=textBox2.Text;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Medici WHERE Id='"+id+"' AND Password='"+pass+"'";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                this.DialogResult=DialogResult.OK; ;
                this.Hide();
                new MainInterface().Show(); //open next form after login
            }
            else
            {
                MessageBox.Show("Logare invalida verificati utilizatorul si parola");
            }
            con.Close();
        }
    }
}

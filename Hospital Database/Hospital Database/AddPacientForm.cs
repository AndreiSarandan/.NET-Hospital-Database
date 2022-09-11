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
    public partial class AddPacientForm : Form
    {
        public AddPacientForm()
        {
            InitializeComponent();
        }

        private void addPacientButton_Click(object sender, EventArgs e)
        {
            string cnp = textBox1.Text;
            string save = "INSERT INTO Pacienti(CNP, Nume, Adresa)"+
                "VALUES (@CNP,@Nume,@Adresa)";
            SqlCommand cmd = new SqlCommand(save);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Andrei\\source\\repos\\Hospital Database\\Hospital Database\\Hospital Database.mdf\";Integrated Security=True;Connect Timeout=30");
            cmd.Connection=con;
            cmd.Parameters.Add("@CNP",SqlDbType.Int).Value=textBox1.Text;
            cmd.Parameters.Add("@Nume", SqlDbType.VarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Adresa", SqlDbType.VarChar).Value = textBox3.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show(i + " Data Saved");
                this.DialogResult = DialogResult.OK; ;
                this.Hide();
                new AddRadiografiiForm().Show(); //open Radiografii form
                //tableAdapterManager.UpdateAll(hospital_DatabaseDataSet);
            }
            else
            {
                MessageBox.Show("Invalid pacient data");
            }
        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_DatabaseDataSet);

        }

        private void AddPacientForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.hospital_DatabaseDataSet.Radiografii);
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.hospital_DatabaseDataSet.Pacienti);

        }
    }
}

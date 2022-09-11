using Hospital_Database.Hospital_DatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Database
{
    public partial class AddRadiografiiForm : Form
    {
        public AddRadiografiiForm()
        {
            InitializeComponent();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;
                textBox2.Text = of.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Random rnd = new Random();
           //int id = Convert.ToInt32(rnd.Next(5000));
            string save = "INSERT INTO Radiografii(CNP,Imagine,Data,Diagnostic,Comentarii)" +
                "VALUES (@CNP,@Imagine,@Data,@Diagnostic,@Comentarii)";
            SqlCommand cmd = new SqlCommand(save);
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Andrei\\source\\repos\\Hospital Database\\Hospital Database\\Hospital Database.mdf\";Integrated Security=True;Connect Timeout=30");
            cmd.Connection = con;
            //cmd.Parameters.Add("@Id",SqlDbType.Int).Value=id;
            cmd.Parameters.Add("@CNP", SqlDbType.Int).Value = textBox1.Text;
            cmd.Parameters.Add("@Imagine", SqlDbType.VarChar,255).Value = textBox2.Text;
            cmd.Parameters.Add("@Data",SqlDbType.DateTime).Value=dateTimePicker1.Value;
            cmd.Parameters.Add("@Diagnostic",SqlDbType.VarChar,100).Value=textBox3.Text;
            cmd.Parameters.Add("@Comentarii",SqlDbType.VarChar,255).Value=richTextBox1.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show(i + " Data Saved");
                this.DialogResult = DialogResult.OK; ;
                this.Hide();
                //tableAdapterManager.UpdateAll(hospital_DatabaseDataSet);
                new MainInterface().Show();//return to main interface
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_DatabaseDataSet);

        }

        private void AddRadiografiiForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.hospital_DatabaseDataSet.Radiografii);
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.hospital_DatabaseDataSet.Pacienti);

        }
    }
 
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Database
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hospital_DatabaseDataSet);

        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.hospital_DatabaseDataSet.Radiografii);
            // TODO: This line of code loads data into the 'hospital_DatabaseDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.hospital_DatabaseDataSet.Pacienti);
            tableAdapterManager.UpdateAll(hospital_DatabaseDataSet);


        }

        private void newPacientButton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK; ;
            this.Hide();
            new AddPacientForm().Show();
        }

        private void radiografiiDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (radiografiiDataGridView.Rows[0].Cells[2].Value.ToString().Length !=0)
            {
                pictureBox1.ImageLocation = radiografiiDataGridView.Rows[0].Cells[2].Value.ToString();
            }
            else
            {
                pictureBox1.Image = null;
            }
            
        }
    }
}

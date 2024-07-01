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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ВБ_на_минималках
{
    public partial class Администратор : Form
    {
        DB DB = new DB();

        public int id;
        public Администратор()
        {
            InitializeComponent();
            ZacazShow();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id = Convert.ToInt32(row.Cells[0].Value);
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();

            }

            catch
            {
                MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


            void ZacazShow()
            {
                DB.openConnection();
                SqlCommand com = new SqlCommand(@"SELECT * from Zacaz ", DB.sqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Zacaz");
                dataGridView1.DataSource = ds.Tables[0];
                DB.closeConnection();

            }  
    }
}
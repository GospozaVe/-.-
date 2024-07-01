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

namespace ВБ_на_минималках
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // переделать запросы
            var loginUs = textBox1.Text;
            var paswordUs = textBox2.Text;
            db.openConnection();
            string querystring = $"SELECT  dopusk_lvl FROM Polzovatel WHERE loginn = {loginUs} AND password ={paswordUs}";
            SqlCommand command = new SqlCommand(querystring, db.getConnection());
            //command.Parameters.AddWithValue("@username", loginUs);
            //command.Parameters.AddWithValue("@password", paswordUs);



            int status = ((int)command.ExecuteScalar());

            db.closeConnection();

            if (status != 0)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //takeIDUser(loginUs, paswordUs);

                textBox1.Text = "";
                textBox2.Text = "";

                Form formToShow = null;

                switch (status)
                {
                    case 2712:
                        formToShow = new Администратор();
                        break;
                    case 1:
                        formToShow = new пользователь();
                        break;

                    default:
                        MessageBox.Show("Роль пользователя не распознана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                this.Hide();
                formToShow.ShowDialog();
                this.Show();


            }
        }
    }
}

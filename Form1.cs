using System;
using System.Data;
using System.Windows.Forms;

namespace _02_NoteApp
{
    public partial class Form1 : Form
    {
        DataTable table;

        public Form1()
        {
            InitializeComponent();

            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));
            dataGridView1.DataSource = table;

            dataGridView1.Columns["Messages"].Visible = false;//hide message column
            dataGridView1.Columns["Title"].Width = 218;

        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);

            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void Button_Read_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;//geting current chosen cell row index

            if (index > -1)//1st index is 0 so checking if any cell chosen
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();//item array[0] is 1st column 
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();//2nd
            }


        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;//geting current chosen cell row index

            table.Rows[index].Delete();


        }
    }
}

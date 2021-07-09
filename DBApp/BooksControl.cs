using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBApp
{
    public partial class BooksControl : UserControl
    {
        SQL db;
        int id;
        public BooksControl()
        {
            db = new SQL();
            InitializeComponent();
            db.Connection();
            Combobox();
            db.closeConnection();
        }

        public void Connect()
        {
            db.Connection();
            Update();
            db.closeConnection();
        }

        public void Combobox()
        {
            comboBox1.Items.Clear();
            var result = db.GetTable("Autor");
            while (result.Read())
                comboBox1.Items.Insert(int.Parse(result.GetValue(0).ToString())-1, result.GetValue(1).ToString());
        }

        public void Add()
        {
            db.Add("Books",textBox2.Text, textBox3.Text, "booktitle","autor_id");
            Connect();
        }

        public void Edit()
        {
            db.Edit("Books", textBox2.Text, textBox3.Text,id, "booktitle", "autor_id");
            Connect();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            textBox1.Text = id.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            //textBox2.Text= dataGridView1.CurrentCell.Value.ToString();

        }

        public void Delete()
        {
            db.Delete("Books", id);
            Connect();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var result = db.GetTable("Books");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2), result.GetValue(3));
        }

        private void BooksControl_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = (comboBox1.SelectedIndex+1).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBApp
{
    public partial class ReadersControl : UserControl
    {
        readonly SQL db;
        public static int index;
        int id;
        public ReadersControl()
        {
            db = new SQL();
            InitializeComponent();
            
        }

        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        public void Connect()
        {
            db.Connection();
            Update();
            db.closeConnection();
            Combobox2();
        }

        public void Combobox2()
        {
            db.Connection();
            var result = db.GetTable("[Group]");
            comboBox1.Items.Clear();
            while (result.Read())
            {
                comboBox1.Items.Add(result.GetValue(1).ToString());
            }
            db.closeConnection();
        }

        public void Add()
        {
            db.Add("Reader", textBox2.Text, textBox3.Text, "name", "group_id");
            db.closeConnection();
            Connect();
        }

        public void Edit()
        {
            db.Edit("Reader", textBox2.Text, textBox3.Text, id, "name", "group_id");
            Connect();
        }

        public void Delete()
        {
            db.Delete("Reader", id);
            Connect();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var result = db.GetTable("TableReaders");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2), result.GetValue(3), result.GetValue(4), result.GetValue(5));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            index = dataGridView1.CurrentRow.Index;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Connection();
            textBox3.Text = (comboBox1.SelectedIndex + 1).ToString();
            
            var result = db.Combobox("Groups", textBox3.Text);
            while (result.Read())
            {
                textBox4.Text = result.GetValue(2).ToString();
                textBox5.Text = result.GetValue(3).ToString();
            }
            db.closeConnection();
        }

    }
}

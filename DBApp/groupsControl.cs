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
    public partial class GroupsControl : UserControl
    {
        SQL db;
        int id;
        DataTable dt = new DataTable();
        public GroupsControl()
        {
            db = new SQL();
            InitializeComponent();
            Combobox();
        }

        public void Connect()
        {
            db.Connection();
            Update();
            db.closeConnection();
        }

        public void Combobox()
        {
            db.Connection();
            var result = db.GetTable("Direction");
            comboBox1.Items.Clear();
            while (result.Read())
            {
                comboBox1.Items.Add(result.GetValue(1).ToString());
            }
            db.closeConnection();
        }

        public void Add()
        {
            db.Add("[Group]", textBox2.Text, textBox3.Text, "studygroup", "direction_id");
            Connect();
        }

        public void Edit()
        {
            db.Edit("[Group]", textBox2.Text, textBox3.Text, id, "studygroup", "direction_id");
            Connect();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            textBox1.Text = id.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
        }

        public void Delete()
        {
            db.Delete("[Group]", id);
            Connect();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var result = db.GetTable("Groups");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2), result.GetValue(3));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = (comboBox1.SelectedIndex+1).ToString();

        }
    }
}

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
    public partial class InfoControl : UserControl
    {
        readonly SQL db;
        int id;
        List<int> listId=new List<int>();

        public InfoControl()
        {
            db = new SQL();
            InitializeComponent();
        }

        public void Connect()
        {
            Update();
            Combobox();
        }

        public void Combobox()
        {
            db.Connection();
            var result = db.GetTable("Book");
            comboBox1.Items.Clear();
            while (result.Read())
            {
                comboBox1.Items.Add(result.GetValue(1).ToString());
            }
            db.closeConnection();
        }

        public void Add()
        {
            db.AddValueInfo(textBox1.Text,int.Parse(textBox5.Text)+1, textBox6.Text, textBox8.Text, textBox9.Text);
            db.closeConnection();
            Connect();
        }

        public void Edit()
        {
            db.EditValueInfo(listId.ElementAt(id), textBox5.Text, textBox6.Text, textBox8.Text, textBox9.Text);
            Connect();
        }

        public void Delete()
        {
            db.Delete("String", listId.ElementAt(id));
            Connect();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            textBox12.Text = "";
            textBox8.Text = "";
            textBox9.Text="";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
            textBox3.Text = "";
            textBox11.Text = "";
            textBox4.Text = "";

            var result = db.GetTableInfo(ReadersControl.index+1);
            while (result.Read())
            {
                    listId.Add(int.Parse(result.GetValue(0).ToString()));
                    textBox1.Text = result.GetValue(1).ToString();
                    textBox2.Text = result.GetValue(2).ToString();
                    textBox10.Text = result.GetValue(3).ToString();
                    textBox3.Text = result.GetValue(4).ToString();
                    textBox11.Text = result.GetValue(5).ToString();
                    textBox4.Text = result.GetValue(6).ToString();
                    dataGridView1.Rows.Add(result.GetValue(7), result.GetValue(8), result.GetValue(9),
                    result.GetValue(10), result.GetValue(11), result.GetValue(12), result.GetValue(13));
            }
            db.closeConnection();
            if (textBox1.Text == "")
            {
                db.Connection();
                var res = db.Combobox("TableReaders", (ReadersControl.index + 1).ToString());
                while (res.Read())
                {
                    textBox1.Text = res.GetValue(0).ToString();
                    textBox2.Text = res.GetValue(1).ToString();
                    textBox3.Text = res.GetValue(5).ToString();
                    textBox10.Text = res.GetValue(4).ToString();
                    textBox11.Text = res.GetValue(2).ToString();
                    textBox4.Text = res.GetValue(3).ToString();
                }
                db.closeConnection();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = dataGridView1.CurrentRow.Index;
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            textBox12.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Connection();
            textBox6.Text = (comboBox1.SelectedIndex + 1).ToString();

            var result = db.Combobox("Books", textBox6.Text);
            while (result.Read())
            {
                textBox7.Text = result.GetValue(2).ToString();
                textBox12.Text = result.GetValue(3).ToString();
            }
            db.closeConnection();
        }
    }
}

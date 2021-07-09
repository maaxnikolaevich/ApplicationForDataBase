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
    public partial class AutorControl : UserControl
    {
        SQL db;
        int id;
        public AutorControl()
        {
            db = new SQL();
            InitializeComponent();
        }

        public void Connect()
        {
            db.Connection();
            Update();
            db.closeConnection();
        }

        public void Add()
        {
            db.AddOneValue("Autor", textBox2.Text,"autor");
            Connect();
        }

        public void Edit()
        {
            db.EditOneValue("Autor", textBox2.Text, id, "autor");
            Connect();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
            textBox1.Text = id.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
        }

        public void Delete()
        {
            db.Delete("Autor", id);
            Connect();
        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var result = db.GetTable("Autor");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1));
        }
    }
}

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
    public partial class TotalAutors : UserControl
    {
        readonly SQL db;
        public TotalAutors()
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

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            var result = db.GetTable("CountWorks");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2));
        }
    }
}

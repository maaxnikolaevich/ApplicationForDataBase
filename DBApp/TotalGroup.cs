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
    public partial class TotalGroup : UserControl
    {  
        readonly SQL db;
        public TotalGroup()
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
            var result = db.GetTable("DirTotal");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2), result.GetValue(3), result.GetValue(4));
        }
    }
}

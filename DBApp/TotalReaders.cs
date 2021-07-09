﻿using System;
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
    public partial class Count : UserControl
    {
        readonly SQL db;

        public Count()
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
            var result = db.GetTable("TotalReaders");
            while (result.Read())
                dataGridView1.Rows.Add(result.GetValue(0), result.GetValue(1), result.GetValue(2), result.GetValue(3), result.GetValue(4), result.GetValue(5));
        }

    }
}

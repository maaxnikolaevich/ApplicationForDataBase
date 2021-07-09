using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBApp
{
    public partial class Form1 : Form
    {
        bool OpenReaders, OpenGroups, OpenBooks, OpenDir, OpenAutors, Info;
        public Form1()
        {
            InitializeComponent();
            button7.Location = new Point(18, 36);
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;
            ReadersControl.BringToFront();
            ReadersControl.Connect();
            button6.Visible = true;
            button12.Visible = false;
            OpenReaders = true;
            button15.Visible = true;
            button6.Enabled = true;
            Info = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Location = new Point(12, 91);
            button7.Location = new Point(18, 36);
            button2.Location = new Point(12, 146);
            button3.Location = new Point(12, 199);
            button4.Location = new Point(12, 257);
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;
            ReadersControl.BringToFront();
            button6.Visible = true;
            button12.Visible = false;
            OpenReaders = true;
            OpenGroups = false;
            OpenBooks = false;
            OpenDir = false;
            OpenAutors = false;
            button15.Visible = true;
            button6.Enabled = true;
            Info = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button7.Location = new Point(12, 36);
            button1.Location = new Point(18, 91);
            button2.Location = new Point(12, 146);
            button3.Location = new Point(12, 199);
            button4.Location = new Point(12, 257);
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            GroupsControl.BringToFront();
            GroupsControl.Connect();
            button6.Visible = false;
            button12.Visible = false;
            OpenReaders =false;
            OpenGroups = true;
            OpenBooks = false;
            OpenDir = false;
            OpenAutors = false;
            button15.Visible = true;
            Info = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button7.Location = new Point(12, 36);
            button1.Location = new Point(12, 91);
            button3.Location = new Point(12, 199);
            button4.Location = new Point(12, 257);
            button2.Location = new Point(18, 146);
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            BooksControl.BringToFront();
            BooksControl.Connect();
            button6.Visible = false;
            button12.Visible = false;
            OpenReaders = false;
            OpenGroups = false;
            OpenBooks = true;
            OpenDir = false;
            OpenAutors = false;
            button15.Visible = false;
            Info = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Location = new Point(12, 146);
            button7.Location = new Point(12, 36);
            button1.Location = new Point(12, 91);
            button4.Location = new Point(12, 257);
            button3.Location = new Point(18, 199);
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            DirectionControl.BringToFront();
            DirectionControl.Connect();
            button6.Visible = false;
            button12.Visible = false;
            OpenReaders = false;
            OpenGroups = false;
            OpenBooks = false;
            OpenDir = true;
            OpenAutors = false;
            button15.Visible = false;
            Info = false;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (OpenGroups == true)
            {
               GroupsControl.Add();
            }
            if (OpenBooks == true)
            {
                BooksControl.Add();
            }
            if (OpenAutors == true)
            {
                AutorControl.Add();
            }

            if (OpenDir == true)
            {
                DirectionControl.Add();
            }

            if (OpenReaders == true)
            {
                ReadersControl.Add();
            }

            if (Info == true)
            {
                InfoControl.Add();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (OpenGroups == true)
            {
                GroupsControl.Delete();
            }
            if (OpenBooks == true)
            {
               BooksControl.Delete();
            }
            if (OpenAutors == true)
            {
                AutorControl.Delete();
            }
            if (OpenDir == true)
            {
               DirectionControl.Delete();
            }

            if (OpenReaders == true)
            {
                ReadersControl.Delete();
            }
            if (Info == true)
            {
                InfoControl.Delete();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //if (OpenGroups == true)
            //{
            //    GroupsControl.Edit();
            //}
            //if (OpenBooks == true)
            //{
            //    BooksControl.Edit();
            //}
            //if (OpenAutors == true)
            //{
            //    AutorControl.Edit();
            //}
            //if (OpenDir == true)
            //{
            //    DirectionControl.Edit();
            //}

            if (OpenReaders == true)
            {
                ReadersControl.Clear();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (OpenAutors == true)
            {
                TotalAutors.BringToFront();
                TotalAutors.Connect();
            }

            if (OpenReaders == true)
            {
                TotalReaders.BringToFront();
                TotalReaders.Connect();
            }

            if (OpenGroups == true)
            {
                TotalGroup.BringToFront();
                TotalGroup.Connect();
            }
            button12.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (OpenGroups == true)
            {
                GroupsControl.Edit();
            }
            if (OpenBooks == true)
            {
               BooksControl.Edit();
            }
            if (OpenAutors == true)
            {
               AutorControl.Edit();
            }
            if (OpenDir == true)
            {
              DirectionControl.Edit();
            }

            if (OpenReaders == true)
            {
                ReadersControl.Edit();
            }

            if (Info == true)
            {
                InfoControl.Edit();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Location = new Point(12, 146);
            button7.Location = new Point(12, 36);
            button1.Location = new Point(12, 91);
            button3.Location = new Point(12, 199);
            button4.Location = new Point(18, 257);
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            AutorControl.BringToFront();
            AutorControl.Connect();
            button6.Visible = false;
            button12.Visible = false;
            OpenReaders = false;
            OpenGroups = false;
            OpenBooks = false;
            OpenDir = false;
            OpenAutors = true;
            button15.Visible = true;
            Info = false;

        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            button12.Visible = true;
            button6.Enabled = false;
            InfoControl.Connect();
            InfoControl.BringToFront();
            Info = true;
            OpenReaders = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {

            Info = false;
            OpenReaders = true;
            if (OpenAutors == true)
            {
                AutorControl.BringToFront();
                AutorControl.Connect();
            }

            if (OpenReaders == true)
            {
                ReadersControl.Connect();
                ReadersControl.BringToFront();
            }

            if (OpenGroups == true)
            {
                GroupsControl.BringToFront();
                GroupsControl.Connect();
            }
            button12.Visible = false;
            button6.Enabled = true;
        }

    }
}

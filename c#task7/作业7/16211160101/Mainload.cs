using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Mainload : Form
    {
        public Mainload()
        {
            InitializeComponent();
        }

        private void Mainload_Load(object sender, EventArgs e)
        {
            Logins al = new Logins();
            al.ShowDialog();
            if (al.islogged == 0)
            {
                Close();
            }
        }
    }
}

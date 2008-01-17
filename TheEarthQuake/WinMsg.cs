using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class WinMsg : Form
    {
        public WinMsg()
        {
            InitializeComponent();
        }
        public void SetText(string t)
        {
            this.label1.Text = t;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class MapSelectForm : Form
    {
        public MapSelectForm()
        {
            InitializeComponent();
        }

        /* This method handles key pressed event. */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                /* generate map */
                case Keys.L:
                    // invoke generate map button_click 
                    return true;

                /* exit */
                case Keys.Escape:
                case Keys.Left:
                    this.button2_Click(this, null);
                    return true;    // will it ever be called? 

                /* proceed */
                case Keys.Enter:
                case Keys.Right:
                    this.button1_Click(this, null);
                    return true;    // will this ever be invoked?

                /* let the base class handle the key */
                default:
                    return base.ProcessDialogKey(keyData);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;

            SelectPlayerForm window = new SelectPlayerForm();
            window.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            GameForm gameForm = new GameForm();
            gameForm.ShowDialog();
        }
    }
}
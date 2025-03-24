using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }

        private void ShowHideConsole_Click(object sender, EventArgs e)
        {
            if (Program.IsConsoleDisplayed == false)
            {
                Program.ShowConsoleWindow(true);
                ShowHideButton.Text = "Hide Console";
            }
            else
            {
                Program.ShowConsoleWindow(false);
                ShowHideButton.Text = "Show Console";
            }
        }
    }
}

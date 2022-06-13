using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace csharp_arduino_bluttuth
{
    public partial class Form1 : Form
    {
        private SerialPort myport;
        public Form1()
        {
            InitializeComponent();
            init();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myport.WriteLine("a");
           

        }

        private void init()
        {
            try
            {
                myport = new SerialPort();
                myport.BaudRate = 9600;
                myport.PortName = "COM9";
                myport.Open();
               
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            myport.WriteLine("d");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            myport.WriteLine("b");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myport.WriteLine("c");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myport.WriteLine("e");
        }

       

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            myport.WriteLine("a");
        }

    

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            myport.WriteLine("b");
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            myport.WriteLine("d");
        }

        private void button2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            myport.WriteLine("c");
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Step_4
{
    public partial class outputForm : Form
    {
        Form1 mainForm;
        public outputForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
      public  void shangeout(string text)
        {
            txtoutput.Text = text;
        }
        public string shangeout()
        {
            return txtoutput.Text;
        }

        public void clearout()
        {
             txtoutput.Clear();
        }
        private void outputForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
     
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //     Console.Out.Close();
            ///   Console.Clear();
            //    FreeConsole();
            // Console.Clear();
            
            this.clearout();
            Hide();
            //Form1.setset();
         
                //   var handle = GetConsoleWindow();

                // Hide
                //  Console.Clear();
                //  ShowWindow(handle, SW_HIDE);
                //  Console.Clear();
             
            }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Width = 1800;
            this.Height = 980;
          
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       
        public void textviow()
        {
            textBox1.ReadOnly = false;
        }
        public void textviow2()
        {
            textBox1.ReadOnly = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
      public  int input;
      //  Form1 fff;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.ReadOnly == false)
                {
                    try
                    {
                        input = Convert.ToInt32(textBox1.Text);

                        txtoutput.Text += " " + textBox1.Text;
                        textBox1.Clear();
                        // this.fff = fff;
                        mainForm.go();

                    }
                    catch (Exception z)
                    {
                        // textBox1.Text = "ادخل رقم صحيح ";
                        MessageBox.Show(z.ToString());
                    }
                }

            }
        }
    }
 }



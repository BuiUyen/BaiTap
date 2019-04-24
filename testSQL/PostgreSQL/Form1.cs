using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PgSql
{
   public partial class Form1 : Form
   {
      List<string> dataItems = new List<string>();

      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         PostGreSQL pgTest = new PostGreSQL();
         dataItems = pgTest.PostgreSQLtest1();
         tbData.Clear();
         for (int i = 0; i < dataItems.Count; i++)
         {
            tbData.Text += dataItems[i];            
         }
      }

      private void button2_Click(object sender, EventArgs e)
      {
         PostGreSQL pgTest = new PostGreSQL();
         dataItems = pgTest.PostgreSQLtest2();
         tbData.Clear();
         for (int i = 0; i < dataItems.Count; i++)
         {
            tbData.Text += dataItems[i];            
         }
      }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

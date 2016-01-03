using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDialog dlg = new FrmDialog();
            //Subscribe this form for callback
            dlg.AddItemCallback = new AddItemDelegate(AddItemCallbackFn);
            dlg.ShowDialog();
        }

        private void AddItemCallbackFn(string item)
        {
            lstBox.Items.Add(item);
        }
    }
}

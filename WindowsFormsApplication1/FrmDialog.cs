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
    public delegate void AddItemDelegate(string item);    

    public partial class FrmDialog : Form
    {
        //Declare delagete callback function, the owner of communication
        public AddItemDelegate AddItemCallback;

        public FrmDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemCallback(txtItemText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private readonly FormModel _model = new FormModel();

        private BindingSource _bindingSource;
        private int _i = 0;
        private int _n = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _bindingSource = new BindingSource {DataSource = _model};

            button2.DataBindings.Add(new Binding("Enabled", _bindingSource, "CanSend", false, DataSourceUpdateMode.OnPropertyChanged));

            NameTextBox.DataBindings.Add(new Binding("Text", _bindingSource, "Person.Name", false, DataSourceUpdateMode.OnPropertyChanged));
            LastnameTextBox.DataBindings.Add(new Binding("Text", _bindingSource, "Person.Lastname", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            label1.Focus();
            MessageBox.Show($"Name: {_model.Person.Name}, Lastname: {_model.Person.Lastname}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _i++;
            _n++;

            _model.Person.Name = $"Binding {_i}";
            _model.Person.Lastname = $"Binding {_n}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _model.Person.Name = "Can";
            _model.Person.Lastname = "Can";
        }
    }
}

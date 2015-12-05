using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public static class TextBoxExtensions
    {
        public static void Bind(this TextBox tb, BindingSource data, string property)
        {
            var binding = new Binding("Text", data, property);
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

            tb.DataBindings.Add(binding);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodPlanner
{
    public partial class AddIngredientForm : Form
    {
        public AddIngredientForm()
        {
            InitializeComponent();
        }

        private void AddIngredientFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    if (NameTB.Text.Trim() == "")
                    {
                        NameTB.Focus();
                        throw new Exception("Поле \"Название\" не заполнено");
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
    }
}

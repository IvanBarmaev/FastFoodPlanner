using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FastFoodPlanner
{
    public partial class IngredientForm : Form
    {
        private string getDirectory()
        {
            string[] directory = Directory.GetCurrentDirectory().Split('\\');
            string DB_directory = "";
            for (int i = 0; i < directory.Length - 3; i++)
                DB_directory += directory[i] + "\\";
            return DB_directory;
        }

        SQLiteConnection connection;
        SQLiteCommand command;
        List<Ingredient> ingredients = new List<Ingredient>();
        public IngredientForm()
        {
            InitializeComponent();
            connection = new SQLiteConnection($"Data Source={getDirectory()}FastFoodPlannerDB.db;Version=3");
            command = new SQLiteCommand(connection);
            connection.Open();
            command.CommandText = "SELECT * FROM Ингредиент";
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(data);
            foreach (DataRow i in data.Rows)
            {
                ingredients.Add(new Ingredient(i.Field<string>("Название"), i.Field<long>("Количество")));
                IngredientLB.Items.Add(ingredients.Last());
            }
        }

        private void IngredientFormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddIngredientForm add_ingredient = new AddIngredientForm();
            if (add_ingredient.ShowDialog() == DialogResult.OK)
            {
                var transaction = connection.BeginTransaction();
                try
                {
                    command.CommandText = "INSERT INTO Ингредиент (Название, Количество) VALUES (:name, :count)";
                    command.Parameters.AddWithValue("name", add_ingredient.NameTB.Text);
                    command.Parameters.AddWithValue("count", add_ingredient.ValueNUD.Value);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    ingredients.Add(new Ingredient(add_ingredient.NameTB.Text, Convert.ToInt32(add_ingredient.ValueNUD.Value)));
                    IngredientLB.Items.Add(ingredients.Last());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            if (IngredientLB.SelectedIndex != -1)
            {
                Ingredient temp = ingredients[IngredientLB.SelectedIndex];

            }
        }
    }
}

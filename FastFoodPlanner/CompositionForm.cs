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

namespace FastFoodPlanner
{
    public partial class CompositionForm : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        List<Ingredient> all_ingredients = new List<Ingredient>();
        List<Ingredient> ingredients = new List<Ingredient>();
        long dish_ID;
        private string getDirectory()
        {
            string[] directory = Directory.GetCurrentDirectory().Split('\\');
            string DB_directory = "";
            for (int i = 0; i < directory.Length - 3; i++)
                DB_directory += directory[i] + "\\";
            return DB_directory;
        }

        public CompositionForm(long ID, SQLiteConnection conn)
        {
            InitializeComponent();
            dish_ID = ID;
            connection = conn;
            command = new SQLiteCommand(connection);
            command.CommandText = "SELECT ID_ингредиента, Название FROM Ингредиент";
            DataTable ingredient_data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(ingredient_data);
            foreach (DataRow i in ingredient_data.Rows)
            {
                all_ingredients.Add(new Ingredient(i.Field<long>("ID_ингредиента"), i.Field<string>("Название"), 0));
                AllIngredientLB.Items.Add(all_ingredients.Last().name);
            }
            command.CommandText = $"SELECT * FROM Состав_блюда WHERE ID_блюда = {ID}";
            DataTable dish_table = new DataTable();
            adapter.Fill(dish_table);
            foreach (DataRow i in dish_table.Rows)
            {
                var temp = all_ingredients.Where(value => value.ID == i.Field<long>("ID_ингредиента"));
                ingredients.Add(temp.First());
                DishIngredientLB.Items.Add(ingredients.Last().name);
            }
        }

        private void CompositionFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                try
                {
                    command.CommandText = $"DELETE FROM Состав_блюда WHERE ID_блюда = {dish_ID}";
                    command.ExecuteNonQuery();
                    foreach (Ingredient i in ingredients)
                    {
                        command.CommandText = "INSERT INTO Состав_блюда (ID_ингредиента, ID_блюда) VALUES (:ingredient_ID, :dish_ID)";
                        command.Parameters.AddWithValue("ingredient_ID", i.ID);
                        command.Parameters.AddWithValue("dish_ID", dish_ID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (AllIngredientLB.SelectedIndex != -1)
            {
                Ingredient temp = all_ingredients[AllIngredientLB.SelectedIndex];
                ingredients.Add(temp);
                DishIngredientLB.Items.Add(temp.name);
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (DishIngredientLB.SelectedIndex != -1)
            {
                ingredients.RemoveAt(DishIngredientLB.SelectedIndex);
                DishIngredientLB.Items.RemoveAt(DishIngredientLB.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (var i in all_ingredients)
                message += i.name + "\n";
            MessageBox.Show(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (var i in ingredients)
                message += i.name + "\n";
            MessageBox.Show(message);
        }
    }
}

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
    public partial class MainForm : Form
    {
        SQLiteConnection connection;
        SQLiteCommand command;
        List<Food> foods = new List<Food>();
        private string getDirectory()
        {
            string[] directory = Directory.GetCurrentDirectory().Split('\\');
            string DB_directory = "";
            for (int i = 0; i < directory.Length - 3; i++)
                DB_directory += directory[i] + "\\";
            return DB_directory;
        }

        public MainForm()
        {
            InitializeComponent();
            connection = new SQLiteConnection($"Data Source={getDirectory()}FastFoodPlannerDB.db;Version=3");
            command = new SQLiteCommand(connection);
            connection.Open();
            command.CommandText = "SELECT * FROM Блюдо";
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(data);
            foreach (DataRow i in data.Rows)
            {
                foods.Add(new Food(i.Field<string>("Название"), i.Field<long>("Стоимость"), i.Field<string>("Описание")));
                MenuLB.Items.Add(foods.Last());
                //MenuLB.Items.Add($"{i.Field<long>("ID_блюда")} {i.Field<string>("Название")}. Стоимость: {i.Field<double>("Стоимость")}");
            }
        }

        private void AddFoodBtn_Click(object sender, EventArgs e)
        {
            AddFoodForm add_food = new AddFoodForm();
            if (add_food.ShowDialog() == DialogResult.OK )
            {
                var transaction = connection.BeginTransaction();
                try
                {
                    foreach (Food food in foods)
                    {
                        if (food.name == add_food.NameTB.Text)
                            throw new Exception("Блюдо с таким названием уже существует.");
                    }
                    command.CommandText = "INSERT INTO Блюдо (Название, Стоимость, Описание) VALUES (:name, :price, :description)";
                    command.Parameters.AddWithValue("name", add_food.NameTB.Text);
                    command.Parameters.AddWithValue("price", add_food.ValueNUD.Value);
                    command.Parameters.AddWithValue("description", add_food.DescriptionRTB.Text);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    foods.Add(new Food(add_food.NameTB.Text, Convert.ToInt32(add_food.ValueNUD.Value), add_food.DescriptionRTB.Text));
                    MenuLB.Items.Add(foods.Last());
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }

        private void MenuLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                DescriptionRTB.Clear();
                Food temp = MenuLB.SelectedItem as Food;
                DescriptionRTB.Text = temp.description;
            }
        }

        private void DeleteFoodBtn_Click(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                Food temp = MenuLB.SelectedItem as Food;
                command.CommandText = $"DELETE FROM Блюдо WHERE Название=\"{temp.name}\"";
                command.ExecuteNonQuery();
                foods.RemoveAt(MenuLB.SelectedIndex);
                MenuLB.Items.RemoveAt(MenuLB.SelectedIndex);
                DescriptionRTB.Clear();
            }
        }

        private void ChnageFoodBtn_Click(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                Food temp = foods[MenuLB.SelectedIndex];
                AddFoodForm change_food = new AddFoodForm();
                change_food.AcceptBtn.Text = "Изменить";
                change_food.NameTB.Text = temp.name;
                change_food.ValueNUD.Value = Convert.ToDecimal(temp.price);
                change_food.DescriptionRTB.Text = temp.description;
                if (change_food.ShowDialog() == DialogResult.OK)
                {
                    command.CommandText = $"UPDATE Блюдо SET Название=\"{change_food.NameTB.Text}\"" +
                        $", Стоимость={Convert.ToInt32(change_food.ValueNUD.Value)}, Описание=\"{change_food.DescriptionRTB.Text}\" WHERE Название=\"{temp.name}\"";
                    command.ExecuteNonQuery();
                    temp.name = change_food.NameTB.Text;
                    temp.price = Convert.ToInt32(change_food.ValueNUD.Value);
                    temp.description = change_food.DescriptionRTB.Text;
                    MenuLB.Items[MenuLB.SelectedIndex] = temp;
                }
                
            }
        }

        private void ChangeReceptBtn_Click(object sender, EventArgs e)
        {
            if (MenuLB.SelectedIndex != -1)
            {
                CompositionForm composition = new CompositionForm();
                if (composition.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void IngredientListBtn_Click(object sender, EventArgs e)
        {
            IngredientForm ingredients = new IngredientForm();
            if (ingredients.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}

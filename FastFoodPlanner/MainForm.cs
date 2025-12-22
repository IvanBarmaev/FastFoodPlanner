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
            SQLiteConnection connection = new SQLiteConnection($"Data Source={getDirectory()}FastFoodPlannerDB.db;Version=3");
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Dish";
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(data);
            foreach (DataRow i in data.Rows)
            {
                MenuLB.Items.Add($"{i.Field<long>("ID_блюда")} {i.Field<string>("Название")}. Стоимость: {i.Field<double>("Стоимость")}");
            }
        }

        private void AddFoodBtn_Click(object sender, EventArgs e)
        {
            AddFoodForm add_food = new AddFoodForm();
            if (add_food.ShowDialog() == DialogResult.OK )
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={getDirectory()}FastFoodPlannerDB.db;Version=3");
                SQLiteCommand command = new SQLiteCommand(connection);

            }
        }
    }
}

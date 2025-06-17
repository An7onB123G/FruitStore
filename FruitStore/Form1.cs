using FruitStore.Controllers;
using FruitStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FruitStore
{
    public partial class Form1 : Form
    {

        FruitController fruitController = new FruitController();
        FruitTypeControllers fruitTypeControllers = new FruitTypeControllers();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fruitStoreDataSet1.Fruits' table. You can move, or remove it, as needed.
            this.fruitsTableAdapter.Fill(this.fruitStoreDataSet1.Fruits);

            List<FruitType> allFruitTypes = fruitTypeControllers.GetAllFruitTypes();
            cmb_type.DataSource = allFruitTypes;
            cmb_type.DisplayMember = "Name";
            cmb_type.ValueMember = "Id";

        }

        private void ClearScreen()
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_description.Clear();
            txt_price.Clear();
            cmb_type.Text = "";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_description.Text == "" || txt_price.Text == "" || cmb_type.Text == "")
            {
                MessageBox.Show("Не си въвел данните!");
                return;
            }
            Fruit newFruit = new Fruit();
            newFruit.Name = txt_name.Text;
            newFruit.Description = txt_description.Text;
            newFruit.Price = int.Parse(txt_price.Text);
            newFruit.FruitTypeId = (int)cmb_type.SelectedValue;

            fruitController.Create(newFruit);
            this.fruitsTableAdapter.Fill(this.fruitStoreDataSet1.Fruits);
            MessageBox.Show("Успешно добавихте плод!");
            ClearScreen();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Не си въвел id за да бъде изтирто!");
                return;
            }
            int fruitId = int.Parse(txt_id.Text);

            Fruit findedFruit = fruitController.Get(fruitId);
            if (findedFruit == null)
            {
                MessageBox.Show($"Няма продукт с id {fruitId}");
                return;
            }

            fruitController.Delete(fruitId);
            this.fruitsTableAdapter.Fill(this.fruitStoreDataSet1.Fruits);
            MessageBox.Show("Успешно изтрихте плод!");
            ClearScreen();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("Не си въвел id за да бъде променено!");
                return;
            }

            if (txt_name.Text == "" || txt_description.Text == "" || txt_price.Text == "" || cmb_type.Text == "")
            {
                MessageBox.Show("Не си въвел данните които искаш да се променят!");
                return;
            }

            int fruitId = int.Parse(txt_id.Text);

            Fruit findedFruit = fruitController.Get(fruitId);
            if (findedFruit == null)
            {
                MessageBox.Show($"Няма продукт с id {fruitId}");
                return;
            }

            findedFruit.Name = txt_name.Text;
            findedFruit.Description = txt_description.Text;
            findedFruit.Price = decimal.Parse(txt_price.Text);
            findedFruit.FruitTypeId = (int)cmb_type.SelectedValue;

            fruitController.Update(fruitId, findedFruit);
            this.fruitsTableAdapter.Fill(this.fruitStoreDataSet1.Fruits);
            MessageBox.Show("Успешно променихте плод!");
            ClearScreen();
        }
    }
}

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

        //private void LoadRecord(Fruit fruit)
        //{
        //    txt_id.Text = fruit.Id.ToString();
        //    txt_name.Text = fruit.Name;
        //    txt_description.Text = fruit.Description;
        //    txt_price.Text = fruit.Price.ToString();
        //    cmb_type.Text = fruit.FruitType.Name;
        //}

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
            if (string.IsNullOrEmpty(txt_name.Text) || txt_description.Text == "" || txt_price.Text == "")
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
            MessageBox.Show("Успешно добавихте плод!");
            ClearScreen();
        }
    }
}

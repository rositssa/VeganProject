using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeganProject
{
    public partial class VeganForm : Form
    {
        VeganLogic veganController = new VeganLogic();
        VeganTypeLogic veganTypeController = new VeganTypeLogic();
        public VeganForm()
        {
            InitializeComponent();
        }
        private void LoadRecord(Vegan vegan)
        {
            tbId.BackColor = Color.White;
            tbId.Text=vegan.Id.ToString();
            tbName.Text = vegan.Name.ToString();
            tbDesc.Text = vegan.Description.ToString();
            tbPrice.Text = vegan.Price.ToString();
            cbType.Text = vegan.VeganTypes.Name;
        }
        private void ClearScreen()
        {
            tbId.BackColor=Color.White;
            tbId.Clear();
            tbName.Clear();
            tbDesc.Clear();
            tbPrice.Clear();
            cbType.Text = "";
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void VeganForm_Load(object sender, EventArgs e)
        {
            List<VeganType> allTypes = veganTypeController.GetAllVeganTypes();
            cbType.DataSource = allTypes;
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "Id";
            btnSelAll_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || tbName.Text==" ")
            {
                MessageBox.Show("Въведете данни");
                tbName.Focus();
                return;
            }
            Vegan newVegan = new Vegan();
            newVegan.Name = tbName.Text;
            newVegan.Description = tbDesc.Text;
            newVegan.Price = double.Parse(tbPrice.Text);
            newVegan.VeganTypesId = (int)cbType.SelectedValue;

            veganController.Create(newVegan);
            MessageBox.Show("Записът е добавен");
            ClearScreen();
            btnSelAll_Click(sender, e);
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            List<Vegan> allVegans = veganController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allVegans)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name}. {item.Description}." +
                    $" {item.Price}. {item.VeganTypes.Name}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(tbId.Text) || !tbId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                tbId.BackColor = Color.Red;
                tbId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(tbId.Text);
            }
            Vegan findedvegan = veganController.Get(findId);
            if (findedvegan == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                tbId.BackColor = Color.Red;
                tbId.Focus();
                return;
            }
            LoadRecord(findedvegan);
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(tbId.Text) || !tbId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                tbId.BackColor = Color.Red;
                tbId.Focus();
                return;
            }
            else
            {
                findId= int.Parse(tbId.Text);
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                Vegan findedvegan = veganController.Get(findId);
                if (findedvegan == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    tbId.BackColor = Color.Red;
                    tbId.Focus();
                    return;
                }
                LoadRecord(findedvegan);
            }
            else
            {
                Vegan updatedVegan = new Vegan();
                updatedVegan.Name = tbName.Text;
                updatedVegan.Description = tbDesc.Text;
                updatedVegan.Price = double.Parse(tbPrice.Text);
                updatedVegan.VeganTypesId = (int)cbType.SelectedValue;

                veganController.Update(findId, updatedVegan);
            }
            btnSelAll_Click(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(tbId.Text) || !tbId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене");
                tbId.BackColor = Color.Red;
                tbId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(tbId.Text);
            }
            Vegan findedVegan = veganController.Get(findId);
            if (findedVegan == null)
            {
           
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                tbId.BackColor = Color.Red;
                tbId.Focus();
                return;
            }
            LoadRecord(findedVegan);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис номер:"
                + findId + "?", "Prompt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                veganController.Delete(findId);
            }
            btnSelAll_Click(sender, e);
        }
    }
}

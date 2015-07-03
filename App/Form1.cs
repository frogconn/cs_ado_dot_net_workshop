using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo_ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var personAccessor = new PersonAccessor();
            gvPersons.DataSource = personAccessor.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var personAccessor = new PersonAccessor();
                var data = personAccessor.GetById(Convert.ToInt32(txtId.Text));
                if (data.Rows.Count > 0)
                {
                    txtFirstName.Text = data.Rows[0]["FirstName"].ToString();
                    txtLastName.Text = data.Rows[0]["LastName"].ToString();
                    txtMiddleName.Text = data.Rows[0]["MiddleName"].ToString();
                    if (data.Rows[0]["Gender"].ToString() == "M")
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                var personAccessor = new PersonAccessor();
                string gender="";
                if (rbMale.Checked == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                personAccessor.Insert(txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, gender);
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtMiddleName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var personAccessor = new PersonAccessor();
                string gender = "";
                if (rbMale.Checked == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                personAccessor.Update(Convert.ToInt32(txtId.Text),txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, gender);
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtMiddleName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

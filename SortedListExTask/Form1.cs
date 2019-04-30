using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        Dictionary<DateTime, string> tasks = new Dictionary<DateTime, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTask.Text == "") { MessageBox.Show("You need to enter a task", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                tasks.Add(dtpTaskDate.Value, txtTask.Text);

                lstTasks.DataSource = new BindingSource(tasks, null);
                lstTasks.DisplayMember = "Key";
                lstTasks.ValueMember = "Value";

                lstTasks.ClearSelected();
                txtTask.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Only one task per date is allowed", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if(lstTasks.SelectedIndex == -1) { MessageBox.Show("you need to select a task you want to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            foreach (var field in tasks.Where(t => t.Value == lstTasks.SelectedValue))
            {
                tasks.Remove(field.Key);
                break;
            }
            
            
            lstTasks.ClearSelected();
            lblTaskDetails.ResetText();

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = "";
            foreach (var item in tasks)
            {
                msg += $"{item.Key} {item.Value} \n";
            }
            MessageBox.Show(msg);
        }

        private void lstTasks_Click(object sender, EventArgs e)
        {
            lblTaskDetails.Text = lstTasks.SelectedValue.ToString();
        }
    }
}

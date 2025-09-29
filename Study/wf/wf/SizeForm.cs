using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace wf
{
    public partial class SizeForm : Form
    {
        TextBox txt;
        ContextMenuStrip contextMenu;

        public SizeForm()
        {
            DataSet ds = new DataSet("MyDataSet");

            // Create first table
            DataTable table1 = new DataTable("Employees");
            table1.Columns.Add("ID", typeof(int));
            table1.Columns.Add("Name", typeof(string));
            table1.Rows.Add(1, "Alice");
            table1.Rows.Add(2, "Bob");

            // Create second table
            DataTable table2 = new DataTable("Departments");
            table2.Columns.Add("DeptID", typeof(int));
            table2.Columns.Add("DeptName", typeof(string));
            table2.Rows.Add(101, "HR");
            table2.Rows.Add(102, "IT");

            // Add tables to DataSet
            ds.Tables.Add(table1);
            ds.Tables.Add(table2);

            // Display table1 in DataGridView
            DataGridView grid = new DataGridView
            {
                DataSource = ds.Tables["Employees"],
                Dock = DockStyle.Fill
            };

            Controls.Add(grid);

            this.Text = "DataSet Example";
            this.Size = new System.Drawing.Size(400, 250);
        }
    }
        }

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panels
{
    public partial class ListViewForm : Form
    {
        BindingList<TextData> ls = new BindingList<TextData>();
        public ListViewForm()
        {
            InitializeComponent();
            ls.Add(new TextData("hi"));
            ls.Add(new TextData("hi"));
            ls.Add(new TextData("hi"));
            ls.Add(new TextData("hi"));
            ls.Add(new TextData("hi"));
            ls.Add(new TextData("hi"));

            listView1.View = View.Details;
            listView1.Columns.Add("Text");
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Delete", null, (s, e) => {
                if (listView1.SelectedItems.Count == 0)
                    return;

                var item = listView1.SelectedItems[0];
                var data = item.Tag as TextData;

                ls.Remove(data);
                listView1.Items.Remove(item);
            });

            listView1.ContextMenuStrip = cms;
            for (int i = 0; i < ls.Count; i++)
            {
                listView1.Items.Add(ls[i].Text);
            }
        }
    }

   public class TextData
    {
        public string Text { get; set; }
        public TextData(string text)
        {
            this.Text = text;
        }
    }
}

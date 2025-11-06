using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form4 : Form
    {
        Panel redPanel, bluePanel;
        Button btnSendBack, btnBringFront;
        public Form4()
        {
             redPanel = new Panel();
             bluePanel = new Panel();

            redPanel = new Panel()
            {
                BackColor=Color.Red,
                Size=new Size(200,200),
                Location=new Point(50,50)
            };
            bluePanel = new Panel()
            {
                BackColor = Color.Blue,
                Size = new Size(200, 200),
                Location = new Point(100, 100)
            };
            btnSendBack = new Button()
            {
                Text = "Send Blue to Back",
                Location=new Point(50,300),
            };
            btnSendBack.Click += (s, e) => bluePanel.SendToBack();

            btnBringFront = new Button()
            {
                Text = "Bring Blue to Front",
                Location = new Point(200, 300),
            };
            btnBringFront.Click += (s, e) => bluePanel.BringToFront();
            Controls.Add(redPanel);
            Controls.Add(bluePanel);
            Controls.Add(btnSendBack);
            Controls.Add(btnBringFront);
        }
    }
}

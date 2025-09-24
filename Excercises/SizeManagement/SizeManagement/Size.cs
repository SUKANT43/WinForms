using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SizeManagement
{
    public partial class GenerateSize : Form
    {
        private Panel sizePanel;
        private List<Button> buttonList;
        private int row = 1, col = 1;
        private int panelName = 1;

        public GenerateSize()
        {
            InitializeComponent();

            buttonList = new List<Button>();

            sizePanel = new Panel();
            Controls.Add(sizePanel);
            sizePanel.Location = new Point(0, 0);
            sizePanel.AutoSize = false;
            sizePanel.Width = 550;
            sizePanel.Height = 400;
            sizePanel.AutoScroll = true;
        }

        private void genertaeSizeButton_Click(object sender, EventArgs e)
        {
            row = int.Parse(rowTextBox.Text);
            col = int.Parse(colTextBox.Text);

            panelName = 1;

            int shapeCol = (sizePanel.Width / col) - 5;
            int shapeRow = (sizePanel.Height / row) - 5;

            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= col; j++)
                {
                    Button shapeButton = new Button();
                    shapeButton.Size = new Size(shapeCol, shapeRow);
                    shapeButton.Text = $"{panelName++}";
                    shapeButton.Location = new Point((j - 1) * shapeCol, (i - 1) * shapeRow);

                    buttonList.Add(shapeButton);
                }
            }
            for (int i = 0; i < buttonList.Count; i++)
            {
                sizePanel.Controls.Add(buttonList[i]);
            }
        }

        protected override void OnResize(EventArgs e)
        {
                base.OnResize(e);

                if (row == 0 || col == 0 || buttonList == null || buttonList.Count == 0)
                    return;

                int buttonWidth = buttonList[0].Width;
                int buttonHeight = buttonList[0].Height;
                int spacing = 5;

                int buttonsPerRow = Math.Max(1, sizePanel.Parent.Width / (buttonWidth + spacing));

                for (int index = 0; index < buttonList.Count; index++)
                {
                if (Width < 550)
                {
                    int x = (index % buttonsPerRow) * (buttonWidth + spacing);
                    int y = (index / buttonsPerRow) * (buttonHeight + spacing);
                    buttonList[index].Location = new Point(x, y);
                    buttonList[index].Text = (index + 1).ToString();
                }
                else
                {
                    int shapeCol = (sizePanel.Width / col) - spacing;
                    int shapeRow = (sizePanel.Height / row) - spacing;

                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            int k = i * col + j;
                            if (k >= buttonList.Count)
                                break;

                            buttonList[k].Size = new Size(shapeCol, shapeRow);
                            buttonList[k].Location = new Point(j * shapeCol, i * shapeRow);
                            buttonList[k].Text = (k + 1).ToString();
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorFormProject
{
    public partial class FormMain : Form
    {
        struct ButtonStruct
        {
            public char Content;
            public bool IsBold;
            public ButtonStruct(char content, bool isBold)
            {
                this.Content = content;
                this.IsBold = isBold;
            }
            public override string ToString()
            {
                return Content.ToString();
            }
        }

        // private char[,] buttons = new char[6, 4];
        private ButtonStruct[,] buttons =
        {
            { new ButtonStruct('%', false), new ButtonStruct(' ', false), new ButtonStruct('C',false), new ButtonStruct(' ',false) },
            { new ButtonStruct('⅟', false), new ButtonStruct(' ', false), new ButtonStruct(' ',false), new ButtonStruct('/',false) },
            { new ButtonStruct('7', true), new ButtonStruct('8', true), new ButtonStruct('9',true), new ButtonStruct('x',false) },
            { new ButtonStruct('4', true), new ButtonStruct('5', true), new ButtonStruct('6',true), new ButtonStruct('-',false) },
            { new ButtonStruct('1', true), new ButtonStruct('2', true), new ButtonStruct('3',true), new ButtonStruct('+',false) },
            { new ButtonStruct('±', false), new ButtonStruct('0', true), new ButtonStruct(',',false), new ButtonStruct('=',false) },
        };

        private RichTextBox resultBox;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MakeResultBox(resultBox);
            MakeButtons(buttons);
        }

        private void MakeResultBox(RichTextBox resultBox)
        {
            resultBox = new RichTextBox();
            resultBox.SelectionAlignment = HorizontalAlignment.Right;
            resultBox.Font = new Font("Segoe UI", 22);
            resultBox.Width = this.Width - 16;
            resultBox.Height = 50;
            resultBox.Top = 20;
            resultBox.ReadOnly = true;
            this.Controls.Add(resultBox);
        }

        private void MakeButtons(ButtonStruct[,] buttons)
        {
            int buttonWidth = 82;
            int buttonHeight = 60;
            int posX = 0;
            int posY = 101;

            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    Button newButton = new Button();
                    newButton.Font = new Font("Segoe UI", 16);
                    // newButton.Text = buttons[i, j].ToString();
                    ButtonStruct bs = buttons[i, j];
                    newButton.Text = bs.ToString();
                    if (bs.IsBold)
                    {
                        newButton.Font = new Font(newButton.Font, FontStyle.Bold);
                    }

                    newButton.Width = buttonWidth;
                    newButton.Height = buttonHeight;
                    newButton.Left = posX;
                    newButton.Top = posY;
                    this.Controls.Add(newButton);
                    posX += buttonWidth;
                }
                posX = 0;
                posY += buttonHeight;
            }
        }
    }
}

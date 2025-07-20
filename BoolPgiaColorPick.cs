using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class BoolPgiaColorPick : Form
    {
        private const int k_buttonWidth = 40;
        private const int k_buttonHeight = 40;

        public Color SelectedColor { get; private set; }

        public BoolPgiaColorPick(List<Color> i_ColorPicks)
        {
            InitializeComponent();
            int currentX = 10;
            int currentY = 10;

            foreach (Color color in i_ColorPicks)
            {
                Button ColorButton = new Button();

                ColorButton.BackColor = color;
                ColorButton.Size = new Size(k_buttonWidth, k_buttonHeight);
                ColorButton.Location = new Point(currentX, currentY);
                ColorButton.Click += ColorPickbutton_Click;
                this.Controls.Add(ColorButton);
                currentX += k_buttonWidth + 5;
                if (currentX > (i_ColorPicks.Count / 2) * (k_buttonWidth + 5))
                {
                    currentX = 10;
                    currentY += k_buttonHeight + 5;
                }
            }
        }

        void ColorPickbutton_Click(object sender, EventArgs e)
        {
            Button ColorButton = sender as Button;

            SelectedColor = ColorButton.BackColor;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BoolPgiaColorPick_Load(object sender, EventArgs e)
        {

        }
    }
}

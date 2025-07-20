using System;
using System.Windows.Forms;

namespace Ex05
{
    public partial class BoolPgiaMenu : Form
    {
        private int m_NumChances = 4;
        private const int  k_MinChances = 4;
        private const int  k_MaxChances = 10;

        public BoolPgiaMenu()
        {
            InitializeComponent();
            buttonNumOfChances.Text = $"Number of chances: {m_NumChances}";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
        }

        private void buttonNumOfChances_Click(object sender, EventArgs e)
        {
            m_NumChances = (m_NumChances < k_MaxChances) ? ++m_NumChances : k_MinChances;
            buttonNumOfChances.Text = $"Number of chances: {m_NumChances}";
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            BoolPgiaGame game = new BoolPgiaGame(m_NumChances);
            game.Show();
            this.Hide();
        }
    }
}

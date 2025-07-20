using Ex02;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class BoolPgiaGame : Form
    {
        private GameLogic m_GameLogic;
        private int m_CurrentRow = 0;
        private const int k_ButtonSize = 40;
        private const int k_Space = 5;
        private const int k_NumberOfResultButtons = 4;
        private const int k_NumberOfGuessButtons = 4;
        private List<List<Button>> m_GuessButtons = new List<List<Button>>();
        private List<Button> m_SubmitButtons = new List<Button>();
        private List<List<Button>> m_ResultButtons = new List<List<Button>>();
        private List<Button> m_SecretButtons = new List<Button>();
        private Color[] m_Colors = { Color.Purple, Color.Red, Color.Green, Color.Cyan, Color.Blue, Color.Yellow, Color.Brown, Color.White };

        public BoolPgiaGame(int i_NumberOfGuesses)
        {
            InitializeComponent();
            m_GameLogic = new GameLogic(i_NumberOfGuesses);
            CreateBoard(i_NumberOfGuesses);
        }

        private void CreateBoard(int i_NumberOfGuesses)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            int width = 300;
            int height = (i_NumberOfGuesses * (k_ButtonSize + k_Space)) + 80;
            this.ClientSize = new Size(width, height);
            for (int i = 0; i < k_NumberOfResultButtons; i++)
            {
                Button buttonSecret = new Button();

                buttonSecret.Size = new Size(k_ButtonSize, k_ButtonSize);
                buttonSecret.Location = new Point(10 + i * (k_ButtonSize + k_Space), 10);
                buttonSecret.BackColor = Color.Black;
                buttonSecret.Enabled = false;
                Controls.Add(buttonSecret);
                m_SecretButtons.Add(buttonSecret);
            }
            for (int row = 0; row < i_NumberOfGuesses; row++)
            {
                List<Button> guessRowButtons = new List<Button>();
                List<Button> resultRowButtons = new List<Button>();

                for (int col = 0; col < k_NumberOfGuessButtons; col++)
                {
                    Button buttonGuess = new Button();

                    buttonGuess.Size = new Size(k_ButtonSize, k_ButtonSize);
                    buttonGuess.Location = new Point(10 + col * (k_ButtonSize + k_Space), 60 
                        + row * (k_ButtonSize + k_Space));
                    buttonGuess.BackColor = Color.Gray;
                    buttonGuess.Enabled = (row == 0);
                    buttonGuess.Click += ButtonGuess_Click;
                    Controls.Add(buttonGuess);
                    guessRowButtons.Add(buttonGuess);
                }
                Button buttonSubmit = new Button();

                buttonSubmit.Text = "→";
                buttonSubmit.Size = new Size(k_ButtonSize, k_ButtonSize);
                buttonSubmit.Location = new Point(10 + 4 * (k_ButtonSize + k_Space), 60 + 
                    row * (k_ButtonSize + k_Space));
                buttonSubmit.Enabled = false;
                buttonSubmit.Click += ButtonSubmit_Click;
                Controls.Add(buttonSubmit);
                m_SubmitButtons.Add(buttonSubmit);
                for (int r = 0; r < k_NumberOfResultButtons; r++)
                {
                    Button buttonResult = new Button();

                    buttonResult.Size = new Size(15, 15);
                    buttonResult.Location = new Point(230 + (r % 2) * 20, 60 + row * (k_ButtonSize + k_Space) + (r / 2) * 20);
                    buttonResult.Enabled = false;
                    buttonResult.BackColor = Color.LightGray;
                    Controls.Add(buttonResult);
                    resultRowButtons.Add(buttonResult);
                }
                m_GuessButtons.Add(guessRowButtons);
                m_ResultButtons.Add(resultRowButtons);
            }
        }

        private void ButtonGuess_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;
            BoolPgiaColorPick colorPicker = new BoolPgiaColorPick(new List<Color>(m_Colors));

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                if (!IsColorAlreadyPicked(colorPicker.SelectedColor))
                {
                    buttonClicked.BackColor = colorPicker.SelectedColor;
                    CheckSubmitEnable();
                }
                else
                {
                    MessageBox.Show("Color already picked!");
                }
            }
        }

        private bool IsColorAlreadyPicked(Color i_Color)
        {
            bool isPicked = false;

            foreach (Button button in m_GuessButtons[m_CurrentRow])
            {
                if (button.BackColor == i_Color)
                {
                    isPicked = true;
                    break;
                }
            }

            return isPicked;
        }

        private void CheckSubmitEnable()
        {
            foreach (Button button in m_GuessButtons[m_CurrentRow])
            {
                if (button.BackColor == Color.Gray)
                {
                    m_SubmitButtons[m_CurrentRow].Enabled = false;

                    return;
                }
            }
            m_SubmitButtons[m_CurrentRow].Enabled = true;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string userGuess = string.Empty;

            foreach (Button button in m_GuessButtons[m_CurrentRow])
            {
                userGuess += (char)('A' + Array.IndexOf(m_Colors, button.BackColor));
            }
            if (!m_GameLogic.IsValidGuess(userGuess))
            {
                MessageBox.Show("Invalid guess!");

                return;
            }
            GameLogic.UserGuess resultSequence = m_GameLogic.AddGuess(userGuess);

            UpdateResultIndicators(resultSequence);
            if (m_GameLogic.IsGameOver)
            {
                RevealSecret();
            }
            else 
            {
                MoveNextRow();
            }
                
        }

        private void UpdateResultIndicators(GameLogic.UserGuess i_Guess)
        {
            int NumOfBlackButtons = i_Guess.RightLettersInRightPosCount;
            int NumOfYellowButtons = i_Guess.RightLettersInWrongPosCount;
            int resultIndex = 0;

            foreach (Button button in m_ResultButtons[m_CurrentRow])
            {
                button.BackColor = Color.LightGray;
            }
            for (int i = 0; i < NumOfBlackButtons; i++)
            {
                m_ResultButtons[m_CurrentRow][resultIndex++].BackColor = Color.Black;
            }
            for (int i = 0; i < NumOfYellowButtons; i++)
            {
                m_ResultButtons[m_CurrentRow][resultIndex++].BackColor = Color.Yellow;
            }
        }

        private void MoveNextRow()
        {
            foreach (Button button in m_GuessButtons[m_CurrentRow])
            {
                button.Enabled = false;
            }
            m_SubmitButtons[m_CurrentRow].Enabled = false;
            m_CurrentRow++;
            if (m_CurrentRow < m_GuessButtons.Count)
            {
                foreach (Button button in m_GuessButtons[m_CurrentRow])
                {
                    button.Enabled = true;
                }
            }
        }

        private void RevealSecret()
        {
            for (int i = 0; i < 4; i++)
            {
                m_SecretButtons[i].BackColor = m_Colors[m_GameLogic.SecretWordValue[i] - 'A'];
            }
            string message;
            
            if (m_GameLogic.IsWin)
            {
                message = string.Format("You won in {0} tries!", m_GameLogic.NumGuessesMade);
            }
            else
            {
                message = "Game over! Out of turns.";
            }
            MessageBox.Show(message);
            DisableBoard();
        }

        private void DisableBoard()
        {
            foreach (List<Button> buttonRow in m_GuessButtons)
            {
                foreach (Button button in buttonRow)
                {
                    button.Enabled = false;
                }
            }
            foreach (Button button in m_SubmitButtons)
            {
                button.Enabled = false;
            }
        }
    }
}

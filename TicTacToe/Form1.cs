using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        bool turn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe is a game for two players, X and O, who take turns making" +
                " the spaces in a 3x3 grid. The player who succeed in placing three of their marks in" +
                " a diagonal, horizontal or vertical row is a winner!\r\nMade by Petar Kirilov", 
                "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }

            turn = !turn;
            button.Enabled = false;
            turnCount++;
            winnerCheck();
        }

        private void winnerCheck()
        {
            bool winner = false;
            //horizontal
            if((A1.Text == A2.Text)&&(A2.Text == A3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner = true;
            }
            //vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner = true;
            }
            //diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                winner = true;
            }

            if (winner)
            {
                disableBtn();
                String win = "";
                if (turn)
                {
                    win = "O";
                    playerTwo.Text = (Int32.Parse(playerTwo.Text) + 1).ToString();
                }
                else
                {
                    win = "X";
                    playerOne.Text = (Int32.Parse(playerOne.Text) + 1).ToString();
                }
                MessageBox.Show(win + " Wins!", "Good job");
                resetGame();
            }else if(turnCount == 9)
            {
                draws.Text = (Int32.Parse(draws.Text) + 1).ToString();
                MessageBox.Show("Draw!", "Good job");
                resetGame();
            }
        }

        private void disableBtn()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button btn = (Button)c;
                    btn.Enabled = false;
                }
                catch
                {

                }
             }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = turn;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button btn = (Button)c;
                    btn.Enabled = true;
                    btn.Text = "";
                }
                catch
                {

                }
            }
        }

        private void resetGame()
        {
            turn = turn;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button btn = (Button)c;
                    btn.Enabled = true;
                    btn.Text = "";
                }
                catch
                {

                }
            }
        }
    }
}

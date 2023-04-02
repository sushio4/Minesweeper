using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    class GameForm : Form
    {
        public GameForm(int lvl)
        {
            //quadratic formula instead of branches UwU
            //lvl 1 => x = 9, lvl 2 => x = 16, lvl 3 => x = 30
            x = (int)(3.5 * lvl * lvl - 3.5 * lvl + 9);
            //lvl 1 => y = 9, lvl 2 => y = 16, lvl 3 => y = 16
            y = (int)(-3.5 * lvl * lvl + 17.5 * lvl - 5);
            //lvl 1 => b = 10, lvl 2 => b = 40, lvl 3 => b = 99
            bombs = (int)(14.5 * lvl * lvl - 13.4 * lvl + 9);

            FormClosed += new FormClosedEventHandler(Exit);

            BackColor = System.Drawing.SystemColors.ControlLight;
            ClientSize = new System.Drawing.Size(x*tileWidth,y*tileWidth + guiSize);
            Name = "GameForm";
            Text = "Minesweeper";
            board = new Tile[x * y];
            Tile.X = x;
            Tile.Y = y;
            Tile.BOMBS = bombs;
            Tile.parent = this;

            //set pos of every tile
            for (int i = 0; i < x * y; i++)
            {
                board[i] = new Tile(i);
                Controls.Add(board[i]);
            }
            discoveredTiles = 0;
            afterFirst = false;
        }

        private void Exit(object o, System.EventArgs e)
        {
            Application.Exit();
        }

        public void DiscoverAll()
        {
            for(int i = 0; i < x*y;i++)
            {
                if(0 == (board[i].value & 0x20))
                    board[i].value |= 0x10; //see Tile.cs for info
                board[i].UpdateText();
            }
        }

        public void Win()
        {
            var answer = MessageBox.Show("You won!\nDo you want to save your time?", "Victory!", MessageBoxButtons.YesNo);
        }

        public void Lose()
        {
            DiscoverAll();
            var answer = MessageBox.Show("You lost!\nDo you want to restart?", "Game over!", MessageBoxButtons.YesNo);
            if(answer == DialogResult.Yes)
            {
                for (int i = 0; i < x * y; i++)
                {
                    Controls.Remove(board[i]);
                    board[i] = new Tile(i);
                    Controls.Add(board[i]);
                }
                discoveredTiles = 0;
                afterFirst = false;
            }
        }

        public void InitBoard(int safePos)
        {
            Random rand = new Random();
            //randomise bombs
            for (int i = 0,p; i < bombs; i++)
            {
                do{
                    p = rand.Next(x * y);
                } while (board[p].value == 0xF || p == safePos);
                board[p].value = 0xF;
            }
            //set other values
            for(int x = 0; x < this.x; x++)
                for(int y = 0; y < this.y; y++)
                {
                    if(board[x+y*this.x].value==0) //if its not bomb
                    {
                        byte adjBombs = 0;
                        //loop through adjacent tiles and increment if there's bomb
                        for (int i = -1; i < 2; i++)
                            for (int j = -1; j < 2; j++)
                                if (x + i >= 0 && x + i < this.x && y + j >= 0 && y + j < this.y
                                    && board[x + i + this.x * (y + j)].value == 0xF)
                                    adjBombs++;

                        board[x + y * this.x].value = adjBombs;
                    }
                    //board[x + y * this.x].value |= 0x10; //just for now
                    board[x + y * this.x].UpdateText();
                }
        }

        public Tile[] board;
        public int discoveredTiles;
        public bool afterFirst;

        public const int tileWidth = 32; // [px]
        public const int guiSize = 0;
        int x, y, bombs;
    }
}

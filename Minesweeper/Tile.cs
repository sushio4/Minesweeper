using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class Tile : Button
    {
        public Tile(int _pos)
        {
            pos = _pos;
            int tWidth = GameForm.tileWidth;
            MouseUp += new MouseEventHandler(OnClick);
            Size = new Size(tWidth, tWidth);
            Location = new Point(tWidth*(pos % X), GameForm.guiSize + tWidth*(pos / X));
            BackColor = SystemColors.ButtonHighlight;
            TabStop = false;
            Font = new Font("consolas", 16);
            TextAlign = ContentAlignment.BottomCenter;
            value = 0;
            UpdateText();
        }

        public void UpdateText()
        {
            if ((value & DISCOVERED) == DISCOVERED)
            {
                BackColor = SystemColors.ScrollBar;
                //FlatStyle = FlatStyle.Flat;
                if ((value & VALUE) == 0xF)
                {
                    ForeColor = Color.Black;
                    Text = "X";
                }
                else if ((value & VALUE) == 0)
                    Text = null;
                else
                {
                    ForeColor = colors[value & VALUE];
                    Text = Convert.ToString(VALUE & value, 10);
                }
            }
            else if ((value & FLAGGED) == FLAGGED)
                Text = "F";
            else
                Text = null;
        }

        public void Flag()
        {
            if((value & DISCOVERED) == 0)
            {
                if ((value & FLAGGED) == 0)
                    value |= FLAGGED;
                else
                    value &= VALUE;
                UpdateText();
            }
        }

        public void MidClick()
        {
            int adjFlags = 0;
            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (pos % X + i >= 0 && pos % X + i < X
                        && pos / X + j >= 0 && pos / X + j < Y
                        && (parent.board[pos + i + j * X].value & FLAGGED) > 0
                        && (parent.board[pos + i + j * X].value & DISCOVERED) == 0)
                        adjFlags++;
            
            if(adjFlags == (value & VALUE))
                for (int i = -1; i < 2; i++)
                    for (int j = -1; j < 2; j++)
                        if (pos % X + i >= 0 && pos % X + i < X
                            && pos / X + j >= 0 && pos / X + j < Y
                            && (parent.board[pos + i + j * X].value & FLAGGED) == 0)
                            parent.board[pos + i + j * X].Discover();
        }

        public void Discover()
        {
            if((value & DISCOVERED)==0)
            {
                if ((value & VALUE) == 0xF)
                    parent.Lose();
                else
                {
                    value |= DISCOVERED;
                    value &= 0xDF; //delete FLAGGED flag
                    if ((value & VALUE) == 0)
                        for (int i = -1; i < 2; i++)
                            for (int j = -1; j < 2; j++)
                                if (pos % X + i >= 0 && pos % X + i < X
                                    && pos / X + j >= 0 && pos / X + j < Y)
                                    parent.board[pos + i + j * X].Discover();
                    parent.discoveredTiles++;
                    UpdateText();
                    if (parent.discoveredTiles == X * Y - BOMBS)
                        parent.Win();
                }
            }
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Flag();

            else if (e.Button == MouseButtons.Left
                && (value & DISCOVERED) == 0 && (value & FLAGGED) == 0)
            {
                if (!parent.afterFirst)
                {
                    parent.InitBoard(pos);
                    parent.afterFirst = true;
                }
                Discover();
            }

            else if (e.Button == MouseButtons.Middle
                && (value & DISCOVERED) > 0)
                MidClick();
        }

        public static int X, Y, BOMBS;
        public static GameForm parent;
        public int pos;
        
        //message to future me:
        //this gets interesting
        // --- fasten your seatbelts senpai ---
        //to get the value of a tile you do value & 0xF
        //becasue only the lower bits are for the value
        //0000 1111
        //value of exactly 0xF means bomb, from 0 to 8 are normal tiles
        //higher bits indicate whether a tile is discovered or flagged
        //0001 0000b = 0x10 for discovered
        //0010 0000b = 0x20 for flagged
        public byte value;
        //I'll just make some constants for convenience
        //remember to AND it
        const byte DISCOVERED = 0x10;
        const byte FLAGGED = 0x20;
        const byte VALUE = 0xF;

        static Color[] colors = new Color[] {
            Color.FromArgb(0x00,0x00,0x00,0x00),
            Color.FromArgb(0xFF,0x20,0x20,0xF0),
            Color.FromArgb(0xFF,0x00,0xA0,0x00),
            Color.FromArgb(0xFF,0xFF,0x00,0x00),
            Color.FromArgb(0xFF,0x00,0x00,0x8B),
            Color.FromArgb(0xFF,0x8B,0x00,0x00),
            Color.FromArgb(0xFF,0x00,0xA0,0xA0),
            Color.FromArgb(0xFF,0x00,0x00,0x00),
            Color.FromArgb(0xFF,0xC0,0xC0,0xC0)
            };
    }
}

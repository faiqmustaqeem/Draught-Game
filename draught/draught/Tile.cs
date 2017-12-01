using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace draught
{
    class Tile
    {
        public Tile(int row, int col)
        {
            this.x = row;
            this.y = col;

        }
        public Piece getOccupantPieceOnThisTile(Piece[,] piece,PictureBox[,] playBoard)
        {
            Piece p=piece[this.x,this.y];
            if (playBoard[this.x, this.y].ImageLocation == "red.png")
            {
                p.side = Side.red;
            }
            else if (playBoard[this.x, this.y].ImageLocation == "Black.png")
            {
                p.side = Side.black;
            }
            else {
                p.side = Side.none;
            }
           
            return p;
        }
        public Piece getOccupantPieceOnTileToJump(Piece[,] piece, PictureBox[,] playBoard)//jis tile k oper say jump karna
        {// hai woh tile return karay
            Piece p = piece[this.x, this.y];
            if (playBoard[this.x, this.y].ImageLocation == "red.png")
            {
                p.side = Side.red;
            }
            else if (playBoard[this.x, this.y].ImageLocation == "Black.png")
            {
                p.side = Side.black;
            }

            return p;
        }
        public bool isOccupied(PictureBox[,] playBoard)
        {
            bool occupy = false;
            if (playBoard[this.x, this.y].ImageLocation == "red.png")
            {
                occupy = true;
            }
            else if (playBoard[this.x, this.y].ImageLocation == "Black.png")
            {
                occupy = true;
            }
            return occupy;
 
        }
        public bool isSelected;
        public int x;
        public int y;

    }
}

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
    enum Side { none,black, red };
    class Piece
    {
        
        public Piece(Tile tile)
        {
            this.tile = tile;
            
        }
        public Tile tile; // position inside the board
        public Side side; // which side the piece is
    }
}

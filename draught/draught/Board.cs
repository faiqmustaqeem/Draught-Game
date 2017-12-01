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
    class Board
    {
        public Tile returnSelectedTile(PictureBox[,] playBoardArray, Tile[,] tile)
        {
            Tile temp = null;
            bool b = false;
            for (int i = 7; i >= 0 && b == false; i--)
            {
                for (int j = 0; j < 8 && b == false; j++)
                {
                    if (playBoardArray[i, j].BackColor == Color.Green && tile[i, j].isSelected == false)
                    {
                        temp = tile[i, j];
                        temp.isSelected = true;
                        b = true;
                        break;
                    }
                }
            }
            return temp;

        }

        public bool isMoveLegal(Piece p, Tile newPosition,Tile[,] tile,PictureBox[,] playBoard,Piece[,] piece,bool turn)
        {
            bool legal = false;
            int x = p.tile.x;
            int y = p.tile.y;
            int newX = newPosition.x;
            int newY = newPosition.y;
            if (x==newX&&y==newY)
            {
                legal = false;
            }
            else if(p.side==Side.black && turn==false)
            {
                if ((x + 1 == newX && y + 1 == newPosition.y) || (x + 1 == newX && y - 1 == newY))
                {// check to move black piece one step forward


                    if ((y -1<=0) && (x+1==newX)&&(y+1==newY)&&(tile[newX,newY].isOccupied(playBoard)==false))
                    {
                        legal = true;
                    }
                    else if ((y -1<=0) && (x+1==newX)&&(y+1==newY)&&(tile[newX,newY].isOccupied(playBoard)==true))
                    {
                        legal = false;
                    }

                    else if ((y + 1 >= 7) && (x + 1 == newX) && (y - 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == false))
                    {
                        legal = true;
                    }
                    else if ((y + 1 >= 7) && (x + 1 == newX) && (y - 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == false))
                    {
                        legal = false;
                    }
                    else if (tile[x + 1, y + 1].isOccupied(playBoard) == false)
                    {
                        //right
                    
                        legal = true;

                    }
                    else if (tile[x + 1, y - 1].isOccupied(playBoard) == false)
                    {
                        //left
                        legal = true;
                    }
                }
                else if ((x + 2 == newX && y + 2 == newY)&&tile[x+2,y+2].isOccupied(playBoard)==false)
                {// check to move black piece jump on red piece forward right

                    if (tile[x + 1, y + 1].isOccupied(playBoard)==true)
                    {
                        Piece pieceieToBeJumped = tile[x + 1,y + 1].getOccupantPieceOnThisTile(piece, playBoard);
                        if (pieceieToBeJumped.side == Side.red)
                        {
                            legal = true;
                            //remove eaten piece
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].InitialImage = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].Image = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].ImageLocation = null;
                            p = null;
                        }
 
                    }

                }
                else if ((x + 2 == newX && y - 2 == newY) && tile[x + 2, y - 2].isOccupied(playBoard) == false)
                {// check to move black piece jump on red piece forward left

                    if (tile[x + 1, y - 1].isOccupied(playBoard))
                    {
                        Piece pieceieToBeJumped = tile[x + 1, y - 1].getOccupantPieceOnThisTile(piece, playBoard);
                        if (pieceieToBeJumped.side == Side.red)
                        {
                            legal = true;
                            //remove eaten piece
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].InitialImage = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].Image = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].ImageLocation = null;
                            p = null;
                        }

                    }

                }

            }
            else if (p.side==Side.red && turn == true)
            {// check to move red piece one step forward
                if ((x-1 == newX && y-1 == newY) || (x - 1 == newX && y + 1 == newY))
                {

                    if ((y - 1 <= 0) && (x - 1 == newX) && (y + 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == false))
                    {
                        legal = true;
                    }
                    else if ((y - 1 <= 0) && (x - 1 == newX) && (y + 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == true))
                    {
                        legal = false;
                    }

                    else if ((y + 1 >= 7) && (x - 1 == newX) && (y - 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == false))
                    {
                        legal = true;
                    }
                    else if ((y + 1 >= 7) && (x - 1 == newX) && (y - 1 == newY) && (tile[newX, newY].isOccupied(playBoard) == true))
                    {
                        legal = false;
                    }
                    else if (tile[x-1,y-1].isOccupied(playBoard)==false)
                    {
                        legal = true;
                    }
                    else if (tile[x - 1, y + 1].isOccupied(playBoard) == false)
                    {
                        legal = true;
                    }
                      
                        
                    
                }

                else if ((x - 2 == newX && y - 2 == newY) && tile[x - 2, y - 2].isOccupied(playBoard) == false)
                {// check to move red piece jump on black piece forward left

                    if (tile[x - 1, y - 1].isOccupied(playBoard))
                    {
                        Piece pieceieToBeJumped = tile[x - 1, y - 1].getOccupantPieceOnThisTile(piece, playBoard);
                        if (pieceieToBeJumped.side == Side.black)
                        {
                            legal = true;
                            //remove eaten piece
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].InitialImage = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].Image = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].ImageLocation = null;
                            p = null;
                        }

                    }

                }
                else if ((x - 2 == newX && y + 2 == newY) && tile[x - 2, y + 2].isOccupied(playBoard) == false)
                {// check to move red piece jump on black piece forward right

                    if (tile[x - 1, y + 1].isOccupied(playBoard))
                    {
                        Piece pieceieToBeJumped = tile[x - 1, y + 1].getOccupantPieceOnThisTile(piece, playBoard);
                        if (pieceieToBeJumped.side == Side.black)
                        {
                            legal = true;
                            //remove eaten piece
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].InitialImage = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].Image = null;
                            playBoard[pieceieToBeJumped.tile.x, pieceieToBeJumped.tile.y].ImageLocation = null;
                            p = null;
                        }

                    }

                }

            }

            return legal;

        }
       


        public bool doMove(Piece pieceToMove, Tile newPosition, PictureBox[,] playBoard, Tile[,] tile, Piece[,] piece,bool turn)
        {
                int x = pieceToMove.tile.x;
                int y = pieceToMove.tile.y;
                int newX = newPosition.x;
                int newY = newPosition.y;
            if (isMoveLegal(pieceToMove, newPosition,tile,playBoard,piece,turn))
            {
                // game logic of movement
                             playBoard[x, y].ImageLocation = null;
                playBoard[x, y].InitialImage = null;
                playBoard[x, y].Image = null;


               if (pieceToMove.side == Side.black)
                {
                    playBoard[newX, newY].ImageLocation = "Black.png";
                    playBoard[newX, newY].SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else if (pieceToMove.side == Side.red)
                {
                    playBoard[newX, newY].ImageLocation = "red.png";
                    playBoard[newX, newY].SizeMode = PictureBoxSizeMode.CenterImage;


                }
                piece[newX, newY].tile = newPosition;
                tile[x, y].isSelected = false;
                tile[newX, newY].isSelected = false;
                turn = !turn;

            }
            else if (tile[x, y].isOccupied(playBoard) == true && tile[newX, newY].isOccupied(playBoard)==true )
            {
                tile[x, y].isSelected = false;
                tile[newX, newY].isSelected = false;
                MessageBox.Show("Illegal Move !");
            }
            else {
                
                playBoard[newX, newY].InitialImage = null;
                playBoard[newX, newY].ImageLocation = null;
                playBoard[newX, newY].Image = null;
                tile[x, y].isSelected = false;
                tile[newX, newY].isSelected = false;
                MessageBox.Show("Illegal Move !");
 
            }
            return turn;
        }
       

    }
}

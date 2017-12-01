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
    public partial class Form1 : Form
    {
        int counter = 0;
        Tile[,] tile = new Tile[8, 8];
        Piece[,] piece =new Piece[8,8];
        Board b = new Board();
        ArrayList selectedPieces = new ArrayList();
        bool turn = false;
        public Form1()
        {
            InitializeComponent();
        }
           PictureBox[,] playBoard = new PictureBox[8,8];
       



           private void Form1_Load(object sender, EventArgs e)
        {
               
            int xLoc = 14, yLoc = 36;

            //For loop to create the board
            int n = 0;
            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col <= 7; col++) 
                {
                    tile[row, col] = new Tile(row,col);
                    //Create and name picture boxes

                    playBoard[row, col] = new PictureBox();

                    playBoard[row, col].Name = "sqrBox" + n.ToString();
                    n++;
                    //Reset xLoc
                    playBoard[row, col].Location = new Point(xLoc, yLoc);
                    xLoc = 14 + 58 * (n % 8);
                    yLoc = 36 + 48 * (n / 8);

                    //Decide if its even or odd

                    playBoard[row, col].BackColor = ((row+col)%2) == 0 ? Color.Tan : Color.Wheat;


                    //Set picture box point, size it and add to the form
                   

                    playBoard[row, col].Size = new Size(58, 54);

                    this.Controls.Add(playBoard[row, col]);
                   
                    playBoard[row, col].BorderStyle = BorderStyle.FixedSingle;
                    playBoard[row, col].Click += new System.EventHandler(this.pictureBox_Click);

                }

            }
            reset();
        }
        private void reset()
        {
            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col <= 7; col++)
                {
                   
                    piece[row, col] = new Piece(tile[row, col]);
                   
                }
            }
            for (int row = 7; row >= 5; row--)
            {
                for (int col = 0; col <= 7; col++)
                {
                  
                    if ((row + col) % 2 == 0)
                    {
                       
                        piece[row,col].side = Side.red;
                        counter++;
                        playBoard[row, col].SizeMode = PictureBoxSizeMode.CenterImage;
                        playBoard[row, col].ImageLocation = "red.png";
                    }
                }
            }

            for (int row = 2; row >= 0; row--)
            {
                for (int col = 0; col <= 7; col++)
                {
                  
                    if ((row + col) % 2 == 0)
                    {
                        
                        piece[row, col].side = Side.black;
                        counter++;
                        playBoard[row, col].SizeMode = PictureBoxSizeMode.CenterImage;
                        playBoard[row, col].ImageLocation = "Black.png";
                    }
                }
            }
        }


        private void resetColoursOfBoard()
        {

            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col <= 7; col++)
                {
                    playBoard[row, col].BackColor = ((row + col) % 2) == 0 ? Color.Tan : Color.Wheat;
                    
                }
            }

          
        }


        int count = 0;
          private void pictureBox_Click(object sender, EventArgs e)
          {
              count++;
              PictureBox myPictureBox = sender as PictureBox;
              myPictureBox.BackColor = Color.Green;

              
              
              Tile temp= b.returnSelectedTile(playBoard,tile);
              if (piece[temp.x,temp.y].side==Side.black && turn == false)// agar turn false ho to black ki baari hai
              {

              }
              selectedPieces.Add(temp);
              if(count%2==0)
              {
                  Tile positionToMove = (Tile)selectedPieces[1];
                  
                  Tile positionfromMove = (Tile)selectedPieces[0];
                 
                  Piece p = positionfromMove.getOccupantPieceOnThisTile(piece,playBoard);
                turn = b.doMove(p,positionToMove,playBoard,tile,piece,turn);
                if (turn)
                {
                    label1.Text = "Red Turn";
                }
                else
                {
                    label1.Text = "Black Turn";
                }
                  resetColoursOfBoard();
                  selectedPieces.Clear();   
    
               }
              
                  

              }
              
             
          }

    }
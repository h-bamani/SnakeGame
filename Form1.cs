using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        //Create a new List of circles that will be the player object and a new circle object that will be the item to eat
        private List<Circle> player = new List<Circle>();
        private Circle item = new Circle();

        public Form1()
        {
            InitializeComponent();

            //Reset the game to its initial settings
            new InitialSettings();

            //Determine the game speed
            timerGame.Interval = 1000 / InitialSettings.snakeSpeed;
            timerGame.Tick += update;
            timerGame.Start();

            //Start a new game
            beginNewGame();
        }

        //Method that will reset the game to its basic settings and create the player object and the item object
        private void beginNewGame()
        {
            lblEnd.Visible = false;

            new InitialSettings();

            player.Clear();
            Circle snakeHead = new Circle();
            snakeHead.x = 10;
            snakeHead.y = 5;
            player.Add(snakeHead);

            lblPoints.Text = InitialSettings.playerScore.ToString();

            //Call the method that creates the item object at the start of a game
            createItem();
        }

        //Method that will create the item object
        private void createItem()
        {
            int maxWidth = pbGameBoard.Size.Width / InitialSettings.width;
            int maxHeight = pbGameBoard.Size.Height / InitialSettings.height;

            Random ran = new Random();
            item = new Circle();
            item.x = ran.Next(0, maxWidth);
            item.y = ran.Next(0, maxHeight);
        }

        private void update(object sender, EventArgs e)
        {
            //Check if the game is over
            if (InitialSettings.GameOver)
            {
                //Check if user presses enter. If yes, begin a new game
                if (KeyboardInput.checkForKeyPress(Keys.Enter))
                {
                    beginNewGame();
                }
            }

            //This set of if statements ensures that user cannot press a direction button while going in the opposite one
            //e.g. user cannot choose to go right while currently moving left
            else
            {
                if (KeyboardInput.checkForKeyPress(Keys.Right) && InitialSettings.playerDirection != direction.Left)
                {
                    InitialSettings.playerDirection = direction.Right;
                }
                else if (KeyboardInput.checkForKeyPress(Keys.Left) && InitialSettings.playerDirection != direction.Right)
                {
                    InitialSettings.playerDirection = direction.Left;
                }
                else if (KeyboardInput.checkForKeyPress(Keys.Down) && InitialSettings.playerDirection != direction.Up)
                {
                    InitialSettings.playerDirection = direction.Down;
                }
                else if (KeyboardInput.checkForKeyPress(Keys.Up) && InitialSettings.playerDirection != direction.Down)
                {
                    InitialSettings.playerDirection = direction.Up;
                }

                //Call the method that will move the player in the direction he pressed
                moveCharacter();
            }

            //Use the Invalidate function to refresh the game board
            pbGameBoard.Invalidate();
        }

        //This method will move the player in the direction he chooses and reposition each circle in the list
        //It will also check for collision between the player and the game borders, the circle item and the body of the snake
        private void moveCharacter()
        {
            for(int i = player.Count - 1; i >= 0; i--)
            {
                //Move the snake's head in the selected direction
                if(i == 0)
                {
                    switch(InitialSettings.playerDirection)
                    {
                        case direction.Right:
                            player[i].x++;
                            break;
                        case direction.Left:
                            player[i].x--;
                            break;
                        case direction.Down:
                            player[i].y++;
                            break;
                        case direction.Up:
                            player[i].y--;
                            break;
                    }

                    //Get the maximum width and height that the player can reach
                    int maxWidth = pbGameBoard.Size.Width / InitialSettings.width;
                    int maxHeight = pbGameBoard.Size.Height / InitialSettings.height;

                    //Check if the player has collided with the game borders
                    if(player[i].x < 0 || player[i].y < 0 || player[i].x >= maxWidth || player[i].y >= maxHeight)
                    {
                        DestroySnake();
                    }

                    //Check if the player has collided with the body of the snake
                    for(int o = 1; o < player.Count; o++)
                    {
                        if(player[i].x == player[o].x && player[i].y == player[o].y)
                        {
                            DestroySnake();
                        }
                    }

                    //Check if the player has collided with the food piece.
                    if(player[0].x == item.x && player[0].y == item.y)
                    {
                        EatItem();
                    }
                }
                //Move the snake's body
                else 
                {
                    player[i].x = player[i - 1].x;
                    player[i].y = player[i - 1].y;
                }
            }
        }

        //This method will draw each circle item on the game screen
        private void pbGameBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics drawing = e.Graphics;

            //Draws a circle of the specified color
            if (!InitialSettings.GameOver)
            {
                Brush playerColor;

                for (int i = 0; i < player.Count; i++)
                {
                    //If the game has just started, it will draw the snake's head
                    if(i == 0)
                    {
                        playerColor = Brushes.Turquoise;
                    }
                    //If during the game, it will draw the body of the snake
                    else
                    {
                        playerColor = Brushes.GreenYellow;
                    }

                    //Using the FillElipse function to draw a circle of the specified color at the specified location
                    drawing.FillEllipse(playerColor, new Rectangle(player[i].x * InitialSettings.width, player[i].y * InitialSettings.height, 
                    InitialSettings.width, InitialSettings.height));

                    drawing.FillEllipse(Brushes.MediumVioletRed, new Rectangle(item.x * InitialSettings.width, item.y * InitialSettings.height, 
                    InitialSettings.width, InitialSettings.height));
                }
            }
            //If the game is over, display the end game message
            else 
            {
                string endGame = "Too bad! You lost\nYour score is: " + InitialSettings.playerScore + "\nPress Enter if you wish to play again";
                lblEnd.Text = endGame;
                lblEnd.Visible = true;
            }
        }

        //Method that checks if the key is being pressed
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyboardInput.changeKeyState(e.KeyCode, true);
        }

        //Method that checks if a key is no longer pressed
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            KeyboardInput.changeKeyState(e.KeyCode, false);
        }

        //Method that ends the game if the player meets the conditions to end the game
        //i.e collides with game borders or snake body
        private void DestroySnake()
        {
            InitialSettings.GameOver = true;
        }

        //Method that will add the circle item to the snake body, expanding the size of the snake
        //It will also increment the player score and create a new circle item
        private void EatItem()
        {
            Circle item = new Circle();
            item.x = player[player.Count - 1].x;
            item.y = player[player.Count - 1].y;

            //Add the circle item to the snake body
            player.Add(item);

            //Increment the player's score
            InitialSettings.playerScore += InitialSettings.pointIncrement;
            lblPoints.Text = InitialSettings.playerScore.ToString();

            //Create a new circle item to eat
            createItem();
        }
    }
}

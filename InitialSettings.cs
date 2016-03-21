using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    //Enum variable that holds the directions in which the player can move
    public enum direction 
    {
        Up,
        Down,
        Left,
        Right
    }
    class InitialSettings
    {
        //Declare all variables along with their gets n sets
        public static int width { get; set; }
        public static int height { get; set; }
        public static int snakeSpeed { get; set; }
        public static int pointIncrement { get; set; }
        public static int playerScore { get; set; }
        public static direction playerDirection { get; set; }
        public static bool GameOver { get; set; }

        //Constructor that holds all the initial values of each settings
        public InitialSettings()
        {
            width = 20;
            height = 20;
            snakeSpeed = 20;
            pointIncrement = 50;
            playerScore = 0;
            playerDirection = direction.Right;
            GameOver = false;
        }
    }
}

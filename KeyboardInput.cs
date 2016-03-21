using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class KeyboardInput
    {
        //Load all keyboard buttons
        private static Hashtable keyList = new Hashtable();

        //Check to see which button the user has pressed
        public static bool checkForKeyPress(Keys key)
        {
            if(keyList[key] == null)
            {
                return false;
            }

            return (bool)keyList[key];
        }

        //Check to see if a key was pressed by the user
        public static void changeKeyState(Keys key, bool state)
        {
            keyList[key] = state;
        }
    }
}
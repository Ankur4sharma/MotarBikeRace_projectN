using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotarBikeRace_project
{
   public class Bike3
    {
        //create the instance of the class 
        Random rd = new Random();

        //create an user define project to pass the value 
        public int stepJump()
        {
            return rd.Next(1, 70);
        }


        //this code is used to get  the value from the bike position to check the accuracy of the system
        public int gameOver(int position)
        {
            if (position > 750)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}

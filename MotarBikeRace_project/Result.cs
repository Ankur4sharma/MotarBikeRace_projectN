using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotarBikeRace_project
{
   public class Result
    {
        //get the post define value 
        public int testResult(String value,int winner,int budget) {
            String []h = value.Split(' ');
            if (Convert.ToInt32(h[2]) == winner)
            {
                return budget + Convert.ToInt32(h[3]);
            }
            else {
                return budget - Convert.ToInt32(h[3]);
            }
        }
    }
}

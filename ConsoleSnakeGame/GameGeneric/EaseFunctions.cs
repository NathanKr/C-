using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGeneric
{
    public class EaseFunctions
    {
        /*
         * I did not invented this , i took it from here https://github.com/SadConsole/SadConsole/blob/master/src/SadConsole/EasingFunctions/Bounce.cs   
         * but i have changed some argument name
         */

        /// <summary>
        /// the result is a value between startingValue and startingValue + targetValueOffest
        /// given time zero -> expect to get startingValue
        /// given time equal to duration-> expect to get startingValue + targetValueOffest
        /// </summary>
        /// <param name="time">current time in time window</param>
        /// <param name="startingValue">start value</param>
        /// <param name="targetValueOffest">current value offset relative to start value</param>
        /// <param name="duration">total animation time window</param>
        /// <returns></returns>
        public static double BounceEaseOut(
            double time, double startingValue,
            double targetValueOffest, double duration)
        {
            if ((time /= duration) < (1 / 2.75))
                return targetValueOffest * (7.5625 * time * time) + startingValue;
            else if (time < (2 / 2.75))
                return targetValueOffest * (7.5625 * (time -= (1.5 / 2.75)) * time + .75) + startingValue;
            else if (time < (2.5 / 2.75))
                return targetValueOffest * (7.5625 * (time -= (2.25 / 2.75)) * time + .9375) + startingValue;
            else
                return targetValueOffest * (7.5625 * (time -= (2.625 / 2.75)) * time + .984375) + startingValue;
        }
    }
}

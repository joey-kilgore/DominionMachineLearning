using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionMachineLearning
{
    public class Attribute
    {
        /// <summary>
        /// weights are listed in the following order
        /// 1. player hand
        /// 2. player deck
        /// 3. player discard
        /// 4. supply piles
        /// 5. VP player
        /// 6. VP opponent
        /// 
        /// each of the first 4 categories contain one number corresponding to the amount of each possible card
        /// these cards are listed in order of lowest cost to highest
        ///     then alphabetical
        ///     
        /// this totals to 66 values
        ///     there are always 16 different cards and therefore
        ///     16-player hand
        ///     16-player deck
        ///     16-player discard
        ///     16-supply piles
        ///     1 -VP player
        ///     1 -VP opponent
        /// </summary>
        double[] weight = new double[66];  

        double value = 0.0;   //value of the attribute

        /// <summary>
        /// calculates the new value of the attribute
        /// this is done by multiplying all input values by their weights,
        ///     and then adding that to the value of the attribute
        /// </summary>
        /// <param name="input"></param>
        public void calcValue(int[] input)
        {
            value = 0.0;

            for(int i=0; i<66; i++)
            {
                value += (weight[i] * input[i]);
            }
        }


        /// <summary>
        /// recalutes the value of the attribute and returns the new value
        /// if the length of the input array does not equal the length of the weight array
        ///     it does not try to recalculate the value of the attribute and sends out and error message
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double getValue(int[] input)
        {
            if(input.Length != weight.Length)
            {
                Console.WriteLine("ERROR: TOO MANY INPUTS FOR THIS ATTRIBUTE");
            }
            else
            {
                calcValue(input);
            }
            return value;
        }
    }
}

//Kendall Nicley
//Cosc 365 Lab 4
//This class is to reduce the content of the file
//Into one value to be returned, should be done both
//Serially and a syncronously

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365_Lab4
{
    //Partial function
    public partial class MapReduce<T>
    {
        //Delegate function for reduce functions
        public delegate T ReduceFunc(T left, T right);

        //Accumulator for return value
        private T accum;

        //Reduce function that will take the given lamda function
        //and pass the accumulator and the given values to the function
        public void Reduce(ReduceFunc rf)
        {
            //if the list is empty return default value
            if (Count == 0)
                accum = default(T);
            else
            {
                //Assign the first value to the accumulator
                accum = lvals[0];
                for (int i = 1; i < Count; i++)
                {
                    //Call the function
                    accum = rf(accum, lvals[i]);
                }
            }
        }

        //The A syncronous function that will run the Reduce function Asyncronoulsly
        public async Task<T> ReduceAsync(ReduceFunc rf)
        {
            return await Task.Run(() => 
            {
                Reduce(rf);
                return accum;
            });
        }
    }
}

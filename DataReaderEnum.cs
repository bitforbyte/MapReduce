//Kendall Nicley
//Lab 4 Cosc 365
//This is to be the enumerator for the DataReader class

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365_Lab4
{
    class DataReaderEnum : IEnumerator
    {
        int initer; //inner iterator
        double[] dvalues; //The copied values

        //Overloaded constructor that will copy the values into the internal data structure
        public DataReaderEnum(ref double[] vals)
        {
            dvalues = vals;
        }

        //Get the current placement
        public object Current 
        {
            get
            {
                //TODO Return the inner iterator?
                return initer;
            }
        }

        //Move to the next element
        public bool MoveNext()
        {
            //increment the inner iterator
            initer++;

            //Return if the inner iterator is larger than the length
            return (initer < dvalues.Length);
        }

        //Reset the inner iterator
        public void Reset()
        {
            //Reset the internal interator to -1
            initer = -1;
        }
    }
}

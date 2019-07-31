//Kendall Nicley
//Cosc 365 Lab 4
//This class is to be the main MapReduce class that
//Will read the data and put into the internal generic list

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365_Lab4
{
    //Class takes a Generic template
    public partial class MapReduce<T>
    {
        //num to hold the number of elements added
        int num;
        List<T> lvals; //List of generic values

        //0 Argument Constructor
        public MapReduce()
        {
            num = 0;
            lvals = new List<T>();
        }


        //Add Items to the list
        public void Add(T item)
        {
            num++;
            lvals.Add(item);
        }

        //Property to get the number of items added to the list
        public int Count
        {
            get
            {
                return num;
            }
        }

        //The Indexer to return the data value and set the data value
        public T this[int index]
        {
            get
            { return lvals[index]; }
            set
            { lvals[index] = value; }
        }
    }
}

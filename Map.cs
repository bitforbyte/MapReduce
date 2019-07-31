//Kendall Nicley
//Cosc 365 Lab 4
//This Class Is to Use the given function
//using parallel for loop to parrallel loop thorugh
//the file saving time

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _365_Lab4
{
    //The partial map reduce function
    public partial class MapReduce<T>
    {
        //Delegate to be passed into Map function
        public delegate T MapFunk(T val);

        //Map function that will loop through the data and do the given function
        public void Map(MapFunk mf)
        {
            //Parallel for to loop through asyncronously
            Parallel.For(0, Count, i => 
            {
                //Run the given function and pass the data
                mf(lvals[i]);
            });
          
            return;
        }

        
    }
        
    
}

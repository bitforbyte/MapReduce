//Kendall Nicley
//Cosc 365 Lab 4
//This Class is to read the data from the given file
//and store into an internal double array

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365_Lab4
{
    class DataReader : IEnumerable
    {
        //Internal data
        double[] vals;
        int arrySize;

        //Overloaded DataReader
        public DataReader(string fileName)
        {
            //Check to see if the file exists
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"The File {fileName} wasn't found");
            }

            //Read from the file
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                //Throw error if file is empty
                if (br.BaseStream.Length == 0)
                {
                    throw new EndOfStreamException($"The File {fileName} is empty");
                }else
                {
                    //Save the position for reset later
                    var temp = br.BaseStream.Position;
                    arrySize = 0; //Intialize the size to 0

                    //*************************************************************************
                    //This gave the size of the file without looping, but the requirements
                    //told us to loop through file.
                    //arrySize = (int) br.BaseStream.Length / 8; //The Number of items in file
                    //*************************************************************************

                    //Try block to read through the file to get size
                    try
                    {
                        //Read the file until Exception is thrown
                        while(true)
                        {
                            br.ReadByte();
                            arrySize++;
                        }
                    }
                    catch(EndOfStreamException)
                    {
                        //Divide size by 8 (since it's 8 bytes each) 
                        arrySize /= 8;

                        //Reset the postion to the beginning of the file
                        br.BaseStream.Position = temp;
                    }
                    catch (Exception ex)
                    {
                        //Display the error
                        Console.WriteLine($"Error:{ex.ToString()}\n Closing!");
                        Environment.Exit(0); //Close due to unkown error
                    }
                    

                    vals = new double[arrySize]; //Assign the array size from # of items in file
                    for(int i = 0; i < arrySize; i++)
                    {
                        //Read in each double from file
                        vals[i] = br.ReadDouble();
                    }
                }
            }
        }

        //Return the enumerator
        public IEnumerator GetEnumerator()
        {
            return vals.GetEnumerator();
        }

        //Count to return the number of elements in array
        public int Count
        {
            get
            {
                return arrySize;
            }
        }

        //Indexer of DataReader file
        public double this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException($"The Index {index} is out of the bounds of the array");
                else
                    return vals[index];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class ImageFile : MyFile
    {
        public override void PrintFile()
        {
            for (int i = 0; i < ScreenColor.GetLength(0); i++)
            {
                for (int j = 0; i < ScreenColor.GetLength(1); j++)
                {
                    Console.WriteLine(ScreenColor[i,j]);
                }
            }
        }
         
        public int[,] ScreenColor { get; set; } 
    }
}

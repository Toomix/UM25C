using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM25C
{
    class Program
    {
        static void Main(string[] args)
        {

            UM25C um25c = new UM25C("COM35")
            {
                LogDataToDataSet = true,
                KeepRowsInDataSets = 300,
            };

            while (true)
            {
                if (um25c.ReadDataDump())
                {
                    Console.Clear();
                    Console.Write(um25c.GetDataDump());
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

    }
}

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
            if (args.Length > 0)
            {
                UM25C um25c = new UM25C(args[0])
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
                    else
                    {
                        Console.WriteLine(um25c.LastError);
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            }
            else
            {
                Console.WriteLine("Please specify COM port in argument.");
            }
        }
        
    }
    
}

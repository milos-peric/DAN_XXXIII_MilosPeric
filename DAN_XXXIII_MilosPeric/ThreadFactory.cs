using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIII_MilosPeric
{
    static class ThreadFactory
    {
        private const string fileByThreadOneName = @"..\..\FileByThread_1.txt";
        private const string fileByThreadTwoTwoName = @"..\..\FileByThread_22.txt";
        private static Stopwatch stwch = new Stopwatch();
        public static void WriteToFileThreadOne()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileByThreadOneName))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (i == j)
                                streamWriter.Write(1);
                            else
                                streamWriter.Write(0);
                        }
                        streamWriter.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Write to file is not possible.");
                Console.WriteLine(e.Message);
            }
        }

        public static void WriteToFileThreadTwoTwo()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileByThreadTwoTwoName))
                {
                    Random random = new Random();
                    for (int i = 0; i < 1000; i++)
                    {
                        streamWriter.WriteLine(random.Next(10000));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Write to file is not possible.");
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadFileMatrix()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileByThreadOneName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't read from {0} file or file doesn't exist.", fileByThreadOneName);
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadFileRandomNumbers()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileByThreadTwoTwoName))
                {
                    string line;
                    long sum = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        int number = Convert.ToInt32(line);
                        if (number % 2 == 1)
                        {
                            sum += number;
                        }
                    }
                    Console.WriteLine("Suma neparnih brojeva je: " + sum);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't read from {0} file or file doesn't exist.", fileByThreadTwoTwoName);
                Console.WriteLine(e.Message);
            }
        }


    }
}

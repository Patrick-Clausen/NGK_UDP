using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using lib;

namespace measurement_server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Dictionary<string,string> commandAndFileDictionary = new Dictionary<string, string>();
            //ADD COMMANDS AND FILE ASSOCIATIONS
            commandAndFileDictionary.Add("L","testfile.txt");

            //Start server
            var server = new ServerRuntime(9000, commandAndFileDictionary);

            //Break at command
            Console.WriteLine("Input Q/q to quit...");
            while (Console.ReadKey().Key != ConsoleKey.Q)
            { }
        }
    }
}

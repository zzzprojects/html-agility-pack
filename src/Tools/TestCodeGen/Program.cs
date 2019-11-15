using System;
using System.IO;
using System.Linq;
using TestCodeGen.Generator;

namespace TestCodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo outDir = null;
            Action<string> paramAction = null;
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-t":
                        paramAction = a =>
                        {
                            outDir = new DirectoryInfo(a);
                        };
                        break;
                    default:
                        paramAction?.Invoke(arg);
                        paramAction = null;
                        break;
                }
            }

            outDir = outDir ?? new DirectoryInfo(Directory.GetCurrentDirectory());

            var generators = new TestCodeGenerator[]
            {
                new HtmlWebTestGenerator { OutDir = outDir },
            };

            Console.WriteLine("Html Agile Pack Test Code Generator");
            Console.WriteLine("");
            for (var i = 0; i < generators.Length; i++)
            {
                Console.WriteLine($"{i}: {generators[i].MenuItemName}");
            }
            Console.WriteLine("");
            Console.Write("Which do you want? Select a menu item by number : ");
            var itemIndex = Console.ReadLine();
            if (!int.TryParse(itemIndex, out var index)
                || index >= generators.Length)
            {
                Console.WriteLine("[ERROR] Your choice was invalid.");
                return;
            }

            try
            {
                foreach (var paramLoader in generators[index].ParamLoaders)
                {
                    Console.Write($"{paramLoader.Message} : ");
                    var input = Console.ReadLine();
                    paramLoader.SetUp(input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[ERROR] {e.Message}");
                return;
            }

            var files = generators[index].GenerateAndSaveToFile().ToList();

            Console.WriteLine("generating test code...");
            Console.WriteLine($"Test code was successfully saved to:");
            foreach (var file in files)
            {
                Console.WriteLine("    " + file.FullName);
            }
        }
    }
}

using System;
using System.IO;

namespace SmartVault.Program
{
  partial class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            WriteEveryThirdFileToFile(args[0]);
            GetAllFileSizes(@"../OutputFiles");
        }

        private static void GetAllFileSizes(string directoryFullName)
        {
            
            DirectoryInfo dir = new DirectoryInfo(directoryFullName);
            FileInfo[] files = dir.GetFiles();
            long size = 0;
            foreach (FileInfo fi in files)
            {
                size += fi.Length;
            }
            //Total file size of all output files
            Console.WriteLine($"Total Size: {size} bytes");
        }

        private static void WriteEveryThirdFileToFile(string accountId)
        {
            DirectoryInfo dir = new DirectoryInfo(@"../OutputFiles");
            int num = 0;
            string lines = "";
            string accountFile = $"TestDoc-User-{accountId}.txt";
            var documentPath = new FileInfo($"{dir.FullName}/{accountFile}").FullName;

            if(!File.Exists(documentPath)){
                Console.WriteLine($"File with account Id {accountId} does not exist.");
                return;
            }

            foreach(var myString in File.ReadAllLines(documentPath)){
                Console.WriteLine(myString);
                if(num%3 == 0){
                    //save every 3rd document
                    lines += $"{myString}{Environment.NewLine}";
                }
                num++;
            }
            num = 0;

            //write lines to new file
            var outFileName = $"Every-3rd-Document-{accountId}.txt";
            var outDocumentPath = new FileInfo($"{dir.FullName}/{outFileName}").FullName;
            File.WriteAllText(outDocumentPath, lines);
        }
    }
}
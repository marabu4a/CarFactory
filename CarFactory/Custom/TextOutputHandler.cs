using System;
using System.IO;
using System.Linq;

namespace CarFactory.Custom
{
    public class TextOutputHandler
    {
        private static string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        private static string pathToLog = Path.Combine(directory,"logs.log");
        public static FileInfo fileInfo;

        private static void FileEx()
        {
            DateTime time = DateTime.Now;
            String newFile = Path.Combine(directory,time.ToString("yyMMddHHmmss") + ".old");
            
            if (!File.Exists(pathToLog))
            {
                File.AppendAllText(pathToLog,"------------Начало-------------" + Environment.NewLine);
            }
            
            fileInfo = new FileInfo(pathToLog);
            try
            {
                if (fileInfo.Length > 100000)
                {
                    if (File.Exists(newFile))
                    {
                        File.Delete(newFile);
                    }
                    else
                    {
                        File.Move(pathToLog, newFile);
                        File.SetCreationTime(newFile, time);
                    }

                    var files = Directory.GetFiles(directory, "*.old", SearchOption.AllDirectories);

                    if (files.Length > 20)
                    {
                        var iter = files.OrderByDescending(f => File.GetCreationTime(f));

                        foreach (string item in iter.Skip(20))
                        {
                            File.Delete(item);
                            Console.WriteLine(item);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка в открытии файла для логирования : {e.Message}");
            }
        }
        
        public static void OutputInFile<T>(T message)
        {
            String outMessage = $"{DateTime.Now} {message.ToString()}";
            Console.WriteLine(outMessage);
        }

        public static void OutputInConsole<T>(T message)
        {
            String outMessage = $"{DateTime.Now}  {message.ToString()}";
            FileEx();
            using StreamWriter sw = File.AppendText(pathToLog);
            sw.WriteLine(outMessage);
        }
    }
}
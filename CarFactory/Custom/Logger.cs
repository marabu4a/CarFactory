using System;
using System.IO;
using System.Linq;

namespace CarFactory.Custom
{
    public class Logger 
    {
        private static string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        private static string pathToLog = Path.Combine(directory,"logs.log");
        public static FileInfo fileInfo;
        
        public delegate void LogHandler(string message);
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
        
        public static void LogInFile(string message)
        {
            String outMessage = $"{DateTime.Now} {message}";
            Console.WriteLine(outMessage);
        }

        public static void LogInConsole(string message)
        {
            String outMessage = $"{DateTime.Now}  {message}";
            FileEx();
            using StreamWriter sw = File.AppendText(pathToLog);
            sw.WriteLine(outMessage);
        }

        // public void log(Action<string> printMessage, string message)
        // {
        //     printMessage(message);
        // }
        // public void Error(T message,LogLevel logLevel = LogLevel.ERROR)
        // {
        //     String outMessage = $"{DateTime.Now} [{logLevel}]  {message.ToString()}";
        //     log(printInLog, outMessage);
        //     log(printInConsole, outMessage);
        // }
        //
        // public void Info(T message,LogLevel logLevel = LogLevel.INFO)
        // {
        //     String outMessage = $"{DateTime.Now} [{logLevel}]  {message.ToString()}";
        //     log(printInLog, outMessage);
        //     log(printInConsole, outMessage);
        // }
        //
        // public void Warn(T message, LogLevel logLevel = LogLevel.WARN)
        // {
        //     String outMessage = $"{DateTime.Now} [{logLevel}]  {message.ToString()}";
        //     log(printInLog, outMessage);
        //     log(printInConsole, outMessage);
        // }
        //
        // public void Debug(T message, LogLevel logLevel = LogLevel.DEBUG)
        // {
        //     String outMessage = $"{DateTime.Now} [{logLevel}]  {message.ToString()}";
        //     log(printInLog, outMessage);
        //     log(printInConsole, outMessage);
        // }
        //
        // public void Fatal(T message, LogLevel logLevel = LogLevel.FATAL)
        // {
        //     String outMessage = $"{DateTime.Now} [{logLevel}]  {message.ToString()}";
        //     log(printInLog, outMessage);
        //     log(printInConsole, outMessage);
        // }

    }
}
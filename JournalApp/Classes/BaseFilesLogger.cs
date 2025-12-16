#pragma warning disable IDE0063
#pragma warning disable IDE0090
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JournalApp.Classes
{

    public class BaseLogger : IDisposable
    {
        private static DateTime CurrentDate = DateTime.MinValue;
        private readonly static ConcurrentDictionary<string, ConcurrentQueue<string>> MessagesOfModule = new ConcurrentDictionary<string, ConcurrentQueue<string>>();
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly Task _logTask;
        private IFileSystem FileSystem;
        private static object lockObject = new object();
        public ConcurrentBag<string> RegisteredModuleNames = new ConcurrentBag<string>();

        public BaseLogger(IFileSystem fileSystem)
        {
            if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
            FileSystem = fileSystem;
            _logTask = Task.Run(WriteMessagesSync);
        }

        private string GetLogFileName(string ModuleName, DateTime ShiftDate)
        {
            var path = GetPath(ModuleName);

            var filename = FileSystem.PathCombine(path, $"{ModuleName}_{ShiftDate:yyyyMMdd}.log");
            return filename;
        }

        private string GetPath(string ModuleName)
        {
            var path = FileSystem.PathCombine(FileSystem.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location ?? ".") ?? ".", "Logs", ModuleName);

            if (!path.EndsWith('\\')) path += '\\';
            FileSystem.CreateDirectory(path);
            return path;
        }

        private static DateTime GetCurrentShiftDate()
        {
            var date = DateTime.Now.Date;
            if (DateTime.Now.TimeOfDay < new TimeSpan(8, 0, 0))
            {
                date = date.AddDays(-1);
            }
            return date;
        }
        private void ChangeDate()
        {
            try
            {
                var date = GetCurrentShiftDate();
                if (date != CurrentDate)
                {
                    CurrentDate = date;
                }
            }
            catch (Exception ex) { AddMessage("Logger", $"Ошибка изменения даты:{ex.Message} {ex.StackTrace}"); }
        }

        public void AddMessage(string Module, string Message)
        {
            try
            {
                ChangeDate();
                StringBuilder sb = new StringBuilder();

                sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH\\:mm\\:ss.fff    "));

                sb.Append(Message);
                var msg = sb.ToString();
                lock (MessagesOfModule)
                {
                    if (!MessagesOfModule.ContainsKey(Module))
                    {
                        MessagesOfModule.TryAdd(Module, new ConcurrentQueue<string>());
                    }
                    MessagesOfModule[Module].Enqueue(msg);
                }
            }
            catch (Exception ex) { AddMessage("Logger", $"Ошибка:{ex.Message} {ex.StackTrace}"); }

        }

        private void WriteMessagesSync()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                foreach (var key in MessagesOfModule.Keys)
                {
                    if (MessagesOfModule[key].Count > 0)
                        WriteBuffer(key);
                }
                Task.Delay(100).Wait();
            }

        }

        private void WriteBuffer(string ModuleName)
        {
            try
            {
                lock (lockObject)
                {
                    using (var File = FileSystem.GetStreamWriter(GetLogFileName(ModuleName, CurrentDate), true))
                    {
                        while (MessagesOfModule[ModuleName].TryDequeue(out string? text))
                        {
                            File.WriteLine(text ?? "");
                        }
                        File.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                MessagesOfModule[ModuleName].Clear();
            }


        }

        private void StopLog()
        {
            _cancellationTokenSource.Cancel();
            _logTask.Wait();
        }

        public void Dispose()
        {
            StopLog();
            GC.SuppressFinalize(this);
        }
               
        public void Flush(string ModuleName)
        {
            if (MessagesOfModule.ContainsKey(ModuleName) && MessagesOfModule[ModuleName].Count > 0)
                WriteBuffer(ModuleName);
        }

        public List<(string ModuleName, string LogPath, string LastLogFile)> GetRegisteredModules()
        {
            return RegisteredModuleNames.Select(mn => (mn, GetPath(mn), GetLogFileName(mn, CurrentDate))).ToList();
        }

        public void RegisterModule(string ModuleName)
        {
            if (!RegisteredModuleNames.Contains(ModuleName))
                RegisteredModuleNames.Add(ModuleName);
        }

        public string GetLogFileOfModule(string ModuleName)
        {
            return GetLogFileName(ModuleName, CurrentDate);
        }
    }

    public interface IFileSystem
    {
        StreamWriter GetStreamWriter(string path, bool append);
        StreamReader GetStreamReader(string path);
        DirectoryInfo CreateDirectory(string path);
        string[] GetFiles(string path);
        void DeleteFile(string path);
        void DeleteDirectory(string path, bool recursive);
        bool IsFileExists(string path);
        bool IsDirectoryExists(string path);
        string? GetDirectoryName(string path);
        string PathCombine(params string[] parts);
    }

    public class FileSystem : IFileSystem
    {
        public DirectoryInfo CreateDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }

        public void DeleteDirectory(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string? GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        public StreamReader GetStreamReader(string path)
        {
            return new StreamReader(path);
        }

        public StreamWriter GetStreamWriter(string path, bool append)
        {
            return new StreamWriter(path, append);
        }

        public bool IsDirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool IsFileExists(string path)
        {
            return File.Exists(path);
        }

        public string PathCombine(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}

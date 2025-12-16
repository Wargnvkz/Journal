using JournalApp.Classes;

namespace JournalApp
{
    internal static class Program
    {
        static FileSystem fileSystem = new FileSystem();
        static BaseLogger appLogger = new BaseLogger(fileSystem);
        static string AppLogSectionName = "Main";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            Microsoft.Win32.SystemEvents.SessionEnding += SystemEvents_SessionEnding;
            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.Run(new LoginForm());
        }

        private static void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            appLogger.AddMessage(AppLogSectionName, $"Изменение режима питания на {e.Mode}");
        }

        private static void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            appLogger.AddMessage(AppLogSectionName, $"Выход из системы: {e.Reason}");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var errMsg = "Необработанное исключение.";
            string? errReason;
            string? errStackTrace;
            if (e.ExceptionObject is Exception ex)
            {
                errReason = ex.Message;
                errStackTrace = ex.StackTrace;
                appLogger.AddMessage(AppLogSectionName, $"{errMsg} .NET {errReason} {errStackTrace}");
            }
            else
            {
                errReason = e.ExceptionObject.ToString();
                appLogger.AddMessage(AppLogSectionName, $"{errMsg} Unsafe {errReason}");
            }
            MessageBox.Show(errReason ?? "", "Ошибка  в программе");
        }

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            appLogger.AddMessage(AppLogSectionName, $"Процесс завершен");
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            appLogger.AddMessage(AppLogSectionName, $"Ошибка при запуске программы. {e.Exception.Message} {e.Exception.StackTrace}");
            MessageBox.Show(e.Exception.Message, "Ошибка  в программе");
        }
    }
}
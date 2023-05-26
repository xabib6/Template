using Microsoft.Win32;
using NLog;
using System.Diagnostics;
using System.IO;

namespace Template.MVVM.Models
{
    public class Logger
    {
        private NLog.Logger _logger = LogManager.GetLogger("Common");
        private const string _backupFolderValueName = "LogFolder";
        private const string _programmRegistryKey = "ProductionUtility";
        private static object locker = new();
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            LogManager.Configuration.Variables["TargetFolder"] = GetRegistryValue(_backupFolderValueName) ?? CurrentFolder ?? "";
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }
        private static Logger? instance;

        internal static string CurrentFolder
        {
            get
            {
                StackFrame callStack = new(0, true);
                var currentFileName = callStack.GetFileName();
                return Path.GetDirectoryName(currentFileName) ?? "";
            }
        }
        private static string? GetRegistryValue(string valueKeyName)
        {
            var currentProgramKey = Registry.CurrentUser.OpenSubKey(_programmRegistryKey);
            if (currentProgramKey == null)
            {
                return null;
            }
            else
            {
                var value = (currentProgramKey.GetValue(valueKeyName) as string);
                currentProgramKey.Close();
                return value;
            }
        }

        public void Log(string message, LogLevel? logLevel = null, bool enableLogging = true)
        {
            if (enableLogging)
            {
                if (logLevel == null)
                {
                    logLevel = LogLevel.Trace;
                }
                _logger.Log(logLevel, message);
            }
        }
        public void Log(params object[] parameters)
        {
            foreach (var parameter in parameters)
            {
                _logger.Log(LogLevel.Trace, $"{parameter}");
            }
        }
    }
}

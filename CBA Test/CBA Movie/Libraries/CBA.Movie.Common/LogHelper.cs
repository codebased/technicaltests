//-----------------------------------------------------------------------
// <copyright file="LogHelper.cs" company="CBA Pty. Ltd.">
//     Copyright (c) CBA. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CBA.Movie.Common
{
    using System;
    using System.Security.Principal;
    using NLog;
    using NLog.Internal;

    /// <summary>
    /// Log Helper class
    /// <remarks>http://www.thedavejay.com/2012/04/custom-logging-handler-for-nlog.html</remarks>
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// Loghelper object.
        /// </summary>
        public static LogHelper CurrentHelper = new LogHelper();

        [Flags]
        public enum LogType
        {
            Error = 0x01,
            CriticalError = 0x02,
            Warning = 0x04,
            Info = 0x08,
            Debug = 0x10,
            Trace = 0x20
        }

        public void Log(string message, LogType logType, Exception ex = null, Type currentType = null)
        {
            Logger logger = (currentType == null)
                                ? LogManager.GetCurrentClassLogger()
                                : LogManager.GetLogger(currentType.FullName);

            Action<string> log = null;
            Action<string, Exception> exLog = null;

            foreach (LogType flag in Enum.GetValues(typeof(LogType)))
            {

                LogType logLevel = (flag & logType);
                LogLevel level = LogLevel.Off;
                switch (logLevel)
                {
                    case LogType.Warning:
                        level = LogLevel.Warn;
                        break;
                    case LogType.CriticalError:
                        level = LogLevel.Fatal;
                        break;
                    case LogType.Error:
                        level = LogLevel.Error;
                        break;
                    case LogType.Info:
                        level = LogLevel.Info;
                        break;
                    case LogType.Trace:
                        level = LogLevel.Trace;
                        break;
                    case LogType.Debug:
                        level = LogLevel.Debug;
                        break;
                    default:
                        continue;
                }

                DoLog(logger, message, level, ex, currentType);
            }
        }

        private static void DoLog(Logger logger, string message, LogLevel level, Exception ex = null, Type type = null)
        {
            LogEventInfo info = new LogEventInfo(level,
                                                ((type == null) ? typeof(LogManager).FullName : type.FullName),
                                                null,
                                                message, null, ex);

            info.Properties["ApplicationName"] = "CBA.Movie";
            info.Properties["Host"] = System.Environment.MachineName;
            info.Properties["Type"] = (ex == null) ? level.ToString() : ex.GetType().FullName;
            info.Properties["CurrentUser"] = WindowsIdentity.GetCurrent().Name;
            info.Properties["Source"] = ex == null ? level.ToString() : ex.Source;

            string error = ex == null ? message : ex.ToString();
            string stackTrace = ex == null ? level.ToString() : ex.StackTrace;

            info.Properties["Error"] =
                string.Format(
                    @"<error host=""{0}"" type=""{1}"" message=""{2}"" source=""{3}"" detail=""{4}"" ><serverVariables>
                        <item name=""SERVICE_NAME""><value string=""{5}""/></item>               
                        <item name=""LOGON_USER""><value string=""{6}""/></item>
                        </serverVariables></error>",
                    System.Environment.MachineName,
                    info.Properties["Type"],
                    System.Security.SecurityElement.Escape(message),
                     info.Properties["Source"],
                    System.Security.SecurityElement.Escape(error),
                    "ServiceName",
                    info.Properties["CurrentUser"]);



            logger.Log(info);

        }

        private Logger GetLoggerFromType(Type currentType)
        {
            return (currentType == null)
                               ? LogManager.GetCurrentClassLogger()
                               : LogManager.GetLogger(currentType.FullName);
        }

    }

}

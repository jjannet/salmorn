using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public enum LOG_TYPE { NONE = 0, INFORMATION = 1, ERROR = 2, WARNING = 3, SQL = 4, START = 5, END = 6 };
public enum LOG_POSITION { VIEW = 0, AO = 1, BO = 2, DAO = 3, DATABASE = 4, COMMON = 5, PI = 6, AUTHENTICATION = 7 }
public static class JLog
{
    #region Private Variables

    private static string DELIMITERS = ConfigurationManager.AppSettings["logDelimeter"];
    private static string LOG_PATH = ConfigurationManager.AppSettings["logPath"];
    private static string LOG_FILE_NAME = ConfigurationManager.AppSettings["logFileName"];

    private static string LOG_FILE_PATH;

    public static bool IS_READLY { get; set; }

    #endregion


    #region Setting Log Variables

    public static void settingLogVariables(string delimiters, string logPath, string logFileName)
    {
        DELIMITERS = delimiters;
        LOG_PATH = logPath;
        LOG_FILE_NAME = logFileName;
        createLogFile();
    }

    public static string getLogFileName()
    {
        return LOG_FILE_NAME;
    }

    public static string getLogPath()
    {
        return LOG_PATH;
    }

    public static string getDelomiter()
    {
        return DELIMITERS;
    }

    #endregion


    #region Create File/Folder

    private static void createLogFile()
    {
        try
        {
            if (generateLogFile())
            {
                IS_READLY = true;
            }
            else
                IS_READLY = false;
        }
        catch
        {
            IS_READLY = false;
        }
    }

    private static bool generateLogFile()
    {
        try
        {
            bool isPass = false;

            isPass = generateLogFileName();

            if (isPass)
                isPass = generateFolder();

            if (isPass)
                isPass = generateFile();

            return isPass;
        }
        catch
        {
            return false;
        }
    }

    private static bool generateLogFileName()
    {
        try
        {
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
            LOG_FILE_NAME = LOG_FILE_NAME + DateTime.Now.ToString("yyyy-MM-dd", cultureinfo) + ".log";
            LOG_FILE_PATH = LOG_PATH + "\\" + LOG_FILE_NAME;

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool generateFolder()
    {
        try
        {
            if (!Directory.Exists(LOG_PATH))
            {
                Directory.CreateDirectory(LOG_PATH);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool generateFile()
    {
        try
        {
            string logFilePath = LOG_FILE_PATH;
            if (!File.Exists(logFilePath))
            {
                var myFile = File.Create(logFilePath);
                myFile.Close();
            }

            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    #endregion


    #region Write Log

    public static void write(LOG_TYPE TYPE, LOG_POSITION LOG_POSITION, object CLASS, string currentMethod, Exception exception)
    {
        try
        {
            StringBuilder logMessage = new StringBuilder();
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");

            logMessage.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cultureinfo));
            logMessage.Append(DELIMITERS);
            logMessage.Append(TYPE.ToString());
            logMessage.Append(DELIMITERS);
            logMessage.Append(LOG_POSITION.ToString());
            logMessage.Append(DELIMITERS);
            logMessage.Append(CLASS.GetType().Name);
            logMessage.Append(DELIMITERS);
            logMessage.Append(currentMethod);
            logMessage.Append(DELIMITERS);
            logMessage.Append(_createExceptionString(exception));

            if (string.IsNullOrEmpty(LOG_FILE_PATH)) createLogFile();

            File.AppendAllText(LOG_FILE_PATH, logMessage.ToString() + Environment.NewLine);
        }
        catch
        {

        }
    }

    public static void write(LOG_TYPE TYPE, LOG_POSITION LOG_POSITION, object CLASS, string currentMethod, string exceptionMessage)
    {
        try
        {
            StringBuilder logMessage = new StringBuilder();
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");

            logMessage.Append(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cultureinfo));
            logMessage.Append(DELIMITERS);
            logMessage.Append(TYPE.ToString());
            logMessage.Append(DELIMITERS);
            logMessage.Append(LOG_POSITION.ToString());
            logMessage.Append(DELIMITERS);
            logMessage.Append(CLASS.GetType().Name);
            logMessage.Append(DELIMITERS);
            logMessage.Append(currentMethod);
            logMessage.Append(DELIMITERS);
            logMessage.Append(exceptionMessage);

            if (string.IsNullOrEmpty(LOG_FILE_PATH)) createLogFile();

            File.AppendAllText(LOG_FILE_PATH, logMessage.ToString() + Environment.NewLine);
        }
        catch
        {

        }
    }
    public static string _createExceptionString(Exception e)
    {
        StringBuilder sb = new StringBuilder();
        _createExceptionString(sb, e, string.Empty);

        return sb.ToString();
    }

    private static void _createExceptionString(StringBuilder sb, Exception e, string indent)
    {
        if (indent == null)
        {
            indent = string.Empty;
        }
        else if (indent.Length > 0)
        {
            sb.AppendFormat("{0}Inner ", indent);
        }

        sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, e.GetType().FullName);
        sb.AppendFormat("\n{0}Message: {1}", indent, e.Message);
        sb.AppendFormat("\n{0}Source: {1}", indent, e.Source);
        sb.AppendFormat("\n{0}Stacktrace: {1}", indent, e.StackTrace);

        if (e.InnerException != null)
        {
            sb.Append("\n");
            _createExceptionString(sb, e.InnerException, indent + "  ");
        }
    }

    #endregion

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetCurrentMethod()
    {
        StackTrace st = new StackTrace();
        StackFrame sf = st.GetFrame(1);

        return sf.GetMethod().Name;
    }


}
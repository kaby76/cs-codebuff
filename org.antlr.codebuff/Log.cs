using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;

namespace org.antlr.codebuff
{
    public class LogStrategy : DefaultErrorStrategy
    {
        public override void ReportError(Parser recognizer, RecognitionException e)
        {
            if (e != null && e.Message != null) Log.WriteLine(e.Message);
            if (e != null && e.InnerException != null && e.InnerException.Message != null) Log.WriteLine(e.InnerException.Message);
            base.ReportError(recognizer, e);
        }
    }

    public class Log
    {
        static StringBuilder _sb = new StringBuilder();

        public static void Reset()
        {
            _sb = new StringBuilder();
        }

        public static void WriteLine(string s = "")
        {
            _sb.AppendLine(s);
        }

        public static void AppendLine(string s = "")
        {
            _sb.AppendLine(s);
        }

        public static void Append(string s)
        {
            _sb.Append(s);
        }

        public static void Write(string s)
        {
            _sb.Append(s);
        }

        public static void Write(string format, params object[] arg)
        {
            var result = String.Format(format, arg);
            _sb.AppendLine(result);
        }

        public static string Message()
        {
            return _sb.ToString();
        }
    }
}

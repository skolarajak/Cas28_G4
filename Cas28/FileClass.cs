using System;
using System.IO;

namespace Cas28
{
    class FileClass
    {
        ///<summary>
        ///Write a log <paramref name="message"/> to a specified <paramref name="file"/>.
        ///</summary>
        ///<param name="file">String. File to which to log a message.</param>
        ///<param name="message">String. Message to log.</param>
        static public void Log(string FileName, string LogMessage)
        {
            // Write a log file to the specified location, if it exists, append text to the end
            using (StreamWriter file = new StreamWriter(FileName, true))
            {
                file.WriteLine("**********");
                // Log the current date and time and timezone offset
                file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss K"));
                file.WriteLine();
                file.WriteLine(LogMessage);
                file.WriteLine();
                file.WriteLine("**********");
            }
        }
    }
}
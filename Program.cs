using System;
using System.IO;

public class FileReader
{
    static void Main()
    {
        string fileWrite = @".\Simeon.txt";
        string fileRead = @".\Tanya.txt";
        
        var oStream = new FileStream(fileWrite, FileMode.Append, FileAccess.Write, FileShare.Read);
        var iStream = new FileStream(fileRead, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        var writer = new System.IO.StreamWriter(oStream);
        var reader = new System.IO.StreamReader(iStream);

        int lineNumber = 1;
        string line;

        string text = "Simeon <3 Tanya";

        while ((line = reader.ReadLine()) != null)
        {

            if (lineNumber == 2)
            {
                writer.WriteLine(text);
                line = text;
            }
            else
            {
                writer.WriteLine(line);
            }

        Console.WriteLine("Line {0}: {1}", lineNumber, line);
        lineNumber++;
        }

        reader.Close();
        writer.Close();
        }  
    }



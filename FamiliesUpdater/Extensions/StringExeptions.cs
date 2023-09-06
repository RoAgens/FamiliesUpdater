using System.Collections.Generic;
using System.IO;

namespace FamiliesUpdater.Exeptions
{
    public static class StringExeptions
    {
        public static bool GetBool(this string boolean)
                             => boolean == "true" ? true : false;

        public static string GetRevitFileVersion(this string filePath)
        {
            string content = null;

            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                return null;
            }

            string codingVersion1 = "\0F\0o\0r\0m\0a\0t\0:";
            string codingVersion2 = "\0R\0e\0v\0i\0t\0 \0B\0u\0i\0l\0d\0:";

            string extractedWord = "";
            int index = content.IndexOf(codingVersion1);

            if (index != -1)
            {
                extractedWord = content.Substring(index + 16, 8);
            }
            else
            {
                index = content.IndexOf(codingVersion2);
                extractedWord = content.Substring(index + 57, 8);
            }

            return extractedWord.Replace("\0", "");
        }

        public static List<string> GetFolderFiles(this string folderPath, bool isFromSubFolders, params string[] exections)
        {
            List<string> files = new List<string>();

            foreach(string exe in exections)
            {
                files.AddRange(isFromSubFolders ? Directory.GetFiles(folderPath, $"*.{exe}", SearchOption.AllDirectories) :
                                                  Directory.GetFiles(folderPath, $"*.{exe}", SearchOption.TopDirectoryOnly));

            }

            return files;
        }
    }
}

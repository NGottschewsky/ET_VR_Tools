using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EyeClops.Internals;
using UnityEngine;

namespace EyeClops.DataLayer
{
    public static class FileIdentifierGenerator
    {
        public static void GenerateIdentifierAndFileEndingMap(string folderPath,
            out Dictionary<string, List<string>> fileIdAndTypeMap)
        {
            fileIdAndTypeMap = new Dictionary<string, List<string>>();
            string[] directories = Directory.GetDirectories(folderPath);
            List<Tuple<string, string>> allPrefixAndFileType = new List<Tuple<string, string>>();
            foreach (string subDirectory in directories)
            {
                if (FolderStructure.CheckOfLegalDirectory(subDirectory))
                {
                    ProcessDirectory(subDirectory, allPrefixAndFileType);
                }
            }

            //Condensate the file list
            foreach (var tuple in allPrefixAndFileType.Distinct().ToList())
            {
                if (!fileIdAndTypeMap.ContainsKey(tuple.Item1))
                    fileIdAndTypeMap.Add(tuple.Item1, new List<string> {tuple.Item2});
                else
                    fileIdAndTypeMap[tuple.Item1].Add(tuple.Item2);
            }
        }

        private static void ProcessDirectory(string targetDirectory, List<Tuple<string, string>> allPrefixAndFileType)
        {
            string[] targetFiles = Directory.GetFiles(targetDirectory);
            foreach (string targetFile in targetFiles)
                ProcessFile(targetFile, allPrefixAndFileType);

            string[] subDirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subDirectory in subDirectoryEntries)
                ProcessDirectory(subDirectory, allPrefixAndFileType);
        }

        private static void ProcessFile(string targetFile, List<Tuple<string, string>> allPrefixAndFileType)
        {
            //TODO: check maybe I have to subtract 1 from this Index
            //Extract fileEnding
            string fileEnding = targetFile.Substring(targetFile.LastIndexOf(FileAdditions.FileNameAndTypSeparator));
            //Extract fileSuffix
            string fileName = targetFile.Substring(targetFile.LastIndexOf(Path.DirectorySeparatorChar) + 1,
                targetFile.LastIndexOf(FileAdditions.FileNameAndTypSeparator));
            string prefix = fileName.Substring(0, fileName.LastIndexOf(FileAdditions.FilePrefixAndSuffixSeparator));
            FolderStructure.CheckOfLegalFileSuffix(fileName.Substring(fileName.LastIndexOf(FileAdditions.FilePrefixAndSuffixSeparator)));

            Debug.LogFormat("Adding as possible File: from {0} as a typ {1}", prefix, fileEnding);
            allPrefixAndFileType.Add(new Tuple<string, string>(prefix, fileEnding));
        }
    }
}
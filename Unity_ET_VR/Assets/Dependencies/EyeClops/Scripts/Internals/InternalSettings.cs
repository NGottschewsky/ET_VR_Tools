using System.IO;
using UnityEngine;

namespace EyeClops.Internals
{
    
    //TODO: Rename This to utilities 
    public enum TimeStampType
    {
        FrameCount,
        RealTime,
        TobiiTimeStamp,
        TobiiFrameSequence
    }

    public enum StatisticalDataType
    {
        Mean,
        StandardDeviation
    }

    public enum EyeType
    {
        LeftEye,
        RightEye,
        CombinedEye
    }

    public static class FileEndings
    {
        public const string Csv = ".csv";
        public const string Binary = ".dat";

        public static bool IsValidClassEnding(string possibleClassFile)
        {
            return Csv.Equals(possibleClassFile) || Binary.Equals(possibleClassFile);
        }
    }

    public static class FileAdditions
    {
        public const char FileNameAndTypSeparator = '.';
        public const char FilePrefixAndSuffixSeparator = '_';
    }

    public static class FolderStructure
    {
        public const string Validation = "Validation";
        public const string GazeValidation = "GazeValidation";
        public const string EyeTrackingData = "EyeTrackingData";
        public const string CsvDirectory = "Csv";
        public const string BinaryDirectory = "Binary";

        public static bool CheckOfLegalDirectory(string subDirectory)
        {
            var dirName = subDirectory.Substring(subDirectory.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            return CsvDirectory.Equals(dirName) || BinaryDirectory.Equals(dirName);
        }

        public static bool CheckOfLegalFileSuffix(string fileSuffix)
        {
            //TODO check of functionality
            Debug.LogFormat("Check for file Suffix: {0} and it is legal: {1}", fileSuffix,
                Validation.Equals(fileSuffix) || GazeValidation.Equals(fileSuffix) ||
                EyeTrackingData.Equals(fileSuffix));
            return Validation.Equals(fileSuffix) || GazeValidation.Equals(fileSuffix) ||
                   EyeTrackingData.Equals(fileSuffix);
        }
    }
}
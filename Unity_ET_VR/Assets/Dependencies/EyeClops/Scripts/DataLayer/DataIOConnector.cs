using System.Collections.Generic;
using System.IO;
using EyeClops.DataLayer.Mapper;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.Internals;
using UnityEngine;

namespace EyeClops.DataLayer
{
    public static class DataIOConnector
    {

        public static void SaveAllDataInCsv(
            List<EyeClopsValidationData> validationData,
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> trailDictionary,
            List<EyeClopsData> eyeTrackerData, string fileAddress, string fileNamePrefix)
        {
            SaveValidationDataInCsv(validationData, fileAddress, fileNamePrefix);
            SaveGazeValidationDataInCsv(trailDictionary, fileAddress, fileNamePrefix);
            SaveEyeTrackingDataInCsv(eyeTrackerData, fileAddress, fileNamePrefix);
        }

        public static void SaveAllDataInBinary(
            List<EyeClopsValidationData> validationData,
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> trailDictionary,
            List<EyeClopsData> eyeTrackerData, string fileAddress, string fileNamePrefix)
        {
            SaveValidationDataInBinary(validationData, fileAddress, fileNamePrefix);
            SaveGazeValidationDataInBinary(trailDictionary, fileAddress, fileNamePrefix);
            SaveEyeTrackingDataInBinary(eyeTrackerData, fileAddress, fileNamePrefix);
        }


        public static void SaveValidationDataInCsv(List<EyeClopsValidationData> validationData, string fileAddress,
            string fileNamePrefix)
        {
            CsvDeSerializer.WriteCSVFile(DataMapper.SerializeSingleEyeTrackingStringValidationData(validationData),
                fileAddress + CsvDirectoryValidationPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.Validation, FileEndings.Csv);
        }


        //(De)Serialization from Csv Files
        public static void SaveGazeValidationDataInCsv(
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> trailDictionary, string fileAddress,
            string fileNamePrefix)
        {
            CsvDeSerializer.WriteCSVFile(DataMapper.SerializeGazeValidationData(trailDictionary),
                fileAddress + CsvDirectoryGazeValidationPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.GazeValidation, FileEndings.Csv);
        }

        public static void SaveEyeTrackingDataInCsv(List<EyeClopsData> eyeTrackerData, string fileAddress,
            string fileNamePrefix)
        {
            CsvDeSerializer.WriteCSVFile(DataMapper.SerializeEyeTrackingData(eyeTrackerData),
                fileAddress + CsvDirectoryEyeTrackingDataPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.EyeTrackingData,
                FileEndings.Csv);
        }


        public static void ReadValidationDataFromCsv(string filePath, string fileNamePrefix,
            ref List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            DataMapper.DeSerializeSingleEyeTrackingStringValidationData(
                GenerateCsvFile(filePath + CsvDirectoryValidationPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator+ FolderStructure.Validation +
                                FileEndings.Csv),
                ref eyeTrackingValidationData);
        }

        public static void ReadGazeValidationDataFromCsv(string filePath, string fileNamePrefix,
            ref Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails)
        {
            DataMapper.DeSerializeGazeValidationData(
                GenerateCsvFile(filePath + CsvDirectoryGazeValidationPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.GazeValidation +
                                FileEndings.Csv),
                ref allDataOverAllTrails);
        }

        public static void ReadEyeTrackingDataFromCsv(string filePath, string fileNamePrefix,
            ref List<EyeClopsData> eyeTrackingData)
        {
            DataMapper.DeSerializeEyeTrackingData(
                GenerateCsvFile(filePath + CsvDirectoryEyeTrackingDataPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.EyeTrackingData +
                                FileEndings.Csv),
                ref eyeTrackingData);
        }

        private static List<string[]> GenerateCsvFile(string filePath)
        {
            List<string[]> csvFile = new List<string[]>();
            CsvDeSerializer.ReadCSVFile(filePath, ref csvFile);
            return csvFile;
        }


        //(De)Serialization from Binary Files
        public static void SaveValidationDataInBinary(List<EyeClopsValidationData> validationData,
            string fileAddress,
            string fileNamePrefix)
        {
            BinaryDeSerializer.WriteBinaryFile(DataMapper.SerializeSingleEyeTrackingBinaryValidationData(validationData),
                fileAddress + BinaryDirectoryValidationPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.Validation, FileEndings.Binary);
        }

        public static void SaveGazeValidationDataInBinary(
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> trailDictionary, string fileAddress,
            string fileNamePrefix)
        {
//            BinaryDeSerializer.WriteBinaryFile(DataMapper.SerializeGazeValidationData(trailDictionary),
//                fileAddress + BinaryDirectoryGazeValidationPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.GazeValidation,
//                FileEndings.Binary);
        }

        public static void SaveEyeTrackingDataInBinary(List<EyeClopsData> eyeTrackerData, string fileAddress,
            string fileNamePrefix)
        {
//            BinaryDeSerializer.WriteBinaryFile(DataMapper.SerializeEyeTrackingData(eyeTrackerData),
//                fileAddress + BinaryDirectoryEyeTrackingDataPath(), fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.EyeTrackingData,
//                FileEndings.Binary);
        }

        public static void ReadValidationDataFromBinary(string filePath, string fileNamePrefix,
            ref List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            DataMapper.DeSerializeSingleEyeTrackingBinaryValidationData(
                GenerateBinaryFile(filePath + BinaryDirectoryValidationPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator + FolderStructure.Validation +
                                   FileEndings.Binary),
                ref eyeTrackingValidationData);
        }

        public static void ReadGazeValidationDataFromBinary(string filePath, string fileNamePrefix,
            ref Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails)
        {
//            DataMapper.DeSerializeGazeValidationData(
//                GenerateBinaryFile(filePath + BinaryDirectoryGazeValidationPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator +
//                                   FolderStructure.GazeValidation + FileEndings.Binary),
//                ref allDataOverAllTrails);
        }

        public static void ReadEyeTrackingDataFromBinary(string filePath, string fileNamePrefix,
            ref List<EyeClopsData> eyeTrackingData)
        {
//            DataMapper.DeSerializeEyeTrackingData(
//                GenerateBinaryFile(filePath + BinaryDirectoryEyeTrackingDataPath() + fileNamePrefix + FileAdditions.FilePrefixAndSuffixSeparator +
//                                   FolderStructure.EyeTrackingData + FileEndings.Binary),
//                ref eyeTrackingData);
        }

        private static List<byte[][]> GenerateBinaryFile(string filePath)
        {
            var binaryFile = new List<byte[][]>();
            BinaryDeSerializer.ReadBinaryFile(filePath, ref binaryFile);
            Debug.Log("Größe: " + binaryFile.Count);
            return binaryFile;
        }


        private static string CsvDirectoryEyeTrackingDataPath()
        {
            return FolderStructure.CsvDirectory + EyeTrackingDataPath();
        }

        private static string CsvDirectoryGazeValidationPath()
        {
            return FolderStructure.CsvDirectory + GazeValidationPath();
        }

        private static string CsvDirectoryValidationPath()
        {
            return FolderStructure.CsvDirectory + ValidationPath();
        }

        private static string BinaryDirectoryEyeTrackingDataPath()
        {
            return FolderStructure.BinaryDirectory + EyeTrackingDataPath();
        }

        private static string BinaryDirectoryGazeValidationPath()
        {
            return FolderStructure.BinaryDirectory + GazeValidationPath();
        }

        private static string BinaryDirectoryValidationPath()
        {
            return FolderStructure.BinaryDirectory + ValidationPath();
        }

        private static string ValidationPath()
        {
            return Path.DirectorySeparatorChar + FolderStructure.Validation + Path.DirectorySeparatorChar;
        }


        private static string GazeValidationPath()
        {
            return Path.DirectorySeparatorChar + FolderStructure.GazeValidation + Path.DirectorySeparatorChar;
        }

        private static string EyeTrackingDataPath()
        {
            return Path.DirectorySeparatorChar + FolderStructure.EyeTrackingData + Path.DirectorySeparatorChar;
        }

        public static void GenerateIdentifierAndFileEndingMap(string folderPath,
            out Dictionary<string, List<string>> fileIdAndTypeMap)
        {
            FileIdentifierGenerator.GenerateIdentifierAndFileEndingMap(folderPath, out fileIdAndTypeMap);
        }
    }
}
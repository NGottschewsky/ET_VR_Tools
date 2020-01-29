using System;
using System.Collections.Generic;
using EyeClops.Data;
using EyeClops.DataLayer.DeSerializer;
using EyeClops.DataLayer.Mapper.EyeTrackingDataMapper;
using EyeClops.DataLayer.Mapper.GazeValidationDataMapper;
using EyeClops.DataLayer.Mapper.ValidationDataMapper;

namespace EyeClops.DataLayer.Mapper
{
    public static class DataMapper
    {
        private static readonly EyeTrackingStringValidationDataMapper EyeTrackingStringValidationDataMapper = new EyeTrackingStringValidationDataMapper();
        private static readonly GazeValidationStringDataMapper GazeValidationStringDataMapper = new GazeValidationStringDataMapper();
        private static readonly EyeClopsStringDataMapper EyeClopsStringDataMapper = new EyeClopsStringDataMapper();
        
        private static readonly EyeTrackingBinaryValidationDataMapper EyeTrackingBinaryValidationDataMapper = new EyeTrackingBinaryValidationDataMapper();
//        private static readonly GazeValidationStringDataMapper GazeValidationStringDataMapper = new GazeValidationStringDataMapper();
//        private static readonly EyeClopsStringDataMapper EyeClopsStringDataMapper = new EyeClopsStringDataMapper();

        //(De)Serialization from the ValidationData
        //String
        public static List<string[]> SerializeSingleEyeTrackingStringValidationData(
            List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            return EyeTrackingStringValidationDataMapper.GenerateSerializableFormat(eyeTrackingValidationData);
        }

        public static void DeSerializeSingleEyeTrackingStringValidationData(List<String[]> csvFile,
            ref List<EyeClopsValidationData> validationDataDeserialization)
        {
            EyeTrackingStringValidationDataMapper.GenerateDeserializedValidationData(csvFile,
                ref validationDataDeserialization);
        }

        //Binary
        public static List<byte[][]> SerializeSingleEyeTrackingBinaryValidationData(
            List<EyeClopsValidationData> eyeTrackingValidationData)
        {
            return EyeTrackingBinaryValidationDataMapper.GenerateSerializableFormat(eyeTrackingValidationData);
        }

        public static void DeSerializeSingleEyeTrackingBinaryValidationData(List<byte[][]> binFile,
            ref List<EyeClopsValidationData> validationDataDeserialization)
        {
            EyeTrackingBinaryValidationDataMapper.GenerateDeserializedValidationData(binFile,
                ref validationDataDeserialization);
        }

        
        
        //(De)Serialization from the GazeValidationData    
        public static List<string[]> SerializeGazeValidationData(
            Dictionary<int, Dictionary<string, List<GazeValidationData>>> gazeValidationData)
        {
            return GazeValidationStringDataMapper.GenerateSerializableFormat(gazeValidationData);
        }

        public static void DeSerializeGazeValidationData(List<String[]> csvFile,
            ref Dictionary<int, Dictionary<string, List<GazeValidationData>>> allDataOverAllTrails)
        {
            GazeValidationStringDataMapper.DeSerializeGazeValidationData(csvFile, ref allDataOverAllTrails);
        }

        //(De)Serialization from the EyeTrackingData   
        public static List<string[]> SerializeEyeTrackingData(List<EyeClopsData> eyeTrackingData)
        {
            return EyeClopsStringDataMapper.GenerateSerializableFormat(eyeTrackingData);
        }

        public static void DeSerializeEyeTrackingData(List<String[]> csvFile, ref List<EyeClopsData> eyeTrackingData)
        {
            EyeClopsStringDataMapper.DeSerializeEyeTrackingData(csvFile, ref eyeTrackingData);
        }
    }
}
using System;
using System.Collections.Generic;
using EyeClops.Internals;
using EyeClops.Manager;

namespace EyeClops.Analytical
{
    internal static class DescriptiveAnalyser
    {
        public static Dictionary<StatisticalDataType, float> CalculateStatisticalEyeData(
            List<SpecificGazeValidationData> gazeDataFromEye)
        {
            Dictionary<StatisticalDataType, float> returnDictionary = new Dictionary<StatisticalDataType, float>();
            float mean = CalculateMeanByGazeData(gazeDataFromEye);

            returnDictionary.Add(StatisticalDataType.Mean, mean);
            returnDictionary.Add(StatisticalDataType.StandardDeviation,
                CalculateStandardDeviationByGazeData(gazeDataFromEye, mean));
            return returnDictionary;
        }


        private static float CalculateMeanByGazeData(List<SpecificGazeValidationData> gazeData)
        {
            float summOfValues = 0;
            int numberOfValues = 0;
            foreach (SpecificGazeValidationData data in gazeData)
            {
                if (LegalValidationPoint(data))
                {
                    summOfValues += data.ErrorAngle;
                    numberOfValues++;
                }
            }

            return numberOfValues > 0 ? summOfValues / numberOfValues : 0;
        }

        private static float CalculateStandardDeviationByGazeData(List<SpecificGazeValidationData> gazeData, float mean)
        {
            int numberOfValues = 0;
            double summOfErrors = 0;
            foreach (SpecificGazeValidationData data in gazeData)
            {
                if (LegalValidationPoint(data))
                {
                    summOfErrors += Math.Pow((data.ErrorAngle - mean), 2);
                }
            }

            return numberOfValues > 0 ? Convert.ToSingle(Math.Sqrt(summOfErrors) / numberOfValues) : 0;
        }

        private static bool LegalValidationPoint(SpecificGazeValidationData data)
        {
            return data.FocusInfo.Transform != null &&
                   ValidationManager.instance.CheckIsLegalValidationPoint(data.FocusInfo.Transform.Name);
        }
    }
}
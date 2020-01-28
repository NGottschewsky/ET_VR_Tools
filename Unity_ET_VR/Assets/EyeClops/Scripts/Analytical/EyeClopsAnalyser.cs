using System.Collections.Generic;
using EyeClops.Internals;

namespace EyeClops.Analytical
{
    public static class EyeClopsAnalyser
    {
        public static Dictionary<StatisticalDataType, float> CalculateStatisticalEyeData(List<SpecificGazeValidationData> gazeDataFromEye)
        {
            return DescriptiveAnalyser.CalculateStatisticalEyeData(gazeDataFromEye);
        }
    }
}
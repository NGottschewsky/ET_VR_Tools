using System.Collections.Generic;
using EyeClops.Data;

namespace EyeClops.DataLayer.Mapper.ValidationDataMapper
{
    public abstract class EyeTrackingAbstractValidationDataMapper<Format> : GenericAbstractMapper<EyeClopsValidationData, Format>
    {
        protected readonly Dictionary<string, int> PositionValueMap;

        protected const string PointName = "PointName";
        protected const string LastScaleX = "LastScale_X";
        protected const string LastScaleY = "LastScale_Y";
        protected const string LastScaleZ = "LastScale_Z";
        protected const string MeasuringTime = "MeasuringTime";
        protected const string ValidationTrial = "ValidationTrial";

        protected EyeTrackingAbstractValidationDataMapper()
        {
            PositionValueMap = new Dictionary<string, int>
            {
                {PointName, 0},
                {LastScaleX, 1},
                {LastScaleY, 2},
                {LastScaleZ, 3},
                {MeasuringTime, 4},
                {ValidationTrial, 5}
            };
        }
    }
}
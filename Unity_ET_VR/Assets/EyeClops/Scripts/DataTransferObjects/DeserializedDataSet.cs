using System.Collections.Generic;
using EyeClops.Data;

namespace EyeClops.Data
{
    public class DeserializedDataSet
    {
        private string _identifier;
        private List<EyeClopsValidationData> _validationData;
        private List<EyeClopsData> _eyeTrackingData;

        public DeserializedDataSet(string identifier, List<EyeClopsValidationData> validationData, List<EyeClopsData> eyeTrackingData)
        {
            _identifier = identifier;
            _validationData = validationData;
            _eyeTrackingData = eyeTrackingData;
        }
    }
}
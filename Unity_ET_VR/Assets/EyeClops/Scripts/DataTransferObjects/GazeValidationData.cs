namespace EyeClops.DataLayer.DeSerializer
{
    public struct GazeValidationData
    {
        private SpecificGazeValidationData _leftEyeGazeValidationData;

        public SpecificGazeValidationData LeftEyeGazeValidationData
        {
            get => _leftEyeGazeValidationData;
            set => _leftEyeGazeValidationData = value;
        }

        private SpecificGazeValidationData _rightEyeGazeValidationData;

        public SpecificGazeValidationData RightEyeGazeValidationData
        {
            get => _rightEyeGazeValidationData;
            set => _rightEyeGazeValidationData = value;
        }

        private SpecificGazeValidationData _combinedEyeGazeValidationData;


        public SpecificGazeValidationData CombinedEyeGazeValidationData
        {
            get => _combinedEyeGazeValidationData;
            set => _combinedEyeGazeValidationData = value;
        }

        public GazeValidationData(SpecificGazeValidationData leftEyeGazeValidationData,
            SpecificGazeValidationData rightEyeGazeValidationData,
            SpecificGazeValidationData combinedEyeGazeValidationData)
        {
            _leftEyeGazeValidationData = leftEyeGazeValidationData;
            _rightEyeGazeValidationData = rightEyeGazeValidationData;
            _combinedEyeGazeValidationData = combinedEyeGazeValidationData;
        }
    }
}
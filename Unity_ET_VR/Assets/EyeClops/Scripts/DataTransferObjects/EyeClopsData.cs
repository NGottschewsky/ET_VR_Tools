namespace EyeClops.Data
{
    public class EyeClopsData
    {
        public string Timestamp { get; set; }

        public SingleEyeData LeftEyeData { get; set; }

        public SingleEyeData RightEyeData { get; set; }

        public CombinedEyeData CombinedEyeData { get; set; }

        public FocusData FocusData { get; set; }

        public HeadData HeadData { get; set; }

        public bool EventData { get; set; }

        public EyeClopsData()
        {
            Timestamp = "";
            LeftEyeData = new SingleEyeData();
            RightEyeData = new SingleEyeData();
            CombinedEyeData = new CombinedEyeData();
            FocusData = new FocusData();
            HeadData = new HeadData();
            EventData = false;
        }

        public EyeClopsData(string timestamp, SingleEyeData leftEyeData, SingleEyeData rightEyeData,
            CombinedEyeData combinedEyeData, FocusData focusData, HeadData headData, bool eventHappens)
        {
            Timestamp = timestamp;
            LeftEyeData = leftEyeData;
            RightEyeData = rightEyeData;
            CombinedEyeData = combinedEyeData;
            FocusData = focusData;
            HeadData = headData;
            EventData = eventHappens;
        }
    }
}
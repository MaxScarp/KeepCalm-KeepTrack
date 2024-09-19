namespace KeepCalm_KeepTrack.Database.Entities
{
    public class TimeFrameEntity : EntityBaseClass
    {
        public int TimeFrameId { get; set; }
        public required DateTime TimeFrameStart { get; set; }
        public required DateTime TimeFrameEnd { get; set; }
        public required TimeSpan TimeFrameTime { get; set; }

        public required int TaskId { get; set; }
        public required TaskEntity TaskEntity { get; set; }
    }
}

namespace KeepCalm_KeepTrack.Database.Entities
{
    public class TimeFrameEntity
    {
        public int TimeFrameId { get; set; }
        public DateTime TimeFrameStart { get; set; }
        public DateTime TimeFrameEnd { get; set; }
        public TimeSpan TimeFrameTime { get; set; }

        public int TaskId { get; set; }
        public required TaskEntity TaskEntity { get; set; }
    }
}

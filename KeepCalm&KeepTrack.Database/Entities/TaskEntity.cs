namespace KeepCalm_KeepTrack.Database.Entities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public required string TaskName { get; set; }
        public string? TaskDescription { get; set; }


        public int ProjectId { get; set; }
        public required ProjectEntity ProjectEntity { get; set; }

        public required List<TimeFrameEntity> TimeFrameEntityList { get; set; }
    }
}

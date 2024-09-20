namespace KeepCalm_KeepTrack.Database.Entities
{
    public class TaskEntity : EntityBaseClass
    {
        public int TaskId { get; set; }
        public required string TaskName { get; set; }
        public string? TaskDescription { get; set; }

        public required int ProjectId { get; set; }
        public ProjectEntity? ProjectEntity { get; set; }

        public List<TimeFrameEntity>? TimeFrameEntityList { get; set; }
    }
}

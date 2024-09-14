namespace KeepCalm_KeepTrack.Database.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }

        public required List<TaskEntity> TaskEntityList { get; set; }
    }
}

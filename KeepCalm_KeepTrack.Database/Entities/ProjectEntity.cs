namespace KeepCalm_KeepTrack.Database.Entities
{
    public class ProjectEntity : EntityBaseClass
    {
        public int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public string? ProjectDescription { get; set; }

        public List<TaskEntity>? TaskEntityList { get; set; }
    }
}

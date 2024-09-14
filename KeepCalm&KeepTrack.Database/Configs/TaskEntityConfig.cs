using KeepCalm_KeepTrack.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeepCalm_KeepTrack.Database.Configs
{
    public class TaskEntityConfig : IEntityTypeConfiguration<TaskEntity>
    {
        private const string TASK_TABLE_NAME = "Tasks";

        private const string TASK_ID_COLUMN_NAME = "Id";
        private const string TASK_NAME_COLUMN_NAME = "Name";
        private const string TASK_DESCRIPTION_COLUMN_NAME = "Description";

        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            //TABLE NAME
            builder.ToTable(TASK_TABLE_NAME);

            //COLUMNS NAME
            builder.Property(t => t.TaskId).HasColumnName(TASK_ID_COLUMN_NAME);
            builder.Property(t => t.TaskName).HasColumnName(TASK_NAME_COLUMN_NAME);
            builder.Property(t => t.TaskDescription).HasColumnName(TASK_DESCRIPTION_COLUMN_NAME);

            //PRIMARY KEY
            builder.HasKey(t => t.TaskId);

            //VALIDATIONS
            builder.Property(t => t.TaskId).UseIdentityColumn();
            builder.Property(t => t.TaskName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.TaskDescription).HasMaxLength(2048);

            //RELATIONS
            builder.HasOne(t => t.ProjectEntity).WithMany(p => p.TaskEntityList).HasForeignKey(t => t.ProjectId);
        }
    }
}

using KeepCalm_KeepTrack.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeepCalm_KeepTrack.Database.Configs
{
    public class ProjectEntityConfig : IEntityTypeConfiguration<ProjectEntity>
    {
        private const string PROJECT_TABLE_NAME = "Projects";

        private const string PROJECT_ID_COLUMN_NAME = "Id";
        private const string PROJECT_NAME_COLUMN_NAME = "Name";
        private const string PROJECT_DESCRIPTION_COLUMN_NAME = "Description";

        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            //TABLE NAME
            builder.ToTable(PROJECT_TABLE_NAME);

            //COLUMNS NAME
            builder.Property(p => p.ProjectId).HasColumnName(PROJECT_ID_COLUMN_NAME);
            builder.Property(p => p.ProjectName).HasColumnName(PROJECT_NAME_COLUMN_NAME);
            builder.Property(p => p.ProjectDescription).HasColumnName(PROJECT_DESCRIPTION_COLUMN_NAME);

            //PRIMARY KEY
            builder.HasKey(p => p.ProjectId);

            //VALIDATIONS
            builder.Property(p => p.ProjectId).UseIdentityColumn();
            builder.Property(p => p.ProjectName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.ProjectDescription).HasMaxLength(2048);
        }
    }
}

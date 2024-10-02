using KeepCalm_KeepTrack.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeepCalm_KeepTrack.Database.Configs
{
    public class TimeFrameEntityConfig : IEntityTypeConfiguration<TimeFrameEntity>
    {
        private const string TIME_FRAME_TABLE_NAME = "TimeFrames";

        private const string TIME_FRAME_ID_COLUMN_NAME = "Id";
        private const string TIME_FRAME_START_COLUMN_NAME = "StartDateTime";
        private const string TIME_FRAME_END_COLUMN_NAME = "EndDateTime";
        private const string TIME_FRAME_TIME_COLUMN_NAME = "TotalTime";

        public void Configure(EntityTypeBuilder<TimeFrameEntity> builder)
        {
            //TABLE NAME
            builder.ToTable(TIME_FRAME_TABLE_NAME);

            //COLUMNS NAME
            builder.Property(tf => tf.TimeFrameId).HasColumnName(TIME_FRAME_ID_COLUMN_NAME);
            builder.Property(tf => tf.TimeFrameStart).HasColumnName(TIME_FRAME_START_COLUMN_NAME);
            builder.Property(tf => tf.TimeFrameEnd).HasColumnName(TIME_FRAME_END_COLUMN_NAME);
            builder.Property(tf => tf.TimeFrameTime).HasColumnName(TIME_FRAME_TIME_COLUMN_NAME);

            //PRIMAARY KEY
            builder.HasKey(tf => tf.TimeFrameId);

            //VALIDATIONS
            builder.Property(tf => tf.TimeFrameId).UseIdentityColumn();
            builder.Property(tf => tf.TimeFrameStart).IsRequired();
            builder.Property(tf => tf.TimeFrameEnd).IsRequired();
            builder.Property(tf => tf.TimeFrameTime).IsRequired();

            //RELATIONS
            builder.HasOne(tf => tf.TaskEntity).WithMany(t => t.TimeFrameEntityList).HasForeignKey(tf => tf.TaskId);
        }
    }
}

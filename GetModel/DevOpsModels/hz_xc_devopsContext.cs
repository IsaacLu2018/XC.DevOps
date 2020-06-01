using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetModel.DataBaseModel
{
    public partial class hz_xc_devopsContext : DbContext
    {
        public hz_xc_devopsContext()
        {
        }

        public hz_xc_devopsContext(DbContextOptions<hz_xc_devopsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DevopsProject> DevopsProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("data source=172.16.8.7;port=3306;database=hz_xc_devops;user id=root;password=p@ssw0rd;charset=utf8", x => x.ServerVersion("5.6.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevopsProject>(entity =>
            {
                entity.ToTable("devops_project");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(100)")
                    .HasComment("项目唯一编号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Client)
                    .HasColumnName("client")
                    .HasColumnType("varchar(255)")
                    .HasComment("需求方（客户）")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("项目创建时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasComment("项目描述（富文本）")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("date")
                    .HasComment("项目结束时间");

                entity.Property(e => e.LastEditUser)
                    .HasColumnName("lastEditUser")
                    .HasColumnType("varchar(255)")
                    .HasComment("项目最近编辑人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("varchar(255)")
                    .HasComment("项目地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasColumnType("varchar(255)")
                    .HasComment("负责人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("decimal(11,5)")
                    .HasComment("项目实际顺序 结合优先级排序");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)")
                    .HasComment("项目优先级");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("date")
                    .HasComment("项目开始时间");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(20)")
                    .HasComment(@"状态
new 新建
inprogress 进行中
stop 暂停
analyzing 需求调研分析
testing 测试中
designing 设计中
running 运行维护
done 完成
archive 归档
abandon 项目取消")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Team)
                    .HasColumnName("team")
                    .HasColumnType("varchar(255)")
                    .HasComment("开发团队")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(600)")
                    .HasComment("项目名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

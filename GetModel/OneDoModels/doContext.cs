using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GetModel.OneDoModels
{
    public partial class doContext : DbContext
    {
        public doContext()
        {
        }

        public doContext(DbContextOptions<doContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Approval> Approval { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<T1doAttr> T1doAttr { get; set; }
        public virtual DbSet<T1doBase> T1doBase { get; set; }
        public virtual DbSet<T1doBoard> T1doBoard { get; set; }
        public virtual DbSet<T1doBoardDaliyReport> T1doBoardDaliyReport { get; set; }
        public virtual DbSet<T1doBoardLog> T1doBoardLog { get; set; }
        public virtual DbSet<T1doBoardRemark> T1doBoardRemark { get; set; }
        public virtual DbSet<T1doBoardTask> T1doBoardTask { get; set; }
        public virtual DbSet<T1doBoardTask1do> T1doBoardTask1do { get; set; }
        public virtual DbSet<T1doBoardTask1doCopy1> T1doBoardTask1doCopy1 { get; set; }
        public virtual DbSet<T1doBoardTaskCopy1> T1doBoardTaskCopy1 { get; set; }
        public virtual DbSet<T1doBoardTaskProgress> T1doBoardTaskProgress { get; set; }
        public virtual DbSet<T1doBoardTaskRemarks> T1doBoardTaskRemarks { get; set; }
        public virtual DbSet<T1doBoardTaskReport> T1doBoardTaskReport { get; set; }
        public virtual DbSet<T1doBoardUpdateLog> T1doBoardUpdateLog { get; set; }
        public virtual DbSet<T1doCall> T1doCall { get; set; }
        public virtual DbSet<T1doEventtype> T1doEventtype { get; set; }
        public virtual DbSet<T1doFbtype> T1doFbtype { get; set; }
        public virtual DbSet<T1doFeedback> T1doFeedback { get; set; }
        public virtual DbSet<T1doFw> T1doFw { get; set; }
        public virtual DbSet<T1doFwpstatus> T1doFwpstatus { get; set; }
        public virtual DbSet<T1doKeyword> T1doKeyword { get; set; }
        public virtual DbSet<T1doLabel> T1doLabel { get; set; }
        public virtual DbSet<T1doLabelFeedback> T1doLabelFeedback { get; set; }
        public virtual DbSet<T1doLabelRecord> T1doLabelRecord { get; set; }
        public virtual DbSet<T1doLog> T1doLog { get; set; }
        public virtual DbSet<T1doOrder> T1doOrder { get; set; }
        public virtual DbSet<T1doProject> T1doProject { get; set; }
        public virtual DbSet<T1doProject1do> T1doProject1do { get; set; }
        public virtual DbSet<T1doProjectStakeholder> T1doProjectStakeholder { get; set; }
        public virtual DbSet<T1doPset> T1doPset { get; set; }
        public virtual DbSet<T1doPstatus> T1doPstatus { get; set; }
        public virtual DbSet<T1doRecord> T1doRecord { get; set; }
        public virtual DbSet<T1doRelation> T1doRelation { get; set; }
        public virtual DbSet<T1doRelationFeedback> T1doRelationFeedback { get; set; }
        public virtual DbSet<T1doRelationRecord> T1doRelationRecord { get; set; }
        public virtual DbSet<T1doSet> T1doSet { get; set; }
        public virtual DbSet<T1doStatus> T1doStatus { get; set; }
        public virtual DbSet<T1doTemp> T1doTemp { get; set; }
        public virtual DbSet<T1doType> T1doType { get; set; }
        public virtual DbSet<T1doType1> T1doType1 { get; set; }
        public virtual DbSet<T1doUrgeWebsocket> T1doUrgeWebsocket { get; set; }
        public virtual DbSet<T1doUser> T1doUser { get; set; }
        public virtual DbSet<T1doWechat> T1doWechat { get; set; }
        public virtual DbSet<T1doWeight> T1doWeight { get; set; }
        public virtual DbSet<TRegCompany> TRegCompany { get; set; }
        public virtual DbSet<TRegCompanyDept> TRegCompanyDept { get; set; }
        public virtual DbSet<TRegUser> TRegUser { get; set; }
        public virtual DbSet<TRegUserDept> TRegUserDept { get; set; }
        public virtual DbSet<Tempab> Tempab { get; set; }
        public virtual DbSet<Websocket> Websocket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("data source=59.202.68.48;port=3306;database=do;user id=reader;password=123456;charset=utf8", x => x.ServerVersion("5.6.43-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approval>(entity =>
            {
                entity.ToTable("approval");

                entity.HasComment("审批配置表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号id");

                entity.Property(e => e.GmtCreate)
                    .HasColumnName("gmtCreate")
                    .HasColumnType("bigint(20)")
                    .HasComment("主动创建");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmtModified")
                    .HasColumnType("bigint(20)")
                    .HasComment("被动更新");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasComment("1 表示删除，0 表示未删除。");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("状态名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(11)")
                    .HasComment("来源 1、call 或者oa 2、主动办 3、三实库 4、其他");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1.是0.不是");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.ToTable("holiday");

                entity.HasComment("日期假期表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键id");

                entity.Property(e => e.Atemp)
                    .HasColumnName("atemp")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Btemp)
                    .HasColumnName("btemp")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("varchar(10)")
                    .HasDefaultValueSql("''")
                    .HasComment("数据")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("varchar(20)")
                    .HasComment(@"日期
")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasColumnType("datetime")
                    .HasComment("日期时间");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasColumnType("varchar(255)")
                    .HasComment("日期类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dtemp)
                    .HasColumnName("dtemp")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("节点id（计算时候使用）");

                entity.Property(e => e.Modifytime)
                    .HasColumnName("modifytime")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("varchar(50)")
                    .HasComment("月日（2.1）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("0工作日（包括周末补班），1周末，2节假日");

                entity.Property(e => e.Week)
                    .HasColumnName("week")
                    .HasColumnType("varchar(255)")
                    .HasComment("星期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WeekOfYear)
                    .HasColumnName("week_of_year")
                    .HasColumnType("varchar(10)")
                    .HasComment("（周跨年算明年）如2018-12-31 为201901")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Weeknum)
                    .HasColumnName("weeknum")
                    .HasColumnType("varchar(10)")
                    .HasComment("星期数值（一到日）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("notice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Test)
                    .HasColumnName("test")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doAttr>(entity =>
            {
                entity.ToTable("t_1do_attr");

                entity.HasComment("1do附件表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.AttrName)
                    .HasColumnName("ATTR_NAME")
                    .HasColumnType("text")
                    .HasComment("文件名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttrOrder)
                    .HasColumnName("ATTR_ORDER")
                    .HasColumnType("int(11)")
                    .HasComment("文件顺序");

                entity.Property(e => e.AttrPath)
                    .HasColumnName("ATTR_PATH")
                    .HasColumnType("text")
                    .HasComment("文件云存储路径")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsFb)
                    .HasColumnName("IS_FB")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否反馈1.否2.是");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UploadTime)
                    .HasColumnName("UPLOAD_TIME")
                    .HasColumnType("datetime")
                    .HasComment("上传时间");

                entity.Property(e => e.UploadUser)
                    .IsRequired()
                    .HasColumnName("UPLOAD_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("上传人员账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UploadUserName)
                    .HasColumnName("UPLOAD_USER_NAME")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBase>(entity =>
            {
                entity.ToTable("t_1do_base");

                entity.HasComment("1do主表");

                entity.HasIndex(e => e.ShowId)
                    .HasName("SHOW_ID_INDEX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)")
                    .HasComment("事件地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Aparameter)
                    .HasColumnName("APARAMETER")
                    .HasColumnType("int(11)")
                    .HasComment("a参数（source为2即来源为主动办时表示工单id）");

                entity.Property(e => e.At)
                    .HasColumnName("AT")
                    .HasColumnType("varchar(2550)")
                    .HasComment("@某人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Base)
                    .HasColumnName("base")
                    .HasColumnType("text")
                    .HasComment("转1do数据")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bparameter)
                    .HasColumnName("BPARAMETER")
                    .HasColumnType("int(11)")
                    .HasComment("b参数（source为2即来源为主动办时表示人数）");

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasColumnType("varchar(255)")
                    .HasComment("抄送人账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CcName)
                    .HasColumnName("CC_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("抄送人名字")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CommandPlatformId)
                    .HasColumnName("COMMAND_PLATFORM_ID")
                    .HasColumnType("varchar(255)")
                    .HasComment("指挥平台id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Cparameter)
                    .HasColumnName("CPARAMETER")
                    .HasColumnType("int(11)")
                    .HasComment("C参数（source为2即来源为主动办时表示工单状态）");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasColumnName("CREATE_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人(创建人账号)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnName("CREATE_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DShowId)
                    .HasColumnName("D_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("部门编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("DELETE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("删除时间");

                entity.Property(e => e.Dparameter)
                    .HasColumnName("DPARAMETER")
                    .HasColumnType("int(11)")
                    .HasComment("D参数（source为2即来源为主动办时表示工单类型1事项2方案）");

                entity.Property(e => e.Evaluation)
                    .HasColumnName("evaluation")
                    .HasColumnType("varchar(255)")
                    .HasComment("最新评价")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventId")
                    .HasColumnType("varchar(255)")
                    .HasComment("事件编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fbnum)
                    .HasColumnName("FBNUM")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("反馈数量");

                entity.Property(e => e.FeedbackSimilarity)
                    .HasColumnName("FEEDBACK_SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'30'")
                    .HasComment("反馈相似度");

                entity.Property(e => e.Groupid)
                    .HasColumnName("GROUPID")
                    .HasColumnType("text")
                    .HasComment("来源群id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsBindingWechatGroup)
                    .HasColumnName("IS_BINDING_WECHAT_GROUP")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否绑定微信群:1是0否");

                entity.Property(e => e.IsSuccess)
                    .HasColumnName("IS_SUCCESS")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1是0否（推送到综合指挥平台是否成功）");

                entity.Property(e => e.Isapproval)
                    .HasColumnName("ISAPPROVAL")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否审批1 表示审批，0 表示未审批。");

                entity.Property(e => e.Isaudit)
                    .HasColumnName("ISAUDIT")
                    .HasColumnType("int(11)")
                    .HasComment("是否审核1是未审核，2审核");

                entity.Property(e => e.Islook)
                    .HasColumnName("ISLOOK")
                    .HasColumnType("int(11)")
                    .HasComment("是否查看1是2否");

                entity.Property(e => e.LastupdateTime)
                    .HasColumnName("LASTUPDATE_TIME")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("最后更新时间");

                entity.Property(e => e.Lightning)
                    .HasColumnName("LIGHTNING")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("催办数（闪电）");

                entity.Property(e => e.LookUser)
                    .HasColumnName("LOOK_USER")
                    .HasColumnType("varchar(1000)")
                    .HasComment("工单查看人员showid，以逗号隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Looknum)
                    .HasColumnName("LOOKNUM")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("查看数量");

                entity.Property(e => e.MessageId)
                    .HasColumnName("MESSAGE_ID")
                    .HasColumnType("text")
                    .HasComment("来源消息id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Module)
                    .HasColumnName("module")
                    .HasColumnType("varchar(255)")
                    .HasComment("指挥平台接口module参数")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OCreateTime)
                    .HasColumnName("O_CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("开始时间（创建时间）");

                entity.Property(e => e.OCustomer)
                    .HasColumnName("O_CUSTOMER")
                    .HasColumnType("text")
                    .HasComment("客户(发起人账号)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OCustomerName)
                    .HasColumnName("O_CUSTOMER_NAME")
                    .HasColumnType("text")
                    .HasComment("客户姓名(发起人姓名)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ODescribe)
                    .IsRequired()
                    .HasColumnName("O_DESCRIBE")
                    .HasColumnType("text")
                    .HasComment("问题描述(内容)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.OExecutor)
                    .HasColumnName("O_EXECUTOR")
                    .HasColumnType("text")
                    .HasComment("受理人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OExecutorName)
                    .HasColumnName("O_EXECUTOR_NAME")
                    .HasColumnType("text")
                    .HasComment("受理人姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OFinishTime)
                    .HasColumnName("O_FINISH_TIME")
                    .HasColumnType("datetime")
                    .HasComment("拟完成时间");

                entity.Property(e => e.OHandle)
                    .HasColumnName("O_HANDLE")
                    .HasColumnType("varchar(255)")
                    .HasComment("处理人showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OHandleName)
                    .HasColumnName("O_HANDLE_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("处理人姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OIsDeleted)
                    .HasColumnName("O_IS_DELETED")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("删除标识1.正常2.删除");

                entity.Property(e => e.ORange)
                    .HasColumnName("O_RANGE")
                    .HasColumnType("text")
                    .HasComment("阅读范围(抄送人)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ORangeName)
                    .HasColumnName("O_RANGE_NAME")
                    .HasColumnType("text")
                    .HasComment("阅读范围人姓名（抄送人人姓名）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OStartTime)
                    .HasColumnName("O_START_TIME")
                    .HasColumnType("datetime")
                    .HasComment("开始时间(发起时间)");

                entity.Property(e => e.OStatus)
                    .HasColumnName("O_STATUS")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'")
                    .HasComment("处理状态3.待处理4.处理中5.已完成6.已删除");

                entity.Property(e => e.OTitle)
                    .HasColumnName("O_TITLE")
                    .HasColumnType("varchar(255)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OTypeId)
                    .HasColumnName("O_TYPE_ID")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("工单分类（1do分类）目前默认：39509142708158464；；来源为1call办的填（1、城管执法，2、民政，3、环卫，4、住建，5、人社）后续增加另行通知，来源为综合指挥平台，1、zdfw-主动服务，2、yj-预警，3、1do-转1do 4、 yjzh-一键指挥")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("PARENT_ID")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("父级工单显示ID(父级1do显示ID)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RealFinishTime)
                    .HasColumnName("Real_FINISH_TIME")
                    .HasColumnType("datetime")
                    .HasComment("实际完成时间");

                entity.Property(e => e.RecordSimilarity)
                    .HasColumnName("RECORD_SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'30'")
                    .HasComment("日志相似度");

                entity.Property(e => e.SendTime)
                    .HasColumnName("SEND_TIME")
                    .HasColumnType("bigint(20)")
                    .HasComment("通知时间");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Similarity)
                    .HasColumnName("SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'20'")
                    .HasComment("相似度");

                entity.Property(e => e.Source)
                    .HasColumnName("SOURCE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("来源 0、全部  1、call 或者oa 2、主动办 3、三实库 4、其他 5、领导批示6.城市大脑,7综合信息系统，8、1call办9、城市大脑综合指挥平台 10、督查指挥");

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("最新评价星星");

                entity.Property(e => e.Street)
                    .HasColumnName("STREET")
                    .HasColumnType("varchar(255)")
                    .HasComment("指挥平台新建1do填写街道（如qz01）：                               下城区：qzx01<br/>天水街道：tszx01<br/>武林街道：wlzhzx01<br/>长庆街道：cqzhzx01<br/>潮鸣街道：cmzhzx01<br/>朝晖街道：zhzhzx01<br/>文晖街道：whzx01<br/>东新街道：dxzhzx01<br/>石桥街道：sqzhzx01")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("置顶");

                entity.Property(e => e.Urgename)
                    .HasColumnName("URGENAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("催报人，以，隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Urgeshowid)
                    .HasColumnName("URGESHOWID")
                    .HasColumnType("varchar(255)")
                    .HasComment("催报人SHOWID，以，隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserType)
                    .HasColumnName("USER_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WechatGroupId)
                    .HasColumnName("WECHAT_GROUP_ID")
                    .HasColumnType("varchar(255)")
                    .HasComment("微信群组ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WechatGroupName)
                    .HasColumnName("WECHAT_GROUP_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("微信群名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBoard>(entity =>
            {
                entity.ToTable("t_1do_board");

                entity.HasComment("项目看板");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Completion)
                    .HasColumnName("COMPLETION")
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("''")
                    .HasComment("完成情况")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("FINISH_DATE")
                    .HasColumnType("date")
                    .HasComment("完成日期");

                entity.Property(e => e.ItemName)
                    .HasColumnName("ITEM_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("PARENT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("父节点id");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("类型：1是项目分类节点2是子分类节点3项目节点");
            });

            modelBuilder.Entity<T1doBoardDaliyReport>(entity =>
            {
                entity.ToTable("t_1do_board_daliy_report");

                entity.HasComment("项目看板日报");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("COMPANY")
                    .HasColumnType("varchar(50)")
                    .HasComment("公司showId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text")
                    .HasComment("日报内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日志日期");

                entity.Property(e => e.Number)
                    .HasColumnName("NUMBER")
                    .HasColumnType("int(11)")
                    .HasComment("字数");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id");

                entity.Property(e => e.ReportId)
                    .HasColumnName("REPORT_ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TASK_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("任务id");

                entity.Property(e => e.Time)
                    .HasColumnName("TIME")
                    .HasColumnType("timestamp")
                    .HasComment("报送时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("UPDATE_TIME")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<T1doBoardLog>(entity =>
            {
                entity.ToTable("t_1do_board_log");

                entity.HasComment("项目看板日志");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("节点id");

                entity.Property(e => e.ItemName)
                    .HasColumnName("ITEM_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("1call用户的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("PARENT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("父节点id");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("类型1新增2修改3删除");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("UPDATE_TIME")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<T1doBoardRemark>(entity =>
            {
                entity.ToTable("t_1do_board_remark");

                entity.HasComment("项目看板备注表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(2)")
                    .HasComment("1-日报评价，2-日报备注，3-项目完整进展备注，4-项目进展备注");
            });

            modelBuilder.Entity<T1doBoardTask>(entity =>
            {
                entity.ToTable("t_1do_board_task");

                entity.HasComment("项目看板项目完整进度表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Atemp)
                    .HasColumnName("ATEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成已完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Btemp)
                    .HasColumnName("BTEMP")
                    .HasColumnType("text")
                    .HasComment("已完成变成未完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Completion)
                    .HasColumnName("COMPLETION")
                    .HasColumnType("varchar(20)")
                    .HasComment("完成情况")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("text")
                    .HasComment("各个实际日期状态")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.Dtemp)
                    .HasColumnName("DTEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成绿色取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsRelation)
                    .HasColumnName("IS_RELATION")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否关联日报 1是0否");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目节点id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.PlannedDate)
                    .HasColumnName("PLANNED_DATE")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划日期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlannedTime)
                    .HasColumnName("PLANNED_TIME")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Principle)
                    .HasColumnName("PRINCIPLE")
                    .HasColumnType("varchar(1000)")
                    .HasComment("负责人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrincipleShowId)
                    .HasColumnName("PRINCIPLE_SHOW_ID")
                    .HasColumnType("varchar(1000)")
                    .HasComment("负责人showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id");

                entity.Property(e => e.Task)
                    .HasColumnName("TASK")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("任务")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBoardTask1do>(entity =>
            {
                entity.ToTable("t_1do_board_task_1do");

                entity.HasComment("项目看板项目1do完整进度表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Atemp)
                    .HasColumnName("ATEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成已完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Btemp)
                    .HasColumnName("BTEMP")
                    .HasColumnType("text")
                    .HasComment("已完成变成未完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("text")
                    .HasComment("各个实际日期状态")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目节点id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.PlannedTime)
                    .HasColumnName("PLANNED_TIME")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBoardTask1doCopy1>(entity =>
            {
                entity.ToTable("t_1do_board_task_1do_copy1");

                entity.HasComment("项目看板项目完整进度表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Atemp)
                    .HasColumnName("ATEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成已完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Btemp)
                    .HasColumnName("BTEMP")
                    .HasColumnType("text")
                    .HasComment("已完成变成未完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("text")
                    .HasComment("各个实际日期状态")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目节点id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.PlannedTime)
                    .HasColumnName("PLANNED_TIME")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBoardTaskCopy1>(entity =>
            {
                entity.ToTable("t_1do_board_task_copy1");

                entity.HasComment("项目看板项目完整进度表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Atemp)
                    .HasColumnName("ATEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成已完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Btemp)
                    .HasColumnName("BTEMP")
                    .HasColumnType("text")
                    .HasComment("已完成变成未完成取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Completion)
                    .HasColumnName("COMPLETION")
                    .HasColumnType("varchar(20)")
                    .HasComment("完成情况")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("text")
                    .HasComment("各个实际日期状态")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.Dtemp)
                    .HasColumnName("DTEMP")
                    .HasColumnType("text")
                    .HasComment("未完成变成绿色取该字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsRelation)
                    .HasColumnName("IS_RELATION")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否关联日报 1是0否");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目节点id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.PlannedDate)
                    .HasColumnName("PLANNED_DATE")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划日期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlannedTime)
                    .HasColumnName("PLANNED_TIME")
                    .HasColumnType("varchar(255)")
                    .HasComment("计划时间")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Principle)
                    .HasColumnName("PRINCIPLE")
                    .HasColumnType("varchar(1000)")
                    .HasComment("负责人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PrincipleShowId)
                    .HasColumnName("PRINCIPLE_SHOW_ID")
                    .HasColumnType("varchar(1000)")
                    .HasComment("负责人showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id");

                entity.Property(e => e.Task)
                    .HasColumnName("TASK")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("任务")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doBoardTaskProgress>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.ProjectId })
                    .HasName("PRIMARY");

                entity.ToTable("t_1do_board_task_progress");

                entity.HasComment("项目任务进展");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("父节点id");

                entity.Property(e => e.AllNumber)
                    .HasColumnName("ALL_NUMBER")
                    .HasColumnType("int(11)")
                    .HasComment("任务总数");

                entity.Property(e => e.AlreadyNumber)
                    .HasColumnName("ALREADY_NUMBER")
                    .HasColumnType("int(11)")
                    .HasComment("任务完成数");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("int(11)")
                    .HasComment("任务完成百分比");
            });

            modelBuilder.Entity<T1doBoardTaskRemarks>(entity =>
            {
                entity.ToTable("t_1do_board_task_remarks");

                entity.HasComment("项目看板任务评估");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("COMPANY_ID")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasComment("公司id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TASK_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("任务id");
            });

            modelBuilder.Entity<T1doBoardTaskReport>(entity =>
            {
                entity.ToTable("t_1do_board_task_report");

                entity.HasComment("项目看板项目完整进度表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date")
                    .HasComment("日期");

                entity.Property(e => e.Number)
                    .HasColumnName("NUMBER")
                    .HasColumnType("int(11)")
                    .HasComment("编号（1，2，3）三个位置的总结");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id");

                entity.Property(e => e.Summary)
                    .HasColumnName("SUMMARY")
                    .HasColumnType("text")
                    .HasComment("总结")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<T1doBoardUpdateLog>(entity =>
            {
                entity.ToTable("t_1do_board_update_log");

                entity.HasComment("项目看板日志");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("text")
                    .HasComment("修改前内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUser)
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("1call用户的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("项目分类-1，项目子分类-2");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("UPDATE_TIME")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<T1doCall>(entity =>
            {
                entity.ToTable("t_1do_call");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("id");

                entity.Property(e => e.CallStatusMessage)
                    .HasColumnName("callStatusMessage")
                    .HasColumnType("text")
                    .HasComment("国际语音状态报告推送")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<T1doEventtype>(entity =>
            {
                entity.ToTable("t_1do_eventtype");

                entity.HasComment("1do事件类型表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.EventType)
                    .HasColumnName("EVENT_TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("通知类型");

                entity.Property(e => e.EventTypeName)
                    .HasColumnName("EVENT_TYPE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("通知类型名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doFbtype>(entity =>
            {
                entity.ToTable("t_1do_fbtype");

                entity.HasComment("1do反馈分类表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.OParentId)
                    .HasColumnName("O_PARENT_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("上级1do反馈分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OTypeId)
                    .HasColumnName("O_TYPE_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do反馈分类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OTypeName)
                    .HasColumnName("O_TYPE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do反馈分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doFeedback>(entity =>
            {
                entity.ToTable("t_1do_feedback");

                entity.HasComment("1do反馈表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.At)
                    .HasColumnName("AT")
                    .HasColumnType("varchar(2550)")
                    .HasComment("@某人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttrName)
                    .HasColumnName("ATTR_NAME")
                    .HasColumnType("text")
                    .HasComment("文件名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttrPath)
                    .HasColumnName("ATTR_PATH")
                    .HasColumnType("text")
                    .HasComment("文件云存储路径组")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attrid)
                    .HasColumnName("ATTRID")
                    .HasColumnType("text")
                    .HasComment("附件id组")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CallMessage)
                    .HasColumnName("callMessage")
                    .HasColumnType("varchar(255)")
                    .HasComment("催办电话返回值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FbTime)
                    .HasColumnName("FB_TIME")
                    .HasColumnType("datetime")
                    .HasComment("反馈时间");

                entity.Property(e => e.FbType)
                    .HasColumnName("FB_TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("反馈类型标签1，正常反馈；2，回复反馈；3，附件反馈  4，催办反馈，5，办结反馈；6，评价反馈，7删除反馈,8删除反馈时加1条数据,9.语音反馈填,10网页链接");

                entity.Property(e => e.FbUser)
                    .HasColumnName("FB_USER")
                    .HasColumnType("text")
                    .HasComment("对应用户账号组（回复对象）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FbUserName)
                    .HasColumnName("FB_USER_NAME")
                    .HasColumnType("text")
                    .HasComment("对应用户账号组名字（回复对象）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Fbcontent)
                    .HasColumnName("FBCONTENT")
                    .HasColumnType("text")
                    .HasComment("反馈内容")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IsCreateReport)
                    .HasColumnName("IS_CREATE_REPORT")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否转过日志1是0否");

                entity.Property(e => e.Isoverdue)
                    .HasColumnName("isoverdue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否过期1否2是");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("相关人员showid（反馈人）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUserName)
                    .HasColumnName("O_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("相关人员姓名（反馈人）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShortMessage)
                    .HasColumnName("shortMessage")
                    .HasColumnType("varchar(255)")
                    .HasComment("催办短信返回值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("本系统默认0，其他系统：1微信，2四个平台。");

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("星星");

                entity.Property(e => e.Temp)
                    .HasColumnName("temp")
                    .HasColumnType("int(11)")
                    .HasComment("零时字段处理脏数据用");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("bigint(20)")
                    .HasComment("时间戳");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doFw>(entity =>
            {
                entity.ToTable("t_1do_fw");

                entity.HasComment("1do整理层管理范围");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.DShowId)
                    .HasColumnName("D_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("管理部门编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Icallshowid)
                    .HasColumnName("icallshowid")
                    .HasColumnType("varchar(50)")
                    .HasComment("1call的showid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("是否查看1是2否");

                entity.Property(e => e.OTypeId)
                    .HasColumnName("O_TYPE_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do分类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("整理人员账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUserName)
                    .IsRequired()
                    .HasColumnName("O_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("1正常通知，2 不通知");
            });

            modelBuilder.Entity<T1doFwpstatus>(entity =>
            {
                entity.ToTable("t_1do_fwpstatus");

                entity.HasComment("1do相关人员状态表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmt_modified")
                    .HasColumnType("datetime")
                    .HasComment("被动更新")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("是否查看1是2否");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("是否在线1在线2不在线");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doKeyword>(entity =>
            {
                entity.ToTable("t_1do_keyword");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Keyword)
                    .HasColumnName("KEYWORD")
                    .HasColumnType("varchar(0)")
                    .HasComment("关键词")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("int(11)")
                    .HasComment("权重");
            });

            modelBuilder.Entity<T1doLabel>(entity =>
            {
                entity.ToTable("t_1do_label");

                entity.HasComment("1do传送门标签表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasColumnType("varchar(255)")
                    .HasComment("标签")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("类型自动解析的未1，整理层加的为2");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)")
                    .HasComment("权重");
            });

            modelBuilder.Entity<T1doLabelFeedback>(entity =>
            {
                entity.ToTable("t_1do_label_feedback");

                entity.HasComment("1do反馈标签表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Fbid)
                    .HasColumnName("FBID")
                    .HasColumnType("int(11)")
                    .HasComment("反馈ID");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasColumnType("varchar(255)")
                    .HasComment("标签")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("类型自动解析的未1，整理层加的为2");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)")
                    .HasComment("权重");
            });

            modelBuilder.Entity<T1doLabelRecord>(entity =>
            {
                entity.ToTable("t_1do_label_record");

                entity.HasComment("1do日志标签表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasColumnType("varchar(255)")
                    .HasComment("标签")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Recordid)
                    .HasColumnName("RECORDID")
                    .HasColumnType("bigint(20)")
                    .HasComment("日志ID");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("类型自动解析的未1，整理层加的为2");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)")
                    .HasComment("权重");
            });

            modelBuilder.Entity<T1doLog>(entity =>
            {
                entity.ToTable("t_1do_log");

                entity.HasComment("1do操作日志审计表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.Calculation)
                    .HasColumnName("calculation")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否已经计算（评价系统算法）1是0否");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasComment("其他参数")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CrateTime)
                    .HasColumnName("crate_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.Isoverdue)
                    .HasColumnName("isoverdue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否过期1否2是（1do重做后数据会过期）");

                entity.Property(e => e.Log)
                    .HasColumnName("log")
                    .HasColumnType("text")
                    .HasComment("操作日志")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LogType)
                    .HasColumnName("log_type")
                    .HasColumnType("int(11)")
                    .HasComment("操作类型日志状态（1.创建2.查看3.上传4.催办5.确认办结6.评价7.拆项8.移除人9.邀请.10.反馈11.删除反馈,12.删除1do,13.恢复1do,14.修改15.重做1do16.新建子1do17.下载，18修改所属项目））");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUserName)
                    .IsRequired()
                    .HasColumnName("O_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OpTime)
                    .HasColumnName("op_time")
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.Oprator)
                    .HasColumnName("oprator")
                    .HasColumnType("varchar(50)")
                    .HasComment("实际操作人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doOrder>(entity =>
            {
                entity.ToTable("t_1do_order");

                entity.HasComment("1do置顶表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("id");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ShowId)
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(255)")
                    .HasComment("show_id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("要我做1，要他做2，整理层 3");

                entity.Property(e => e.Useraccount)
                    .HasColumnName("useraccount")
                    .HasColumnType("varchar(255)")
                    .HasComment("用户账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doProject>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("t_1do_project");

                entity.HasComment("项目看板项目表");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.CrateUser)
                    .HasColumnName("CRATE_USER")
                    .HasColumnType("varchar(255)")
                    .HasComment("创建人的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GROUP_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1CALL群id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GroupName)
                    .HasColumnName("GROUP_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("群名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("IS_DELETED")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否删除1是0否");

                entity.Property(e => e.IsFinish)
                    .HasColumnName("IS_FINISH")
                    .HasComment("是否完成1是0否");

                entity.Property(e => e.IsKey)
                    .HasColumnName("IS_KEY")
                    .HasComment("是否是重点项目1是0否");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("看板名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OCreateTime)
                    .HasColumnName("O_CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.OFinishTime)
                    .HasColumnName("O_FINISH_TIME")
                    .HasColumnType("datetime")
                    .HasComment("拟完成时间");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("UPDATE_TIME")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<T1doProject1do>(entity =>
            {
                entity.ToTable("t_1do_project_1do");

                entity.HasComment("项目-1do关联表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(11)")
                    .HasComment("自增id");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doProjectStakeholder>(entity =>
            {
                entity.ToTable("t_1do_project_stakeholder");

                entity.HasComment("项目-干系人关联表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(11)")
                    .HasComment("自增id");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("COMPANY")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("公司showId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ITEM_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("项目id(t_1do_board中是项目的id关联)");

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("1call用户的showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint(11)")
                    .HasComment("项目ID");
            });

            modelBuilder.Entity<T1doPset>(entity =>
            {
                entity.ToTable("t_1do_pset");

                entity.HasComment("1do相关人员设置表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.EventType)
                    .HasColumnName("EVENT_TYPE")
                    .HasColumnType("text")
                    .HasComment("订阅事件1.送达2.查看3.反馈4.催办5.办结6.评价")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("相关人员账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserType)
                    .HasColumnName("USER_TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("1发起人2创建人3受理人4抄送人5受邀人");
            });

            modelBuilder.Entity<T1doPstatus>(entity =>
            {
                entity.ToTable("t_1do_pstatus");

                entity.HasComment("1do相关人员状态表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmt_modified")
                    .HasColumnType("datetime")
                    .HasComment("被动更新")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否删除1否2是");

                entity.Property(e => e.IsRead)
                    .HasColumnName("isRead")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("是否查看1是2否(是否发送通知)");

                entity.Property(e => e.Islook)
                    .HasColumnName("ISLOOK")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("看板红点（是否查看1是2否）");

                entity.Property(e => e.OStatus)
                    .HasColumnName("O_STATUS")
                    .HasColumnType("int(11)")
                    .HasComment("处理状态 1.已送达2.无（创建人状态）3.待处理4.处理中5.已完成6.已删除");

                entity.Property(e => e.OUser)
                    .IsRequired()
                    .HasColumnName("O_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OUserName)
                    .IsRequired()
                    .HasColumnName("O_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
                    .HasComment("显示ID（相关人员账号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("是否在线1在线2不在线");

                entity.Property(e => e.Original)
                    .HasColumnName("original")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("原始人员1，后台添加的人2");

                entity.Property(e => e.Otherid)
                    .HasColumnName("otherid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("其他身份1受理人，2抄送人");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("text")
                    .HasComment("发送通知返回结果")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'")
                    .HasComment("sort，处理人排1，@xx排2，参与人排3");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasColumnType("varchar(20)")
                    .HasComment("处理状态 1.已送达2.无（创建人状态）3.待接单4.已接单5.已完成6.已删除")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UrgeIsLook)
                    .HasColumnName("urge_isLook")
                    .HasDefaultValueSql("'1'")
                    .HasComment("催报是否查看1.是0.否");

                entity.Property(e => e.UserType)
                    .HasColumnName("USER_TYPE")
                    .HasColumnType("int(11)")
                    .HasComment("1发起人2创建人3受理人4抄送人5受邀人6整理层");
            });

            modelBuilder.Entity<T1doRecord>(entity =>
            {
                entity.ToTable("t_1do_record");

                entity.HasComment("日志表");

                entity.HasIndex(e => e.Recordid)
                    .HasName("RECORDID_INDEX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("id");

                entity.Property(e => e.Account)
                    .HasColumnName("ACCOUNT")
                    .HasColumnType("varchar(255)")
                    .HasComment("账号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Createtime)
                    .HasColumnName("CREATETIME")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("名字")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Record)
                    .HasColumnName("RECORD")
                    .HasColumnType("text")
                    .HasComment("日志内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Recordid)
                    .HasColumnName("RECORDID")
                    .HasColumnType("bigint(20)")
                    .HasComment("日志id");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态1正常，2删除");
            });

            modelBuilder.Entity<T1doRelation>(entity =>
            {
                entity.ToTable("t_1do_relation");

                entity.HasComment("1do传送门关联表");

                entity.HasIndex(e => e.RelationShowId)
                    .HasName("RELATION_SHOW_ID_INDEX");

                entity.HasIndex(e => e.ShowId)
                    .HasName("SHOW_ID_INDEX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Modifytime)
                    .HasColumnName("MODIFYTIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RelationShowId)
                    .HasColumnName("RELATION_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("关联SHOW_ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Similarity)
                    .HasColumnName("SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasComment("相似度");

                entity.Property(e => e.Sort)
                    .HasColumnName("SORT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序 -1是批量添加的关联 -2父1do -3是子1do");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'6'")
                    .HasComment("0手动添加的关联。6已删除的1do，-1父1do，-2子1do");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("int(11)")
                    .HasComment("权重");
            });

            modelBuilder.Entity<T1doRelationFeedback>(entity =>
            {
                entity.ToTable("t_1do_relation_feedback");

                entity.HasComment("1do传送门反馈关联表");

                entity.HasIndex(e => e.Fbid)
                    .HasName("RELATION_SHOW_ID_INDEX");

                entity.HasIndex(e => e.ShowId)
                    .HasName("SHOW_ID_INDEX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Fbid)
                    .HasColumnName("FBID")
                    .HasColumnType("int(11)")
                    .HasComment("关联反馈id");

                entity.Property(e => e.Modifytime)
                    .HasColumnName("MODIFYTIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Similarity)
                    .HasColumnName("SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasComment("相似度");

                entity.Property(e => e.Sort)
                    .HasColumnName("SORT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1显示0不显示");
            });

            modelBuilder.Entity<T1doRelationRecord>(entity =>
            {
                entity.ToTable("t_1do_relation_record");

                entity.HasComment("1do传送门日志关联表");

                entity.HasIndex(e => e.Recordid)
                    .HasName("RELATION_SHOW_ID_INDEX");

                entity.HasIndex(e => e.ShowId)
                    .HasName("SHOW_ID_INDEX");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Modifytime)
                    .HasColumnName("MODIFYTIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("修改时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Recordid)
                    .HasColumnName("RECORDID")
                    .HasColumnType("bigint(20)")
                    .HasComment("关联反馈id");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Similarity)
                    .HasColumnName("SIMILARITY")
                    .HasColumnType("int(11)")
                    .HasComment("相似度");

                entity.Property(e => e.Sort)
                    .HasColumnName("SORT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1显示0不显示");
            });

            modelBuilder.Entity<T1doSet>(entity =>
            {
                entity.ToTable("t_1do_set");

                entity.HasComment("1do默认设置表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.EventType)
                    .HasColumnName("EVENT_TYPE")
                    .HasColumnType("varchar(50)")
                    .HasComment("订阅事件1.送达2.查看3.反馈4.催办5.办结6.评价")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doStatus>(entity =>
            {
                entity.ToTable("t_1do_status");

                entity.HasComment("1do状态表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.OStatus)
                    .HasColumnName("O_STATUS")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'")
                    .HasComment("处理状态3.待处理4.处理中5.已完成");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doTemp>(entity =>
            {
                entity.ToTable("t_1do_temp");

                entity.HasComment("1call转1do缓存表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Base)
                    .HasColumnName("BASE")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyTime)
                    .HasColumnName("modifyTime")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<T1doType>(entity =>
            {
                entity.ToTable("t_1do_type");

                entity.HasComment("1do分类表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.OParentId)
                    .HasColumnName("O_PARENT_ID")
                    .HasColumnType("int(11)")
                    .HasComment("上级分类ID");

                entity.Property(e => e.OSoureName)
                    .HasColumnName("O_SOURE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do来源名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OTypeId)
                    .HasColumnName("O_TYPE_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1do分类");

                entity.Property(e => e.OTypeName)
                    .HasColumnName("O_TYPE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'全部'")
                    .HasComment("1do分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherName)
                    .HasColumnName("OTHER_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("其他名称（1do看板里用）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doType1>(entity =>
            {
                entity.ToTable("t_1do_type1");

                entity.HasComment("1do分类表");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("编号");

                entity.Property(e => e.OParentId)
                    .HasColumnName("O_PARENT_ID")
                    .HasColumnType("int(11)")
                    .HasComment("上级分类ID");

                entity.Property(e => e.OSoureName)
                    .HasColumnName("O_SOURE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("1do来源名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OTypeId)
                    .HasColumnName("O_TYPE_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1do分类");

                entity.Property(e => e.OTypeName)
                    .HasColumnName("O_TYPE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'全部'")
                    .HasComment("1do分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OtherName)
                    .HasColumnName("OTHER_NAME")
                    .HasColumnType("varchar(255)")
                    .HasComment("其他名称（1do看板里用）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doUrgeWebsocket>(entity =>
            {
                entity.ToTable("t_1do_urge_websocket");

                entity.HasComment("审批配置表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GmtCreate)
                    .HasColumnName("gmtCreate")
                    .HasColumnType("bigint(20)")
                    .HasComment("主动创建");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmtModified")
                    .HasColumnType("bigint(20)")
                    .HasComment("被动更新");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasComment("1 表示删除，0 表示未删除。");

                entity.Property(e => e.IsOnline)
                    .IsRequired()
                    .HasColumnName("isOnline")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否在线1 表示在线，0 表示离线。");

                entity.Property(e => e.ModeifyTime)
                    .HasColumnName("modeifyTime")
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Sessionid)
                    .HasColumnName("sessionid")
                    .HasColumnType("varchar(255)")
                    .HasComment("来源1、主动办2、三实库")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("来源：1.综合信息平台、2.oa、3.1call、4.android、5.IOS");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasColumnType("varchar(255)")
                    .HasComment("账号/用户showid")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doUser>(entity =>
            {
                entity.ToTable("t_1do_user");

                entity.HasComment("1do(1call用户表)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CShowId)
                    .HasColumnName("C_SHOW_ID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DName)
                    .HasColumnName("D_NAME")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LoginName)
                    .HasColumnName("loginName")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowId)
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UDeptId)
                    .HasColumnName("U_DEPT_ID")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UMail)
                    .HasColumnName("U_MAIL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UMobile)
                    .HasColumnName("U_MOBILE")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UTrueName)
                    .HasColumnName("U_TRUE_NAME")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<T1doWechat>(entity =>
            {
                entity.ToTable("t_1do_wechat");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("时间")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.DataId)
                    .HasColumnName("data_id")
                    .HasColumnType("varchar(250)")
                    .HasComment("数据id如工单showid，反馈id等")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Parameter)
                    .HasColumnName("parameter")
                    .HasColumnType("text")
                    .HasComment("参数")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("text")
                    .HasComment("返回值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasComment("1、新建群发的第一条消息，2、反馈消息、3、公告、4加入、5减人,6修改群名、7创建群并拉入用户、8查看群创建任务进度、9修改群名并绑定，10、绑定群并拉入新用户、11解绑微信群");
            });

            modelBuilder.Entity<T1doWeight>(entity =>
            {
                entity.ToTable("t_1do_weight");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("自增id");

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasColumnType("varchar(255)")
                    .HasComment("标签(每个标签两条数据方便计算)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Weight)
                    .HasColumnName("WEIGHT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'")
                    .HasComment("权重");
            });

            modelBuilder.Entity<TRegCompany>(entity =>
            {
                entity.ToTable("t_reg_company");

                entity.HasComment("企业信息表");

                entity.HasIndex(e => e.CCode)
                    .HasName("AK_UQ_C_CODE")
                    .IsUnique();

                entity.HasIndex(e => e.ShowId)
                    .HasName("INDEX_SHOWID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("记录ID");

                entity.Property(e => e.CActivationStatus)
                    .HasColumnName("C_ACTIVATION_STATUS")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("激活状态");

                entity.Property(e => e.CActivationTime)
                    .HasColumnName("C_ACTIVATION_TIME")
                    .HasColumnType("datetime")
                    .HasComment("激活时间");

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasColumnName("C_CODE")
                    .HasColumnType("varchar(50)")
                    .HasComment("企业编码(域名)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("C_NAME")
                    .HasColumnType("varchar(200)")
                    .HasComment("企业名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasColumnName("CREATE_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnName("CREATE_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.EndTime)
                    .HasColumnName("END_TIME")
                    .HasColumnType("datetime")
                    .HasComment("有效期");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<TRegCompanyDept>(entity =>
            {
                entity.ToTable("t_reg_company_dept");

                entity.HasComment("企业组织架构表");

                entity.HasIndex(e => e.CShowId)
                    .HasName("INDEX_CSHOWID");

                entity.HasIndex(e => e.ShowId)
                    .HasName("AK_AK_UQ_C_DEPT_SHOW_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("记录ID");

                entity.Property(e => e.AppId)
                    .HasColumnName("APP_ID")
                    .HasColumnType("text")
                    .HasComment("最大应用集")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AppName)
                    .HasColumnName("APP_NAME")
                    .HasColumnType("text")
                    .HasComment("最大应用集")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Background)
                    .HasColumnName("BACKGROUND")
                    .HasColumnType("text")
                    .HasComment("背景")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CShowId)
                    .IsRequired()
                    .HasColumnName("C_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("企业显示编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasColumnName("CREATE_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnName("CREATE_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DAvailableCount)
                    .HasColumnName("D_AVAILABLE_COUNT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DChilddeptCount)
                    .HasColumnName("D_CHILDDEPT_COUNT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DIcon)
                    .HasColumnName("D_ICON")
                    .HasColumnType("text")
                    .HasComment("图标")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DLevel)
                    .HasColumnName("D_LEVEL")
                    .HasColumnType("int(11)")
                    .HasComment("部门级别");

                entity.Property(e => e.DName)
                    .IsRequired()
                    .HasColumnName("D_NAME")
                    .HasColumnType("varchar(100)")
                    .HasComment("部门名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DParentidShowId)
                    .IsRequired()
                    .HasColumnName("D_PARENTID_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("上级部门")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DPath)
                    .IsRequired()
                    .HasColumnName("D_PATH")
                    .HasColumnType("text")
                    .HasComment("部门路径")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DPathName)
                    .IsRequired()
                    .HasColumnName("D_PATH_NAME")
                    .HasColumnType("text")
                    .HasComment("部门名称路径")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DSort)
                    .HasColumnName("D_SORT")
                    .HasColumnType("int(11)")
                    .HasComment("排序号,越小越前面");

                entity.Property(e => e.DUnavailableCount)
                    .HasColumnName("D_UNAVAILABLE_COUNT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("LAST_UPDATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.USign)
                    .HasColumnName("U_SIGN")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否隐藏，0-否，1-是");
            });

            modelBuilder.Entity<TRegUser>(entity =>
            {
                entity.ToTable("t_reg_user");

                entity.HasComment("企业用户表");

                entity.HasIndex(e => e.UName)
                    .HasName("Index_1");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("用户ID");

                entity.Property(e => e.CShowId)
                    .HasColumnName("C_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("企业显示编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnName("CREATE_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("IS_ADMIN")
                    .HasColumnType("int(11)")
                    .HasComment("是否管理员,0=否,1=是");

                entity.Property(e => e.LastLoginTime)
                    .HasColumnName("LAST_LOGIN_TIME")
                    .HasColumnType("datetime")
                    .HasComment("上次登录时间");

                entity.Property(e => e.LastLoginToken)
                    .HasColumnName("LAST_LOGIN_TOKEN")
                    .HasColumnType("varchar(36)")
                    .HasComment("上次登录凭证")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnName("LAST_UPDATE_TIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("最近更新时间");

                entity.Property(e => e.LaunchrId)
                    .HasColumnName("LAUNCHR_ID")
                    .HasColumnType("bigint(20)")
                    .HasComment("Launchr id");

                entity.Property(e => e.Power)
                    .HasColumnName("POWER")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'")
                    .HasComment("权限表（1整理层2领导3普通用户4项目干系人）项目干系人只在特殊接口里才出现，这里不设置");

                entity.Property(e => e.ShowId)
                    .IsRequired()
                    .HasColumnName("SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("显示ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UAddress)
                    .HasColumnName("U_ADDRESS")
                    .HasColumnType("varchar(500)")
                    .HasComment("办公地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UHira)
                    .HasColumnName("U_HIRA")
                    .HasColumnType("varchar(10)")
                    .HasComment("用户日文片假名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UIsIn)
                    .HasColumnName("U_IS_IN")
                    .HasColumnType("int(11)")
                    .HasComment("白名单，用户等级，1级最低，2级最高");

                entity.Property(e => e.UIsShow)
                    .HasColumnName("U_IS_SHOW")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否特殊显示（0=否，1=是）");

                entity.Property(e => e.UJob)
                    .HasColumnName("U_JOB")
                    .HasColumnType("varchar(200)")
                    .HasComment("职位")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ULanguage)
                    .HasColumnName("U_LANGUAGE")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户选择的默认语言")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ULoginName)
                    .HasColumnName("U_LOGIN_NAME")
                    .HasColumnType("varchar(100)")
                    .HasComment("第三方登录名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UMail)
                    .HasColumnName("U_MAIL")
                    .HasColumnType("varchar(200)")
                    .HasComment("邮箱")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UMobile)
                    .HasColumnName("U_MOBILE")
                    .HasColumnType("varchar(50)")
                    .HasComment("手机号码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UName)
                    .HasColumnName("U_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UNumber)
                    .HasColumnName("U_NUMBER")
                    .HasColumnType("varchar(50)")
                    .HasComment("工号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UPasswoed)
                    .HasColumnName("U_PASSWOED")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户密码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.USign)
                    .HasColumnName("U_SIGN")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否隐藏，0-否，1-是");

                entity.Property(e => e.USort)
                    .HasColumnName("U_SORT")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("排序号,越小排在越前面");

                entity.Property(e => e.UState)
                    .HasColumnName("U_STATE")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("用户登陆状态，-1-离线，0-离开，1-在线");

                entity.Property(e => e.UStatus)
                    .HasColumnName("U_STATUS")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户状态,0=不可用(锁定),1=可用");

                entity.Property(e => e.UTelephone)
                    .HasColumnName("U_TELEPHONE")
                    .HasColumnType("varchar(30)")
                    .HasComment("办公室电话号码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UTrueName)
                    .HasColumnName("U_TRUE_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UTrueNameAc)
                    .HasColumnName("U_TRUE_NAME_AC")
                    .HasColumnType("varchar(255)")
                    .HasComment("首字母缩写")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UTrueNameC)
                    .HasColumnName("U_TRUE_NAME_C")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户姓名首字母")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<TRegUserDept>(entity =>
            {
                entity.ToTable("t_reg_user_dept");

                entity.HasComment("企业用户部门表");

                entity.HasIndex(e => e.UName)
                    .HasName("AK_Key_2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .HasComment("记录ID");

                entity.Property(e => e.CShowId)
                    .HasColumnName("C_SHOW_ID")
                    .HasColumnType("varchar(50)")
                    .HasComment("企业显示编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("CREATE_TIME")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnName("CREATE_USER_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IsMain)
                    .HasColumnName("IS_MAIN")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("是否主部门,0=否,1=是");

                entity.Property(e => e.UDeptId)
                    .HasColumnName("U_DEPT_ID")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("所属部门")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UDeptSort)
                    .HasColumnName("U_DEPT_SORT")
                    .HasColumnType("int(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("用户在该组织架构中的排序,越小排越前,默认为0");

                entity.Property(e => e.UName)
                    .HasColumnName("U_NAME")
                    .HasColumnType("varchar(50)")
                    .HasComment("用户名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Tempab>(entity =>
            {
                entity.ToTable("tempab");

                entity.HasComment("审批配置表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号id");

                entity.Property(e => e.GmtCreate)
                    .HasColumnName("gmtCreate")
                    .HasColumnType("bigint(20)")
                    .HasComment("主动创建");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmtModified")
                    .HasColumnType("bigint(20)")
                    .HasComment("被动更新");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasComment("1 表示删除，0 表示未删除。");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("状态名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(11)")
                    .HasComment("来源 1、call 或者oa 2、主动办 3、三实库 4、其他");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1.是0.不是");
            });

            modelBuilder.Entity<Websocket>(entity =>
            {
                entity.ToTable("websocket");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号id");

                entity.Property(e => e.Fbid)
                    .HasColumnName("fbid")
                    .HasColumnType("int(11)")
                    .HasComment("反馈id");

                entity.Property(e => e.GmtCreate)
                    .HasColumnName("gmtCreate")
                    .HasColumnType("bigint(20)")
                    .HasComment("主动创建");

                entity.Property(e => e.GmtModified)
                    .HasColumnName("gmtModified")
                    .HasColumnType("bigint(20)")
                    .HasComment("被动更新");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasComment("1 表示删除，0 表示未删除。");

                entity.Property(e => e.IsOnline)
                    .IsRequired()
                    .HasColumnName("isOnline")
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否在线1 表示在线，0 表示离线。");

                entity.Property(e => e.Sessionid)
                    .HasColumnName("sessionid")
                    .HasColumnType("varchar(255)")
                    .HasComment("来源1、主动办2、三实库")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Showid)
                    .HasColumnName("showid")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("1.是0.不是")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

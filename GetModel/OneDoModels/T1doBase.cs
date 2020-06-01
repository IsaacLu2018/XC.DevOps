using System;
using System.Collections.Generic;

namespace GetModel.OneDoModels
{
    public partial class T1doBase
    {
        public string ShowId { get; set; }
        public int Id { get; set; }
        public string ParentId { get; set; }
        public string OTitle { get; set; }
        public string ODescribe { get; set; }
        public string OCustomer { get; set; }
        public string OCustomerName { get; set; }
        public DateTime? OStartTime { get; set; }
        public string CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? OCreateTime { get; set; }
        public DateTime? OFinishTime { get; set; }
        public DateTime? RealFinishTime { get; set; }
        public string ORange { get; set; }
        public string ORangeName { get; set; }
        public DateTime? LastupdateTime { get; set; }
        public int OIsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DShowId { get; set; }
        public string OTypeId { get; set; }
        public string MessageId { get; set; }
        public string Groupid { get; set; }
        public string OExecutor { get; set; }
        public string OExecutorName { get; set; }
        public string Cc { get; set; }
        public string CcName { get; set; }
        public int? Islook { get; set; }
        public int? Type { get; set; }
        public int? UserType { get; set; }
        public int? Isaudit { get; set; }
        public int? Star { get; set; }
        public string Evaluation { get; set; }
        public long? SendTime { get; set; }
        public string At { get; set; }
        public int? Source { get; set; }
        public int? Aparameter { get; set; }
        public int? Bparameter { get; set; }
        public int? Cparameter { get; set; }
        public int? Dparameter { get; set; }
        public bool? Isapproval { get; set; }
        public int? OStatus { get; set; }
        public int? Looknum { get; set; }
        public int? Fbnum { get; set; }
        public int? Lightning { get; set; }
        public string Urgename { get; set; }
        public string Urgeshowid { get; set; }
        public string Base { get; set; }
        public int? Similarity { get; set; }
        public string LookUser { get; set; }
        public string OHandle { get; set; }
        public string OHandleName { get; set; }
        public int? FeedbackSimilarity { get; set; }
        public int? RecordSimilarity { get; set; }
        public string Address { get; set; }
        public string EventId { get; set; }
        public string CommandPlatformId { get; set; }
        public bool? IsSuccess { get; set; }
        public string Module { get; set; }
        public string Street { get; set; }
        public string WechatGroupName { get; set; }
        public bool? IsBindingWechatGroup { get; set; }
        public string WechatGroupId { get; set; }
    }
}

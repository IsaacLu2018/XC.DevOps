using System.Collections.Generic;

namespace XC.DevOps.Common
{
    public class CommonEnumable
    {
        /// <summary>
        ///  维护一个状态字典
        /// </summary>
        public static Dictionary<string, string> stateDic = new Dictionary<string, string>()
        {
            {"newproject","新建"},
            {"inprogress","进行中"},
            {"stop","暂停"},
            {"analyzing","需求调研分析"},
            {"testing","测试中"},
            {"designing","设计中"},
            {"running","运行维护"},
            {"done","完成"},
            {"archive","归档"},
            {"abandon","项目取消"},
        };

    }
}

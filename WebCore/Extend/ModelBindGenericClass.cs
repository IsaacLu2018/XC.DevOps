using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XC.DevOps.Extend
{
    public static class ModelBindGenericClass<T_sender, T_rcver>
    {
        /// <summary>
        /// req实例赋值给DB实例
        /// </summary>
        /// <param name="list">数据库返回的list</param>
        /// <returns></returns>
        public static void ModelBind(T_sender sender, T_rcver rcver)
        {
            if (sender == null || rcver == null) return;
            Type reqType = sender.GetType();
            Type dblistType = rcver.GetType();
            var reqType_properties = reqType.GetProperties();
            var dblist_properties = dblistType.GetProperties();
            foreach (var senderp in reqType_properties)
            {
                if (senderp.GetValue(sender) == null) continue;
                foreach (var rcverp in dblist_properties)
                    if (senderp.Name.ToLower() == rcverp.Name.ToLower())
                    {
                        rcverp.SetValue(rcver, senderp.GetValue(sender));
                    }
            }

        }
    }
}

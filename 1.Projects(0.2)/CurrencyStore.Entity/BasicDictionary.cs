using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public partial class BasicDictionary
    {
        public enum DictKindEnum
        {
            DeviceKind = 1,
            DeviceModel = 2,
            CurrencyKind = 3,
            CurrencyType = 4,
            BusinessType = 5,
            PortNumber = 6
        }
        /// <summary>
        /// ����
        /// </summary>
        public int PkId { get; set; }
        /// <summary>
        /// �ֵ��������1-�豸���2-�豸�ͺţ�3-ֽ�����࣬4-ֽ�����ͣ�5-ҵ�����ͣ�6-���ں���
        /// </summary>
        public byte DictKind { get; set; }
        /// <summary>
        /// �ֵ����ݼ�
        /// </summary>
        public byte DictKey { get; set; }
        /// <summary>
        /// �ֵ�����ֵ
        /// </summary>
        public string DictValue { get; set; }
        /// <summary>
        /// �Ƿ�ϵͳ�ֵ䣬0-��ϵͳ������1-ϵͳ����
        /// </summary>
        public byte IsSystem { get; set; }
    }
}

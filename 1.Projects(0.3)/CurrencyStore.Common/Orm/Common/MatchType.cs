
namespace CurrencyStore.Common.Orm.Common
{
    public enum MatchType
    {
        /// <summary>
        /// 等于
        /// </summary>
        Equal,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual,
        /// <summary>
        /// 恒等于
        /// </summary>
        AlwaysEqual,
        /// <summary>
        /// 包含
        /// </summary>
        /// In,
        /// <summary>
        /// 不包含
        /// </summary>
        /// NotIn,
        /// <summary>
        /// 之间取值
        /// </summary>
        /// Between,
        /// <summary>
        /// 模糊匹配
        /// </summary>
        Like,
        /// <summary>
        /// 模糊否匹配
        /// </summary>
        NotLike,
        /// <summary>
        /// 大于
        /// </summary>
        BigThan,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan,
        /// <summary>
        /// 大于或等于
        /// </summary>
        BigEqualThan,
        /// <summary>
        /// 小于或等于
        /// </summary>
        LessEqualThan,
        /// <summary>
        /// 空
        /// </summary>
        IsNull,
        /// <summary>
        /// 非空
        /// </summary>
        IsNotNull
    }
}

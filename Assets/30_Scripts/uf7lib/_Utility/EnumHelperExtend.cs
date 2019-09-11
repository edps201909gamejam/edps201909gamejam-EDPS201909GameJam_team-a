using System;
using System.ComponentModel;

namespace uf7lib
{
    /// <summary>
    /// Enumの要素に付属したDescriptionを取り出す拡張メソッドを実装するクラス by flanny7
    /// http://www.luispedrofonseca.com/unity-quick-tips-enum-description-extension-method
    /// </summary>
    public static class EnumsHelperExtension
    {
        /// <summary>
        /// 要素に付属したDescriptionを取り出す by flanny7
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Descriptionの文字列</returns>
        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }
}
using uf7lib.DP;
using UnityEngine;
using UnityEngine.UI;

namespace uf7lib
{
    /// <summary>
    /// uGUIのTextにデバッグ用の文字列を表示させるクラス by flanny7
    /// </summary>
    public sealed class DebugText : SingletonMonoBehaviour<DebugText>
    {
        #region SerializeField
        [SerializeField]
        private Text uGuiText = null;
        #endregion

        #region Private Propaty
        private string Text { get => this.uGuiText.text; set => this.uGuiText.text = value; }
        #endregion

        /// <summary>
        /// 初期化関数 by flanny7
        /// </summary>
        protected override void OnInitialize()
        {
            if (this.uGuiText is null)
            {
                this.uGuiText = this.GetComponent<Text>();
            }

			if (this.uGuiText is null) { Debug.LogWarning("uGuiText is null."); }
        }

        /// <summary>
        /// テキストを追加する by flanny7
        /// </summary>
        /// <param name="_str">追加する文字列</param>
        /// <param name="_color">文字の色</param>
        public void AddText(object _str, string _color = "")
        {
            var tmp = this.Text;
            var str = (_color == string.Empty) ? _str : "<color=" + _color + ">" + _str + "</color>";
            this.Text = (tmp == string.Empty) ? str.ToString() : str + "\n" + tmp;
        }

        /// <summary>
        /// テキストを追加してDebug.Logする by flanny
        /// </summary>
        /// <param name="_str">追加する文字列</param>
        /// <param name="_color">文字の色</param>
        public void AddDebugText(object _str, string _color = "")
        {
            var str = (_color == string.Empty) ? _str : "<color=" + _color + ">" + _str + "</color>";
            this.AddText(_str);
            Debug.Log(_str);
        }

        /// <summary>
        /// テキストをすべて消す by flanny7
        /// </summary>
        public void Clear()
        {
            this.Text = string.Empty;
        }
    }
}
using UnityEngine;

namespace uf7lib
{
    public abstract class AbstractState : ScriptableObject, IStateable
    {
        [SerializeField]
        private bool isDebug = false;

		/// <summary>
		/// 初期化関数 by flanny7
		/// </summary>
        public void SubStart()
        {
            this.DebugLog(this.name + ": SubStart.");
            this.OnSubStart();
        }

		/// <summary>
		/// 更新関数 by flanny7
		/// </summary>
        public void SubUpdate()
        {
            this.DebugLog(this.name + ": SubUpdate.");
            this.OnSubUpdate();
        }

		/// <summary>
		/// 破棄処理 by flanny7
		/// </summary>
        public void SubEnd()
        {
            this.DebugLog(this.name + ": SubEnd.");
            this.OnSubEnd();
        }

		/// <summary>
		/// デバッグ用のテキスト出力関数 by flanny7
		/// </summary>
		/// <param name="_message"></param>
		/// <param name="_context"></param>
        protected void DebugLog(object _message, Object _context = null)
        {
            if (this.isDebug)
            {
                if (_context is null) { Debug.Log(_message); }
                else { Debug.Log(_message, _context); }
            }
        }

        protected abstract void OnSubStart();
        protected abstract void OnSubUpdate();
        protected abstract void OnSubEnd();
    }
}
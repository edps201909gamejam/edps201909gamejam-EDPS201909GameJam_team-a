using System.Collections.Generic;

namespace uf7lib
{
    public sealed class StateManager<T> : AbstractManager, IManageable
    {
        private Dictionary<T, IStateable> stateTable = null;

        public bool IsEmpty { get => this.CurrentState is null; }
        public T CurrentStateKey { get; private set; }
        public IStateable CurrentState { get; private set; } = null;

		/// <summary>
		/// ステートの追加 by flanny7
		/// </summary>
		/// <param name="_key">ステートを表すキー</param>
		/// <param name="_state">ステート</param>
        public void Add(T _key, IStateable _state)
        {
            this.stateTable.Add(_key, _state);
        }

		/// <summary>
		/// 初期化処理 by flanny7
		/// </summary>
        protected override void OnSubStart()
		{
			this.stateTable = new Dictionary<T, IStateable>();
			this.CurrentState = null;
        }

		/// <summary>
		/// 更新処理 by flanny7
		/// </summary>
        protected override void OnSubUpdate()
        {
            if (this.IsEmpty) { return; }

            this.CurrentState.SubUpdate();
        }

		/// <summary>
		/// 破棄処理 by flanny7
		/// </summary>
        protected override void OnSubEnd()
        {
        }

		/// <summary>
		/// ステートを切り替える by flanny7
		/// </summary>
		/// <param name="_key"></param>
        public void Change(T _key)
        {
            if (!this.IsEmpty)
            {
                this.CurrentState.SubEnd();
            }

            this.CurrentStateKey = _key;
            this.CurrentState = this.stateTable[_key];
            this.CurrentState.SubStart();
        }

		/// <summary>
		/// ステートをすべて破棄する by flanny7
		/// </summary>
        public void Clear()
        {
            this.stateTable.Clear();
            this.CurrentState = null;
        }
	}
}
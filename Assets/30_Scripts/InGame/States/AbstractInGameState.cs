using uf7lib;
using UnityEngine;

namespace InGame
{
	public abstract class AbstractInGameState : IStateable
	{
		protected InGameStateChange Change = null;
		protected bool IsDebug { get; private set; } = false;
		private bool isStart = false;

		public AbstractInGameState(InGameStateChange _change, bool _isDebug = false)
		{
			this.Change = _change;
			this.IsDebug = _isDebug;
		}

		/// <summary>
		/// 初期化処理 by flanny7
		/// </summary>
		public void SubStart()
		{
			if (this.IsDebug)
			{
				DebugText.Inst.AddDebugText(this.GetType().Name + ": Start.");
			}

			this.OnSubStart();

			this.isStart = true;
		}

		/// <summary>
		/// 更新処理 by flanny7
		/// </summary>
		public void SubUpdate()
		{
			// シールド by flanny7
			if (this.isStart is false)
			{
				DebugText.Inst.AddDebugText(this.GetType().Name + ": is Not Start!!", "red");
				Debug.Break();
				return;
			}

			if (this.IsDebug)
			{
				DebugText.Inst.AddDebugText(this.GetType().Name + ": Update.");
			}

			this.OnSubUpdate();
		}

		/// <summary>
		/// 破棄処理 by flanny7
		/// </summary>
		public void SubEnd()
		{
			if (this.IsDebug)
			{
				DebugText.Inst.AddDebugText(this.GetType().Name + ": End.");
			}

			this.OnSubEnd();
		}

		protected abstract void OnSubStart();
		protected abstract void OnSubUpdate();
		protected abstract void OnSubEnd();
	}
}
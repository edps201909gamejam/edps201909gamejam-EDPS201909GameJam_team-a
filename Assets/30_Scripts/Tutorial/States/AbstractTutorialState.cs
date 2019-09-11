using uf7lib;
using UnityEngine;

namespace Tutorial
{
	public abstract class AbstractTutorialState : IStateable
	{
		protected TutorialStateChange Change = null;
		private bool isDebug = false;
		private bool isStart = false;

		public AbstractTutorialState(TutorialStateChange _change, bool _isDebug = false)
		{
			this.Change = _change;
			this.isDebug = _isDebug;
		}

		/// <summary>
		/// 初期化処理 by flanny7
		/// </summary>
		public void SubStart()
		{
			if (this.isDebug)
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

			if (this.isDebug)
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
			if (this.isDebug)
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
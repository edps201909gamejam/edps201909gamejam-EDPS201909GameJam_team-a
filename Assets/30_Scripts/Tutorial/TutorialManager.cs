using uf7lib;
using uf7lib.DP;
using UnityEngine;

namespace Tutorial
{
	public sealed class TutorialManager : SingletonMonoBehaviour<TutorialManager>
	{
		[SerializeField]
		private TutorialStateManager stateManager = null;

		protected override void OnInitialize()
		{
			// Nullチェック by flanny7
			if (this.stateManager is null)
			{
				DebugText.Inst.AddDebugText("StateManager is null!!", "red");
				Debug.Break();
			}

			// 初期化 by flanny7
			this.stateManager.SubStart();
		}

		private void Update()
		{
			this.stateManager.SubUpdate();
		}
	}
}
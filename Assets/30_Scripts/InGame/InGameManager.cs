using uf7lib;
using uf7lib.DP;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGame
{
	public sealed class InGameManager : SingletonMonoBehaviour<InGameManager>, ILoadSceneable
	{
		[SerializeField]
		private InGameStateManager stateManager = null;

		public void LoadScene(string _sceneName)
		{
			SceneManager.LoadScene(_sceneName);
		}

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
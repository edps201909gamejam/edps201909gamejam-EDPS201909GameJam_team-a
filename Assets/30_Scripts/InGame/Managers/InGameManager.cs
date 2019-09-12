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
		[SerializeField]
		private MaoManager maoManager = null;
		[SerializeField]
		private BraverManager braverManager = null;
		[SerializeField]
		private MonsterManager monsterManager = null;
		[SerializeField]
		private GateManager gateManager = null;
		[SerializeField]
		private CrystalManager crystalManager = null;
		[SerializeField]
		private StatueManager statueManager = null;

		public MaoManager MaoManager { get => this.maoManager; }
		public BraverManager BraverManager { get => this.braverManager; }
		public MonsterManager MonsterManager { get => this.monsterManager; }
		public GateManager GateManager { get => this.gateManager; }
		public CrystalManager CrystalManager { get => this.crystalManager; }
		public StatueManager StatueManager { get => this.StatueManager; }

		public void LoadScene(string _sceneName)
		{
			SceneManager.LoadScene(_sceneName);
		}

		protected override void OnInitialize()
		{
			// Nullチェック by flanny7
			this.NullCheck(this.stateManager);
			this.NullCheck(this.maoManager);
			this.NullCheck(this.braverManager);
			this.NullCheck(this.monsterManager);
			this.NullCheck(this.gateManager);
			this.NullCheck(this.crystalManager);
			this.NullCheck(this.statueManager);

			// 初期化 by flanny7
			this.stateManager.SubStart();
		}

		private void Update()
		{
			this.stateManager.SubUpdate();
		}

		private void NullCheck(Object _obj)
		{
			if (_obj is null)
			{
				DebugText.Inst.AddDebugText(_obj.name + " is null!!", "red");
				Debug.Break();
			}
		}
	}
}
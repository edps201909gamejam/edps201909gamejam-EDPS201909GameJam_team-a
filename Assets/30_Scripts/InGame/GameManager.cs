using uf7lib.DP;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace InGame
{
	public sealed class GameManager : SingletonMonoBehaviour<GameManager>
	{
		[SerializeField]
		private MaoManager mao;
		[SerializeField]
		private BraveManager brave;
		[SerializeField]
		private StatueManager[] statues;
		[SerializeField]
		private CrystalManager[] crystals;
		[SerializeField]
		private MonsterPool[] monsterPools;
		[Space(8)]
		[SerializeField]
		private HitPoint gateHP;
		[SerializeField]
		private Gage3DUI gateGage;
		[SerializeField]
		private CanvasGroup maowin;
		[SerializeField]
		private CanvasGroup bravewin;
		[SerializeField]
		private Axes pl1ok;
		[SerializeField]
		private KeyCode pl1okkey;
		[SerializeField]
		private Axes pl2ok;
		[SerializeField]
		private KeyCode pl2okkey;
		[SerializeField]
		private string titleSceneName;

		private bool maoPhaseTrigger = false;
		private bool finished = false;

		public bool IsOpenGate { get => this.gateHP.Rate <= 0; }

		protected override void OnInitialize()
		{
		}

		private bool GetButtonDownOK()
		{
			return InputController.Inst.GetButtonDown(this.pl1ok) ||
				   InputController.Inst.GetButtonDown(this.pl2ok) ||
				   Input.GetKeyDown(this.pl1okkey) ||
				   Input.GetKeyDown(this.pl2okkey);
		}

		private void Update()
		{

			this.gateGage.SetRate(gateHP.Rate);
			if (TimeManager.Inst.MaoTimePhase)
			{
				this.BraveFrieze();
				return;
			}

			if (!this.maoPhaseTrigger)
			{
				this.maoPhaseTrigger = true;
				this.UnFrieze();
			}

			if (TimeManager.Inst.IsFinished)
			{
				this.Finised(false);
			}

			if (this.finished)
			{
				if (GetButtonDownOK()) { SceneManager.LoadScene(this.titleSceneName); }
			}
		}

		public void Finised(bool _winMao)
		{
			if (_winMao)
			{
				this.maowin.alpha = 1;
			}
			else
			{
				this.bravewin.alpha = 1;
			}

			this.finished = true;
		}

		public void BraveFrieze()
		{
			this.brave.Frieze();
			for (var i = 0; i < this.statues.Length; ++i) { this.statues[i].Frieze(); }
		}

		public void Frieze()
		{
			this.mao.Frieze();
			this.brave.Frieze();
			for (var i = 0; i < this.statues.Length; ++i) { this.statues[i].Frieze(); }
			for (var i = 0; i < this.crystals.Length; ++i) { this.crystals[i].Frieze(); }
			for (var i = 0; i < this.monsterPools.Length; ++i) { this.monsterPools[i].Frieze(); }
		}

		public void UnFrieze()
		{
			this.mao.UnFrieze();
			this.brave.UnFrieze();
			for (var i = 0; i < this.statues.Length; ++i) { this.statues[i].UnFrieze(); }
			for (var i = 0; i < this.crystals.Length; ++i) { this.crystals[i].UnFrieze(); }
			for (var i = 0; i < this.monsterPools.Length; ++i) { this.monsterPools[i].UnFrieze(); }
		}

		public void GageCharge(float _value)
		{
			this.gateHP.Damage(_value);
			this.gateGage.SetRate(gateHP.Rate);
		}
	}
}
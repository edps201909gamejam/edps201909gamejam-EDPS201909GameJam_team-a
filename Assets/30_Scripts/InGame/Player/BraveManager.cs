using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(HitPoint))]
	[RequireComponent(typeof(MagicPoint))]
	[RequireComponent(typeof(ControllerMover))]
	[RequireComponent(typeof(ReSpawner))]
	[RequireComponent(typeof(Attacker))]
	public sealed class BraveManager : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private Gage3DUI hitPointGage = null;
		[SerializeField]
		private Gage3DUI magicPointGage = null;

		private HitPoint hitPoint = null;
		private MagicPoint magicPoint = null;
		private ControllerMover mover = null;
		private ReSpawner respawner = null;
		private Attacker attacker = null;

		private void Start()
		{
			if (this.hitPointGage is null) { Debug.LogError("hitPointGage is null.", this); }
			if (this.magicPointGage is null) { Debug.LogError("magicPointGage is null.", this); }
			// GetComponents
			this.hitPoint = GetComponent<HitPoint>();
			this.magicPoint = GetComponent<MagicPoint>();
			this.mover = GetComponent<ControllerMover>();
			this.respawner = GetComponent<ReSpawner>();
			this.attacker = GetComponent<Attacker>();

			// Initialize
			this.hitPointGage.SetRate(this.hitPoint.Rate);
			this.magicPoint.Damage(int.MaxValue);
			this.magicPointGage.SetRate(this.magicPoint.Rate);
			this.respawner.Initialize(this.Restart);
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			// update gage
			this.hitPointGage.SetRate(this.hitPoint.Rate);
			this.magicPointGage.SetRate(this.magicPoint.Rate);

			if (this.hitPoint.IsDead)
			{
				this.respawner.ReSpawn();
			}
		}

		private void Restart()
		{
			this.hitPoint.Heal(int.MaxValue);
			this.hitPointGage.SetRate(this.hitPoint.Rate);
		}

		private void Frieze()
		{
			this.hitPoint.SetActiveComponent(false);
			this.magicPoint.SetActiveComponent(false);
			this.mover.SetActiveComponent(false);
			this.attacker.SetActiveComponent(false);
		}

		private void UnFrieze()
		{
			this.hitPoint.SetActiveComponent(true);
			this.magicPoint.SetActiveComponent(true);
			this.mover.SetActiveComponent(true);
			this.attacker.SetActiveComponent(true);
		}
	}
}
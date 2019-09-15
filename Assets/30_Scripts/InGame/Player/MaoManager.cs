using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(HitPoint))]
	[RequireComponent(typeof(MagicPoint))]
	[RequireComponent(typeof(ControllerMover))]
	[RequireComponent(typeof(ControllerSkiller))]
	[RequireComponent(typeof(Attacker))]
	[RequireComponent(typeof(MPHealer))]
	public sealed class MaoManager : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private GameObject crystalPrefab4Skill = null;

		private HitPoint hitPoint = null;
		private MagicPoint magicPoint = null;
		private ControllerMover mover = null;
		private ControllerSkiller skiller = null;
		private Attacker attacker = null;
		private MPHealer healer = null;

		private void Start()
		{
			// GetComponents
			this.hitPoint = GetComponent<HitPoint>();
			this.magicPoint = GetComponent<MagicPoint>();
			this.mover = GetComponent<ControllerMover>();
			this.skiller = GetComponent<ControllerSkiller>();
			this.attacker = GetComponent<Attacker>();
			this.healer = GetComponent<MPHealer>();

			// Initialize
			this.skiller.SetSkill(this.Skill);
			this.magicPoint.Heal(int.MaxValue);
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			if (this.hitPoint.IsDead)
			{
				GameManager.Inst.Finised(false);
			}
		}

		private void Skill()
		{
			Instantiate(crystalPrefab4Skill);
		}

		public void Frieze()
		{
			this.hitPoint.SetActiveComponent(false);
			this.magicPoint.SetActiveComponent(false);
			this.mover.SetActiveComponent(false);
			this.skiller.SetActiveComponent(false);
			this.attacker.SetActiveComponent(false);
			this.healer.SetActiveComponent(false);
		}

		public void UnFrieze()
		{
			this.hitPoint.SetActiveComponent(true);
			this.magicPoint.SetActiveComponent(true);
			this.mover.SetActiveComponent(true);
			this.skiller.SetActiveComponent(true);
			this.attacker.SetActiveComponent(true);
			this.healer.SetActiveComponent(true);
		}
	}
}
using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(HitPoint))]
	[RequireComponent(typeof(MagicPoint))]
	[RequireComponent(typeof(MonsterFactory))]
	public sealed class CrystalManager : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private SpriteRenderer magickCircleSpriteRender = null;
		[SerializeField]
		private Gage3DUI hitPointGage = null;
		[SerializeField]
		private Gage3DUI magicPointGage = null;
		[SerializeField]
		private bool isFullMPStart = false;

		private HitPoint hitPoint = null;
		private MagicPoint magicPoint = null;
		private MonsterFactory factory = null;

		private bool canGenerateMonster = false;

		private void Start()
		{
			if (this.magickCircleSpriteRender is null) { Debug.LogError("magickCircleImage is null.", this); }
			if (this.hitPointGage is null) { Debug.LogError("hitPointGage is null.", this); }
			if (this.magicPointGage is null) { Debug.LogError("magicPointGage is null.", this); }
			// GetComponents
			this.hitPoint = GetComponent<HitPoint>();
			this.magicPoint = GetComponent<MagicPoint>();
			this.factory = GetComponent<MonsterFactory>();

			// Initialize
			this.hitPointGage.SetRate(this.hitPoint.Rate);
			if (this.isFullMPStart) { this.magicPoint.Heal(int.MaxValue, false); }
			else { this.magicPoint.Damage(int.MaxValue, false); }
			this.magicPointGage.SetRate(this.magicPoint.Rate);

			this.magickCircleSpriteRender.enabled = false;
			this.hitPoint.SetActiveComponent(false);
			this.factory.SetActiveComponent(false);
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			// update gage
			this.hitPointGage.SetRate(this.hitPoint.Rate);
			this.magicPointGage.SetRate(this.magicPoint.Rate);

			Debug.Log("C: " + this.hitPoint.Value);
			Debug.Log("C: " + this.magicPoint.Value);

			if (this.canGenerateMonster)
			{

				if (this.hitPoint.IsDead) { this.DestroyCrystal(); }
			}
			else
			{
				this.canGenerateMonster = this.magicPoint.IsFull;
				if (this.canGenerateMonster)
				{
					this.magickCircleSpriteRender.enabled = true;
					this.hitPoint.SetActiveComponent(true);
					this.magicPoint.SetActiveComponent(false);
					this.factory.SetActiveComponent(true);
					return;
				}
			}
		}

		private void DestroyCrystal()
		{
			GameObject.FindGameObjectWithTag("Braver").GetComponent<MagicPoint>().Heal(1);
			Destroy(this.gameObject);
		}

		public void Frieze()
		{
			this.hitPoint.SetActiveComponent(false);
			this.magicPoint.SetActiveComponent(false);
			this.factory.SetActiveComponent(false);
		}

		public void UnFrieze()
		{
			this.hitPoint.SetActiveComponent(this.canGenerateMonster);
			this.magicPoint.SetActiveComponent(!this.canGenerateMonster);
			this.factory.SetActiveComponent(this.canGenerateMonster);
		}
	}
}
using UnityEngine;
using UnityEngine.AI;

namespace InGame
{
	[RequireComponent(typeof(HitPoint))]
	[RequireComponent(typeof(Attacker))]
	[RequireComponent(typeof(NavMeshAgent))]
	public sealed class MonsterManager : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private Gage3DUI hitPointGage = null;
		[SerializeField]
		private float braverMinDistance = 0.3f;

		private HitPoint hitPoint = null;
		private Attacker attacker = null;
		private NavMeshAgent agent = null;
		private MonsterPool pool = null;
		private Transform braverTrans = null;

		public void SetPool(MonsterPool _pool) { this.pool = _pool; }

		public void Frieze()
		{
			this.hitPoint.SetActiveComponent(false);
			this.attacker.SetActiveComponent(false);
		}

		public void UnFrieze()
		{
			this.hitPoint.SetActiveComponent(true);
			this.attacker.SetActiveComponent(true);
		}

		private void Start()
		{
			if (this.hitPointGage is null) { Debug.LogError("hitPointGage is null.", this); }
			// GetComponents
			this.hitPoint = GetComponent<HitPoint>();
			this.attacker = GetComponent<Attacker>();
			this.agent = GetComponent<NavMeshAgent>();

			this.braverTrans = GameObject.FindGameObjectWithTag("Braver").transform;

			// Initialize
			this.hitPointGage.SetRate(this.hitPoint.Rate);
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			// update gage
			this.hitPointGage.SetRate(this.hitPoint.Rate);

			this.Move();

			if (this.hitPoint.IsDead)
			{
				this.pool.Remove(this);
			}
		}

		private void Move()
		{
			this.agent.destination = this.braverTrans.position;
			if (this.agent.remainingDistance <= this.braverMinDistance)
			{
				var aim = this.braverTrans.position - this.transform.position;
				var look = Quaternion.LookRotation(aim);
				this.transform.localRotation = look;
			}
		}
	}
}
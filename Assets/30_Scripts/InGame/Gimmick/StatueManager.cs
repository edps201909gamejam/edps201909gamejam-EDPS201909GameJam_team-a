using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(HitPoint))]
	public sealed class StatueManager : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private Gage3DUI gage = null;

		private HitPoint hitPoint = null;

		private void Start()
		{
			if (this.gage is null) { Debug.LogError("Gage3DUI is null.", this); }
			this.hitPoint = GetComponent<HitPoint>();
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			if (this.hitPoint.IsDead)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
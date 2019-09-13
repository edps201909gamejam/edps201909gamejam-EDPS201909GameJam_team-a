using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class FHpGauge : AbstractManagerBehaviour
	{
		[SerializeField]
		private Vector3 rotate;

		private void Start()
		{
			this.SubStart();
		}

		private void Update()
		{
			this.SubUpdate();
		}

		protected override void OnSubStart()
		{
			this.transform.Rotate(this.rotate, Space.World);
		}

		protected override void OnSubUpdate()
		{
		}

		protected override void OnSubEnd()
		{
		}
	}
}
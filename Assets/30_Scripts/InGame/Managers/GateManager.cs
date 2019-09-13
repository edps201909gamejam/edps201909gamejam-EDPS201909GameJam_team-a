using uf7lib;
using UnityEngine;

namespace InGame
{
	public class GateManager : AbstractManagerBehaviour
	{
		[SerializeField]
		private FGateArea gateArea = null;

		protected override void OnSubStart()
		{
			if (this.gateArea is null) { Debug.LogError("gateArea is null."); }

			this.gateArea.SubStart();
		}

		protected override void OnSubUpdate()
		{
			this.gateArea.SubUpdate();
		}

		protected override void OnSubEnd()
		{
			this.gateArea.SubEnd();
		}
	}
}
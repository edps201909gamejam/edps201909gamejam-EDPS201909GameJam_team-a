using UnityEngine;

namespace InGame
{
	public sealed class GateWallManager : MonoBehaviour
	{
		[SerializeField]
		private HitPoint gateHP;

		private void Update()
		{
			if (this.gateHP.Rate <= 0)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
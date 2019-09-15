using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(Collider))]
	public class GateGoalManager : MonoBehaviour
	{
		private void OnCollisionStay(Collision collision)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Mao"))
			{
				GameManager.Inst.Finised(true);
			}
		}
	}
}
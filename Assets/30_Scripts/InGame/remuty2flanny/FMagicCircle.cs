using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class FMagicCircle : AbstractManagerBehaviour
	{
		[SerializeField] GameObject crystal;
		bool create_crystal = false;
		float charge = 5;

		protected override void OnSubStart()
		{
		}

		protected override void OnSubUpdate()
		{
			if (charge <= 0)
			{
				var c = Instantiate(crystal, transform.position, Quaternion.identity);
				InGameManager.Inst.CrystalManager.AddCrystal(c.GetComponent<FCrystal>());
				Destroy(gameObject);
			}
		}

		protected override void OnSubEnd()
		{
		}

		void OnTriggerStay(Collider c)
		{
			if (c.tag == "Mao")
			{
				charge -= Time.deltaTime;
			}
		}
	}
}
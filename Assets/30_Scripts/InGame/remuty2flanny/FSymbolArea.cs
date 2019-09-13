using uf7lib;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
	public sealed class FSymbolArea : AbstractManagerBehaviour
	{
		public GameObject symbol;
		[SerializeField] string joystick_o;
		public GameObject gauge;
		float hp;
		public Status status;

		protected override void OnSubStart()
		{
			hp = status.maxHp;
		}

		protected override void OnSubUpdate()
		{
			GaugeDown(hp, status.maxHp);
			if (hp <= 0)
			{
				Destroy(symbol);
			}
		}

		protected override void OnSubEnd()
		{
		}

		private void OnTriggerStay(Collider c)
		{
			if (c.tag == "Mao")
			{
				if (Input.GetButton(joystick_o))
				{
					hp -= Time.deltaTime;
				}
			}
		}

		void GaugeDown(float current, int max)
		{
			gauge.GetComponent<Image>().fillAmount = current / max;
		}
	}
}
using uf7lib;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
	public sealed class FGateArea : AbstractManagerBehaviour
	{
		float gate_charge;
		public GameObject gate;
		public GameObject gauge;
		[SerializeField] int gate_max = 10;
		[SerializeField] int symbol_count = 2;
		int symbol_destroy;
		[SerializeField] string joystick_o;

		protected override void OnSubStart()
		{
			gate_charge = gate_max;
			symbol_destroy = gate_max / 3;
		}

		protected override void OnSubUpdate()
		{
			if (gate_charge <= 0)
			{
				Destroy(gate);
			}
			GameObject[] symbol = GameObject.FindGameObjectsWithTag("Symbol");
			if (symbol.Length == symbol_count - 1)                  //女神像を破壊するとチャージがたまる
			{
				symbol_count = symbol.Length;
				gate_charge -= symbol_destroy;
			}
			GaugeDown(gate_charge, gate_max);
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
					gate_charge -= Time.deltaTime;
				}
			}
		}

		void GaugeDown(float current, int max)
		{
			gauge.GetComponent<Image>().fillAmount = current / max;
		}
	}
}
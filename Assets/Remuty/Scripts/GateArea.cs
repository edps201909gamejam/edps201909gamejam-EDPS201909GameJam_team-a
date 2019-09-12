using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateArea : MonoBehaviour
{
	float gate_charge;
	public GameObject gate;
	public GameObject gauge;
	[SerializeField] int gate_max = 10;
	[SerializeField] int symbol_count = 2;
	int symbol_destroy;
	[SerializeField] string joystick_o;
	// Start is called before the first frame update
	void Start()
    {
		gate_charge = gate_max;
		symbol_destroy = gate_max / 3;
    }

    // Update is called once per frame
    void Update()
    {
		if (gate_charge <= 0)
		{
			Destroy(gate);
		}
		GameObject[] symbol = GameObject.FindGameObjectsWithTag("Symbol");
		if (symbol.Length == symbol_count - 1)					//女神像を破壊するとチャージがたまる
		{
			symbol_count = symbol.Length;
			gate_charge -= symbol_destroy;
		}
		GaugeDown(gate_charge, gate_max);
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

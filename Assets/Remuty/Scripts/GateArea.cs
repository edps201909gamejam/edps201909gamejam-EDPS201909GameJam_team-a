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
	// Start is called before the first frame update
	void Start()
    {
		gate_charge = gate_max;
    }

    // Update is called once per frame
    void Update()
    {
		if (gate_charge <= 0)
		{
			Destroy(gate);
		}
		GaugeDown(gate_charge, gate_max);
	}

    private void OnTriggerStay(Collider c)
	{
		if (c.tag == "Mao")
		{
			if (Input.GetKey(KeyCode.JoystickButton1))
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

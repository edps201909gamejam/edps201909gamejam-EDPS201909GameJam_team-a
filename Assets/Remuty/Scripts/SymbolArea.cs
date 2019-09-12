using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolArea : MonoBehaviour
{
	public GameObject symbol;
	[SerializeField] float symbol_charge = 5;
	[SerializeField] string joystick_o;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (symbol_charge <= 0)
		{
			Destroy(symbol);
		}
	}

	private void OnTriggerStay(Collider c)
	{
		if (c.tag == "Mao")
		{
			if (Input.GetButton(joystick_o))
			{
				symbol_charge -= Time.deltaTime;
			}
		}
	}
}

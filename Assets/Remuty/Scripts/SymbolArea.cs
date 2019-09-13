using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolArea : MonoBehaviour
{
	public GameObject symbol;
	[SerializeField] string joystick_o;
    public GameObject gauge;
    float hp;
    public Status status;
    // Start is called before the first frame update
    void Start()
    {
        hp = status.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        GaugeDown(hp, status.maxHp);
        if (hp <= 0)
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
				hp -= Time.deltaTime;
			}
		}
	}

    void GaugeDown(float current, int max)
    {
        gauge.GetComponent<Image>().fillAmount = current / max;
    }
}

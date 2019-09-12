using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braver : MonoBehaviour
{
	[SerializeField] string joystick_o;
	Animator animator;
	public Status status;
	float hp;
	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
		hp = status.maxHp;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton(joystick_o))
		{
			animator.SetBool("AttackFlag", true);
		}
		else
		{
			animator.SetBool("AttackFlag", false);
		}
	}

	private void OnCollisionStay(Collision c)
	{
		if (c.gameObject.tag == "Monster")
		{
			
		}
	}
}

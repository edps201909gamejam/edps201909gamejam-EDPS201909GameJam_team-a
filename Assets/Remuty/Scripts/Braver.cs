using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Braver : MonoBehaviour
{
	[SerializeField] string joystick_o,joystick_x;
	public GameObject braver, gauge,skill;
    GameObject respawn;
	Animator animator;
	public Status status;
	float hp,mp;
    public MpCount mp_count;
    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
		hp = status.maxHp;
        respawn = GameObject.FindGameObjectWithTag("Respawn");
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton(joystick_o))			//攻撃
		{
			animator.SetBool("AttackFlag", true);
		}
		else
		{
			animator.SetBool("AttackFlag", false);
		}
        mp = mp_count.GetMp();
		if(mp >= 1)
        {
            if (Input.GetButton(joystick_x))		//スキル
            {
                Instantiate(skill, transform.position, Quaternion.Euler(0,0,0));
            }
        }
        if (hp <= 0)
        {
            Instantiate(braver, respawn.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        GaugeDown(hp, status.maxHp);
    }

	private void OnCollisionStay(Collision c)
	{
		if (c.gameObject.tag == "Monster")
		{
            int monster_atk = c.gameObject.GetComponent<Monster>().status.atk;
            hp -= monster_atk * Time.deltaTime;
		}
    }

    void GaugeDown(float current, int max)
    {
        gauge.GetComponent<Image>().fillAmount = current / max;
    }
}

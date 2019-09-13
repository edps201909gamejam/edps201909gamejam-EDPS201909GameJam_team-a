using uf7lib;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
	public sealed class FBraver : AbstractManagerBehaviour
	{
		[SerializeField]
		private string joystick_o, joystick_x;

		public GameObject braver, gauge, skill;
		GameObject respawn;
		Animator animator;
		public Status status;
		float hp, mp;
		public FMpCount mp_count;

		protected override void OnSubStart()
		{
			animator = GetComponent<Animator>();
			hp = status.maxHp;
			respawn = GameObject.FindGameObjectWithTag("Respawn");
		}

		protected override void OnSubUpdate()
		{
			if (Input.GetButton(joystick_o))            //攻撃
			{
				if (this.animator != null)
				{
					this.animator.SetBool("AttackFlag", true);
				}
			}
			else
			{
				if (this.animator != null)
				{
					this.animator.SetBool("AttackFlag", false);
				}
			}
			mp = mp_count.GetMp();
			if (mp >= 1)
			{
				if (Input.GetButton(joystick_x))        //スキル
				{
					var s = Instantiate(skill, transform.position, Quaternion.Euler(0, 0, 0));
					InGameManager.Inst.BraverManager.AddSkill(s.GetComponent<FBraverSkill>());
				}
			}
			if (hp <= 0)
			{
				var b = Instantiate(braver, respawn.transform.position, Quaternion.identity);
				InGameManager.Inst.BraverManager.ChangeBraver(b.GetComponent<FBraver>());
				Destroy(gameObject);
			}
			GaugeDown(hp, status.maxHp);
		}

		protected override void OnSubEnd()
		{
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
}
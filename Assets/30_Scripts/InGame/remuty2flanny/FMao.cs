using uf7lib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InGame
{
	public sealed class FMao : AbstractManagerBehaviour
	{
		bool stan = false;
		[SerializeField] float stan_time = 5;
		float stan_count;
		[SerializeField] int skill_count = 2;
		[SerializeField] string joystick_x;
		public GameObject crystal;

		protected override void OnSubStart()
		{
		}

		protected override void OnSubUpdate()
		{
			if (stan && stan_count > 0)
			{
				stan_count -= Time.deltaTime;
			}
			if (stan_count <= 0)
			{
				stan = false;
				GetComponent<FPlayer>().enabled = true;
			}
			if (skill_count >= 1)
			{
				if (Input.GetButtonDown(joystick_x))        //スキル
				{
					var c = Instantiate(crystal, transform.position, Quaternion.Euler(0, 0, 0));
					InGameManager.Inst.CrystalManager.AddCrystal(c.GetComponent<FCrystal>());
					skill_count--;
				}
			}
		}

		protected override void OnSubEnd()
		{
		}

		private void OnTriggerEnter(Collider c)
		{
			if (c.tag == "Skill")
			{
				stan_count = stan_time;
				stan = true;
				GetComponent<FPlayer>().enabled = false;
			}
			if (c.tag == "Gate")
			{
				SceneManager.LoadScene("ResultTest");
			}
		}

		private void OnCollisionEnter(Collision c)
		{
			if (c.gameObject.tag == "Braver")
			{
				SceneManager.LoadScene("ResultTest");
			}
		}
	}
}
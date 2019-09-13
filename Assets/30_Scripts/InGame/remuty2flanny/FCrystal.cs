using uf7lib;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
	public sealed class FCrystal : AbstractManagerBehaviour
	{
		[SerializeField] GameObject[] monster;
		float interval = 2;
		public GameObject gauge;
		public float hp;
		public Status status;

		protected override void OnSubStart()
		{
			hp = status.maxHp;
		}

		protected override void OnSubUpdate()
		{
			interval -= Time.deltaTime;
			if (interval <= 0)
			{
				int m = Random.Range(0, monster.Length);
				Instantiate(monster[m], transform.position, Quaternion.identity);
				interval = 2;
			}
			GaugeDown(hp, status.maxHp);
			if (hp <= 0)
			{
				Destroy(gameObject);
			}
		}

		protected override void OnSubEnd()
		{
		}

		private void OnCollisionStay(Collision c)
		{
			if (c.gameObject.tag == "Braver")
			{
				int braver_atk = c.gameObject.GetComponent<FBraver>().status.atk;
				hp -= braver_atk * Time.deltaTime;
			}
		}
		void GaugeDown(float current, int max)
		{
			gauge.GetComponent<Image>().fillAmount = current / max;
		}
	}
}
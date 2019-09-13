using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class FBraverSkill : AbstractManagerBehaviour
	{
		float skill_time = 1;

		protected override void OnSubStart()
		{
		}

		protected override void OnSubUpdate()
		{
			skill_time -= Time.deltaTime;
			if (skill_time <= 0)
			{
				Destroy(gameObject);
			}
		}

		protected override void OnSubEnd()
		{
		}
	}
}
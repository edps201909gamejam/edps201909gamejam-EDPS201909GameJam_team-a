using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class FMpCount : AbstractManagerBehaviour
	{
		int mp = 0;
		public int circle_count;
		int crystal_count = 0;
		bool skill_use = false;

		protected override void OnSubStart()
		{
		}

		protected override void OnSubUpdate()
		{
			Debug.Log(mp);
			GameObject[] magic_circle = GameObject.FindGameObjectsWithTag("MagicCircle");
			if (magic_circle.Length == circle_count - 1)
			{
				circle_count--;
				crystal_count++;
			}
			GameObject[] crystal = GameObject.FindGameObjectsWithTag("Crystal");
			if (crystal.Length == crystal_count + 1)
			{
				crystal_count++;
			}
			if (crystal.Length == crystal_count - 1)
			{
				crystal_count--;
				mp++;
			}
			GameObject[] skill = GameObject.FindGameObjectsWithTag("Skill");
			if (skill.Length > 0 && !skill_use)
			{
				skill_use = true;
				mp--;
			}
			if (skill.Length == 0)
			{
				skill_use = false;
			}
		}

		protected override void OnSubEnd()
		{
		}

		public int GetMp()
		{
			return mp;
		}
	}
}
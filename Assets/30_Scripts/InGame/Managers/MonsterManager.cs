using System.Collections.Generic;
using uf7lib;
using UnityEngine;

namespace InGame
{
	public class MonsterManager : AbstractManagerBehaviour
	{
		private List<FMonster> monsters = null;

		public void AddMonster(FMonster _monster)
		{
			this.monsters.Add(_monster);
			_monster.SubStart();
		}

		protected override void OnSubStart()
		{
			this.monsters = new List<FMonster>();
		}

		protected override void OnSubUpdate()
		{
			for (var i = 0; i < this.monsters.Count; ++i)
			{
				if (this.monsters[i] is null) { continue; }

				this.monsters[i].SubUpdate();
			}
		}

		protected override void OnSubEnd()
		{
			for (var i = 0; i < this.monsters.Count; ++i)
			{
				if (this.monsters[i] is null) { continue; }

				this.monsters[i].SubEnd();
			}
		}
	}
}
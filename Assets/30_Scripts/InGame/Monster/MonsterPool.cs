using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
	public sealed class MonsterPool : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		private List<MonsterManager> monsters = null;

		private void Start()
		{
			this.monsters = new List<MonsterManager>();
		}

		public void Add(MonsterManager _monster)
		{
			this.monsters.Add(_monster);
			_monster.SetPool(this);
		}

		public void Remove(MonsterManager _monster)
		{
			this.monsters.Remove(_monster);
			Destroy(_monster.gameObject);
		}

		public void Frieze()
		{
			for (var i = 0; i < this.monsters.Count; ++i)
			{
				this.monsters[i].SetActiveComponent(false);
			}
		}

		public void UnFrieze()
		{
			for (var i = 0; i < this.monsters.Count; ++i)
			{
				this.monsters[i].SetActiveComponent(true);
			}
		}
	}
}
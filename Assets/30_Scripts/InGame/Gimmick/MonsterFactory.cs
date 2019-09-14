// Remuty/Crystal より生成処理を抜粋 by flanny7

using UnityEngine;

namespace InGame
{
	public sealed class MonsterFactory : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private MonsterPool monsterPool = null;
		[SerializeField]
		private GameObject[] monsterPrefabs = null;
		[SerializeField, Min(1)]
		private int numAtOnce = 1;
		[SerializeField, Min(0.0f)]
		private float intervalTime = 2.0f;

		private Transform trans = null;
		private Transform poolTrans = null;
		private float elapsedTime = 0.0f;

		private void Start()
		{
			if (this.monsterPool is null) { Debug.LogError("monsterPool is null.", this); }
			if ((this.monsterPrefabs is null) || (this.monsterPrefabs.Length <= 0))
				{ Debug.LogError("monsterPrefabs is null or empty.", this); }

			this.trans = this.transform;
			this.poolTrans = this.monsterPool.transform;
			this.elapsedTime = 0.0f;
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			this.elapsedTime += Time.deltaTime;

			if (this.intervalTime <= this.elapsedTime)
			{
				for (var i = 0; i < this.numAtOnce; ++i)
				{
					int m = Random.Range(0, this.monsterPrefabs.Length);
					var tmp = Instantiate(this.monsterPrefabs[m], this.trans.position, Quaternion.identity, this.poolTrans);
					var mm = tmp.GetComponent<MonsterManager>();
					if (mm is null)
					{
						for (var k = 0; k < tmp.transform.childCount; ++k)
						{
							mm = tmp.transform.GetChild(k).GetComponent<MonsterManager>();
							if (mm != null) { this.elapsedTime = 0.0f; break; }
						}
						if (mm is null) { Destroy(tmp); continue; }
					}

					this.monsterPool.Add(mm);
				}
			}
		}
	}
}
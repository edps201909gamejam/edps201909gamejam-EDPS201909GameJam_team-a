using System;
using UnityEngine;

namespace InGame
{
	public sealed class ReSpawner : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private Transform spawnTrans = null;

		private Transform trans = null;
		private bool isInitialized = false;
		private Action restart = null;

		public void Initialize(Action _restart)
		{
			this.restart = _restart;
			this.isInitialized = true;
		}

		public bool ReSpawn()
		{
			if (!this.IsActiveComponent()) { return false; }

			if (!this.isInitialized)
			{
				Debug.LogError("ReSpawner is NOT initialized.", this);
				return false;
			}

			this.trans.position = this.spawnTrans.position;
			this.trans.rotation = Quaternion.identity;
			this.restart();

			return true;
		}

		private void Start()
		{
			this.trans = this.transform;
			this.isInitialized = false;
		}
	}
}
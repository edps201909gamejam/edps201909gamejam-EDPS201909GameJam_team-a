using System;
using UnityEngine;

namespace uf7lib
{
	public class SecondRoutine
	{
		private Action action = null;
		private readonly float intervalTime = 0.0f;
		private float elapsedTime = 0.0f;

		public SecondRoutine(Action _action, float _intervalTime)
		{
			this.action = _action;
			this.intervalTime = _intervalTime;
			this.elapsedTime = 0.0f;
		}

		public bool Update()
		{
			return this.Update(Time.deltaTime);
		}

		public bool Update(float _deltaTime)
		{
			this.elapsedTime += _deltaTime;
			if (this.intervalTime <= this.elapsedTime)
			{
				this.action();
				this.elapsedTime -= this.intervalTime;
				return true;
			}

			return false;
		}
	}
}
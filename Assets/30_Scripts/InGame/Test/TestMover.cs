using UnityEngine;

namespace InGame.Test
{
	public sealed class TestMover : MonoBehaviour
	{
		[System.Serializable]
		public struct Keys
		{
			public KeyCode Up;
			public KeyCode Down;
			public KeyCode Right;
			public KeyCode Left;
		}

		[SerializeField]
		private Keys keys;
		[SerializeField]
		private float speed = .025f;
		[SerializeField]
		private bool isKeyDown = false;

		// this.transformはメンバ変数でcacheした方が高速になる by flanny7
		private Transform trans = null;

		private float Speed { get => this.speed * 60.0f; }

		private void Start()
		{
			this.trans = this.transform;
		}

		private void Update()
		{
			var dt = Time.deltaTime;
			var pos = this.trans.position;

			if (this.isKeyDown)
			{
				if (Input.GetKeyDown(this.keys.Up)) { pos.z += dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Down)) { pos.z -= dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Right)) { pos.x += dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Left)) { pos.x -= dt * this.Speed; }
			}
			else
			{
				if (Input.GetKey(this.keys.Up)) { pos.z += dt * this.Speed; }
				if (Input.GetKey(this.keys.Down)) { pos.z -= dt * this.Speed; }
				if (Input.GetKey(this.keys.Right)) { pos.x += dt * this.Speed; }
				if (Input.GetKey(this.keys.Left)) { pos.x -= dt * this.Speed; }
			}

			this.trans.position = pos;
		}
	}
}
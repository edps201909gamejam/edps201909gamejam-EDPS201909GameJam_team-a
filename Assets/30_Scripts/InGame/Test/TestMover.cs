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
		[Space(16)]
		[SerializeField]
		private new Rigidbody rigidbody = null;
		[SerializeField]
		private bool isMovePosition = false;

		// this.transformはメンバ変数でcacheした方が高速になる by flanny7
		private Transform trans = null;

		private float Speed { get => this.speed * 60.0f; }

		private void Start()
		{
			if (this.rigidbody is null) { this.rigidbody.GetComponent<Rigidbody>(); }
			this.trans = this.transform;
		}

		private void Update()
		{
			var dt = Time.deltaTime;
			var diff = new Vector3();

			if (this.isKeyDown)
			{
				if (Input.GetKeyDown(this.keys.Up)) { diff.z += dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Down)) { diff.z -= dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Right)) { diff.x += dt * this.Speed; }
				if (Input.GetKeyDown(this.keys.Left)) { diff.x -= dt * this.Speed; }
			}
			else
			{
				if (Input.GetKey(this.keys.Up)) { diff.z += dt * this.Speed; }
				if (Input.GetKey(this.keys.Down)) { diff.z -= dt * this.Speed; }
				if (Input.GetKey(this.keys.Right)) { diff.x += dt * this.Speed; }
				if (Input.GetKey(this.keys.Left)) { diff.x -= dt * this.Speed; }
			}

			this.Move(diff);
		}

		private void Move(Vector3 _diff)
		{
			var pos = this.trans.position;
			pos += _diff;

			if ((this.rigidbody != null) && this.isMovePosition)
			{
				this.rigidbody.MovePosition(pos);
				this.rigidbody.velocity = Vector3.zero;
			}
			else
			{
				this.trans.position = pos;
			}
		}
	}
}
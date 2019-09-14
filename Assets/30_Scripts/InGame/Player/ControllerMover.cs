// Remuty/Player より移動処理を抜粋 by flanny7

using UnityEngine;

namespace InGame
{
	public sealed class ControllerMover : MonoBehaviour, IActiveable
	{
		private static readonly Vector3 VECTOR3_ZERO = Vector3.zero;

		[System.Serializable]
		public struct Keys
		{
			public KeyCode Up;
			public KeyCode Down;
			public KeyCode Right;
			public KeyCode Left;
		}

		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private InputController.Player plNum = InputController.Player.pl1;
		[SerializeField]
		private Keys keys;
		[SerializeField]
		private float moveSpeed = 5.0f;
		[SerializeField]
		private float turnSpeed = 0.2f;

		// this.transformはメンバ変数でcacheした方が高速になる by flanny7
		private Transform trans = null;
		private InputController ic = null;

		public bool IsMoving { get; private set; }

		private void Start()
		{
			this.trans = this.transform;
			this.ic = InputController.Inst;
		}

		private void Update()
		{
			if (!this.IsActiveComponent())
			{
				this.IsMoving = false;
				return;
			}

			this.Move();
		}

		private void Move()
		{
			var dt = Time.deltaTime;
			var velocity = VECTOR3_ZERO;

			if (this.GetButton(InputController.Horizontal.Right)) { velocity.x += 1; }
			if (this.GetButton(InputController.Horizontal.Left)) { velocity.x -= 1; }
			if (this.GetButton(InputController.Vertical.Up)) { velocity.z += 1; }
			if (this.GetButton(InputController.Vertical.Down)) { velocity.z -= 1; }

			// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整 by Remuty
			velocity = velocity.normalized * this.moveSpeed * dt;
			this.IsMoving = 0 < velocity.magnitude;
			if (this.IsMoving)
			{
				this.trans.position += velocity;
				this.trans.rotation = Quaternion.Slerp(this.trans.rotation, Quaternion.LookRotation(velocity), this.turnSpeed);
			}
		}

		private bool GetButton(InputController.Horizontal _hori)
		{
			var keyCode = (_hori is InputController.Horizontal.Left) ? this.keys.Left : this.keys.Right;
			return this.ic.GetDirectionButton(keyCode, this.plNum, _hori);
		}

		private bool GetButton(InputController.Vertical _vert)
		{
			var keyCode = (_vert is InputController.Vertical.Up) ? this.keys.Up : this.keys.Down;
			return this.ic.GetDirectionButton(keyCode, this.plNum, _vert);
		}
	}
}
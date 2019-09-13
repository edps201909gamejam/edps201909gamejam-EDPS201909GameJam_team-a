using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class FPlayer : AbstractManagerBehaviour
	{
		private Vector3 velocity;              // 移動方向
		[SerializeField] private float moveSpeed = 5.0f;        // 移動速度
		[SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
		private Animator animator;
		[SerializeField] public string joystick_X, joystick_Y;  //入力の名前を入れる

		protected override void OnSubStart()
		{
			animator = GetComponent<Animator>();
		}

		protected override void OnSubUpdate()
		{
			velocity = Vector3.zero;
			if (Input.GetAxisRaw(joystick_X) > 0)
				velocity.x += 1;
			if (Input.GetAxisRaw(joystick_X) < 0)
				velocity.x -= 1;
			if (Input.GetAxisRaw(joystick_Y) > 0)
				velocity.z += 1;
			if (Input.GetAxisRaw(joystick_Y) < 0)
				velocity.z -= 1;

			// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整
			velocity = velocity.normalized * moveSpeed * Time.deltaTime;
			if (velocity.magnitude > 0)
			{
				transform.position += velocity;
				transform.rotation = Quaternion.Slerp(transform.rotation,
													  Quaternion.LookRotation(velocity),
													  applySpeed);
				if (this.animator != null)
				{
					animator.SetBool("WalkFlag", true);
				}
			}
			else
			{
				if (this.animator != null)
				{
					animator.SetBool("WalkFlag", false);
				}
			}
		}

		protected override void OnSubEnd()
		{
		}
	}
}
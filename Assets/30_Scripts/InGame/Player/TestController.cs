using UnityEngine;

public sealed class TestController : MonoBehaviour
{
	private static readonly Vector3 VECTOR3_ZERO = Vector3.zero;

	[SerializeField]
	private AxesHorizontal[] horizontalButtons = null;
	[SerializeField]
	private AxesVertical[] verticalButtons = null;
	[SerializeField]
	private float moveSpeed = 5.0f;
	[SerializeField]
	private float rotateApplySpeed = 0.2f;
	[Space(8)]
	[SerializeField]
	private Axes attackButton;

	private Animator animator = null;

	private void Start()
    {
		this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
		this.Move();
		this.Attack();
    }

	private bool GetHorizon(InputController.Horizontal _h, float _sensitivety = 0)
	{
		var ic = InputController.Instance;
		for (var i = 0; i < this.horizontalButtons.Length; ++i)
		{
			var btn = this.horizontalButtons[i];
			if (ic.GetHorizontalButton(btn, _h, _sensitivety))
			{
				return true;
			}
		}

		return false;
	}

	private bool GetVert(InputController.Vertical _v, float _sensitivety = 0)
	{
		var ic = InputController.Instance;
		for (var i = 0; i < this.verticalButtons.Length; ++i)
		{
			var btn = this.verticalButtons[i];
			if (ic.GetVerticalButton(btn, _v, _sensitivety))
			{
				return true;
			}
		}

		return false;
	}

	private void Move()
	{
		var velocity = VECTOR3_ZERO;
		if (this.GetHorizon(InputController.Horizontal.Right)) { velocity.x += 1; }
		if (this.GetHorizon(InputController.Horizontal.Left)) { velocity.x -= 1; }
		if (this.GetVert(InputController.Vertical.Up)) { velocity.z += 1; }
		if (this.GetVert(InputController.Vertical.Down)) { velocity.z -= 1; }

		// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整 by remty
		velocity = velocity.normalized * moveSpeed * Time.deltaTime;
		if (0 < velocity.magnitude)
		{
			transform.position += velocity;
			transform.rotation = Quaternion.Slerp(transform.rotation,
												  Quaternion.LookRotation(velocity),
												  rotateApplySpeed);

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

	private void Attack()
	{
		var ic = InputController.Instance;
		if (ic.GetButtonDown(this.attackButton))
		{
			Debug.Log("Attack!!");
		}
	}
}

using uf7lib;
using uf7lib.DP;
using UnityEngine;

public sealed class InputController : Singleton<InputController>
{
	public enum Player
	{
		pl1,
		pl2,
	}

	public enum ButtonType
	{
		Left,
		Right,
		Up,
		Down,
		Circle,
		Cross,
		Square,
		Triangle,
		R1,
		R2,
		L1,
		L2,
		Start,
		Select,
	}

	public bool GetButton(Axes _axes)
	{
		return Input.GetButton(_axes.ToDescription());
	}

	public bool GetButtonDown(Axes _axes)
	{
		return Input.GetButtonDown(_axes.ToDescription());
	}

	public bool GetButtonUp(Axes _axes)
	{
		return Input.GetButtonUp(_axes.ToDescription());
	}

	public float GetAxis(Axes _axes)
	{
		return Input.GetAxis(_axes.ToDescription());
	}

	public float GetAxisRaw(Axes _axes)
	{
		return Input.GetAxisRaw(_axes.ToDescription());
	}
}
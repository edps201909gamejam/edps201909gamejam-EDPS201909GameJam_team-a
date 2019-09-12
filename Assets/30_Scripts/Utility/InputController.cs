using uf7lib;
using uf7lib.DP;
using UnityEngine;

public sealed class InputController : Singleton<InputController>
{
	public enum Horizontal
	{
		Left,
		Right,
	}

	public enum Vertical
	{
		Up,
		Down,
	}

	public bool GetHorizontalButton(AxesHorizontal _axes, Horizontal _h, float _sensitivety = 0)
	{
		var value = this.GetAxisRaw(_axes);

		if (_h == Horizontal.Left)
		{
			return value < -_sensitivety;
		}

		if (_h == Horizontal.Right)
		{
			return _sensitivety < value;
		}

		return false;
	}

	public bool GetVerticalButton(AxesVertical _axes, Vertical _v, float _sensitivety = 0)
	{
		var value = this.GetAxisRaw(_axes);

		if (_v == Vertical.Up)
		{
			return value < -_sensitivety;
		}

		if (_v == Vertical.Down)
		{
			return _sensitivety < value;
		}

		return false;
	}

	public bool GetButton(Axes _axes) { return Input.GetButton(_axes.ToDescription()); }
	public bool GetButton(AxesHorizontal _axes) { return Input.GetButton(_axes.ToDescription()); }
	public bool GetButton(AxesVertical _axes) { return Input.GetButton(_axes.ToDescription()); }

	public bool GetButtonDown(Axes _axes) { return Input.GetButtonDown(_axes.ToDescription()); }
	public bool GetButtonDown(AxesHorizontal _axes) { return Input.GetButtonDown(_axes.ToDescription()); }
	public bool GetButtonDown(AxesVertical _axes) { return Input.GetButtonDown(_axes.ToDescription()); }

	public bool GetButtonUp(Axes _axes) { return Input.GetButtonUp(_axes.ToDescription()); }
	public bool GetButtonUp(AxesHorizontal _axes) { return Input.GetButtonUp(_axes.ToDescription()); }
	public bool GetButtonUp(AxesVertical _axes) { return Input.GetButtonUp(_axes.ToDescription()); }

	public float GetAxis(Axes _axes) { return Input.GetAxis(_axes.ToDescription()); }
	public float GetAxis(AxesHorizontal _axes) { return Input.GetAxis(_axes.ToDescription()); }
	public float GetAxis(AxesVertical _axes) { return Input.GetAxis(_axes.ToDescription()); }

	public float GetAxisRaw(Axes _axes) { return Input.GetAxisRaw(_axes.ToDescription()); }
	public float GetAxisRaw(AxesHorizontal _axes) { return Input.GetAxisRaw(_axes.ToDescription()); }
	public float GetAxisRaw(AxesVertical _axes) { return Input.GetAxisRaw(_axes.ToDescription()); }
}
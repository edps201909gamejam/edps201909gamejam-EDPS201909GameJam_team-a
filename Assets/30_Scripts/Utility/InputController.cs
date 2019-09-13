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

	public bool GetDirectionButton(KeyCode _keyCode, Player _pl, Horizontal _hori)
	{
		if (Input.GetKey(_keyCode)) { return true; }

		var btn = (_pl is Player.pl1) ?
					this.GetHorizontalButton(AxesHorizontal.p1_horizontal_button, _hori) ||
					this.GetHorizontalButton(AxesHorizontal.p1_horizontal_stick_L, _hori) :
				  (_pl is Player.pl2) ?
					this.GetHorizontalButton(AxesHorizontal.p2_horizontal_button, _hori) ||
					this.GetHorizontalButton(AxesHorizontal.p2_horizontal_stick_L, _hori) :
			  false;

		return btn;
	}

	public bool GetDirectionButton(KeyCode _keyCode, Player _pl, Vertical _vart)
	{
		if (Input.GetKey(_keyCode)) { return true; }

		var btn = (_pl is Player.pl1) ?
					this.GetVerticalButton(AxesVertical.p1_vertical_button, _vart) ||
					this.GetVerticalButton(AxesVertical.p1_vertical_stick_L, _vart) :
				  (_pl is Player.pl2) ?
					this.GetVerticalButton(AxesVertical.p2_vertical_button, _vart) ||
					this.GetVerticalButton(AxesVertical.p2_vertical_stick_L, _vart) :
			  false;

		return btn;
	}
}
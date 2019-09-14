// Remuty/Player より移動処理を抜粋 by flanny7

using System;
using UnityEngine;

namespace InGame
{
	[RequireComponent(typeof(MagicPoint))]
	public sealed class ControllerSkiller : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField, Min(0)]
		private int useMP = 1;
		[SerializeField, Min(0)]
		private float intervalTime = 0.0f;
		[SerializeField]
		private KeyCode[] keyCodes = null;
		[SerializeField]
		private Axes[] axes = null;

		private MagicPoint magicPoint = null;
		private float elapsedTime = 0.0f;
		private Action skill = null;

		public void SetSkill(Action _skill) { this.skill = _skill; }

		private void Start()
		{
			var isKeyEmpty = (this.keyCodes is null) || (this.keyCodes.Length <= 0);
			var isButtonEmpty = (this.axes is null) || (this.axes.Length <= 0);
			if (isKeyEmpty && isButtonEmpty) { Debug.LogError("Key and Button are Empty.", this); }

			this.magicPoint = GetComponent<MagicPoint>();

			this.elapsedTime = 0.0f;
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			this.elapsedTime += Time.deltaTime;
			if (this.elapsedTime < this.intervalTime) { return; }

			var canAttack = false;
			for (var i = 0; i < this.keyCodes.Length; ++i)
			{
				if (Input.GetKeyDown(this.keyCodes[i])) { canAttack = true; break; }
			}

			if (!canAttack)
			{
				for (var i = 0; i < this.axes.Length; ++i)
				{
					if (InputController.Inst.GetButtonDown(this.axes[i])) { canAttack = true; break; }
				}
			}
			if (!canAttack) { return; }

			if (this.useMP <= this.magicPoint.Value)
			{
				this.magicPoint.Damage(this.useMP);
				this.skill();
				this.elapsedTime = 0.0f;
			}
		}
	}
}
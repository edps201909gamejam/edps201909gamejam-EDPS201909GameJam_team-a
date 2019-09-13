using UnityEngine;

namespace InGame
{
	public sealed class Attacker : MonoBehaviour, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private string[] layerNames;
		[SerializeField, Min(1)]
		private int attackPoint = 1;
		[SerializeField]
		private bool useButton = true;
		[SerializeField]
		private bool isButtonDown = true;
		[SerializeField, Min(0)]
		private float intervalTime = 0.0f;
		[SerializeField]
		private KeyCode[] keyCodes = null;
		[SerializeField]
		private Axes[] axes = null;
		[SerializeField]
		private bool isOneShotPlaySE = true;

		private float elapsedTime = 0.0f;

		private void Start()
		{
			var isLayerEmpty = (this.layerNames is null) || (this.layerNames.Length <= 0);
			if (isLayerEmpty) { Debug.LogError("LayerNames is Empty.", this); }

			if (this.useButton)
			{
				var isKeyEmpty = (this.keyCodes is null) || (this.keyCodes.Length <= 0);
				var isButtonEmpty = (this.axes is null) || (this.axes.Length <= 0);
				
				if (isKeyEmpty && isButtonEmpty) { Debug.LogError("Key and Button are Empty.", this); }
			}
			else
			{
				this.keyCodes = null;
				this.axes = null;
			}

			this.elapsedTime = 0.0f;
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }

			this.elapsedTime += Time.deltaTime;
		}

		private void OnCollisionStay(Collision c)
		{
			if (!this.IsActiveComponent()) { return; }
			if (this.elapsedTime < this.intervalTime) { return; }

			if (this.useButton)
			{
				var canAttack = false;

				if (this.isButtonDown)
				{
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
				}
				else
				{
					for (var i = 0; i < this.keyCodes.Length; ++i)
					{
						if (Input.GetKey(this.keyCodes[i])) { canAttack = true; break; }
					}

					if (!canAttack)
					{
						for (var i = 0; i < this.axes.Length; ++i)
						{
							if (InputController.Inst.GetButton(this.axes[i])) { canAttack = true; break; }
						}
					}
				}

				if (!canAttack) { return; }
			}

			var target = c.gameObject;
			var layer = target.layer;
			var isPlayed = false;

			for (var i = 0; i < this.layerNames.Length; ++i)
			{
				if (layer == LayerMask.NameToLayer(this.layerNames[i]))
				{
					var hp = target.GetComponent<HitPoint>();
					if (hp != null)
					{
						hp.Damage(this.attackPoint, (!isPlayed || !isOneShotPlaySE));
						isPlayed = true;
						Debug.Log("Attack: " + target.name, target);
					}
				}
			}

			if (isPlayed)
			{
				this.elapsedTime = 0.0f;
			}
		}
	}
}
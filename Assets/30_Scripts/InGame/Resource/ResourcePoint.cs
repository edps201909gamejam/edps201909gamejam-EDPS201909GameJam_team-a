using UnityEngine;

namespace InGame
{
	public abstract class ResourcePoint : MonoBehaviour, IActiveable
	{
		[SerializeField]
		protected bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField, Min(1)]
		protected int maxValue = 1;
		[SerializeField]
		protected AudioSource audioSource = null;
		[SerializeField]
		protected AudioClip healClip = null;
		[SerializeField]
		protected AudioClip damageClip = null;

		public int Value { get; protected set; }
		public float Rate { get => this.Value / this.maxValue; }
		public bool IsDead { get => this.Value <= 0; }
		public bool IsFull { get => this.maxValue <= this.Value; }

		private bool canHealSE = false;
		private bool canDamageSE = false;

		public void Heal(int _value, bool _se = true)
		{
			if (!this.IsActiveComponent()) { return; }
			if (_value < 0) { Debug.LogWarning("0未満は処理されません。", this); return; }

			this.Value = Mathf.Clamp(this.Value + _value, 0, this.maxValue);

			if (_se && this.canHealSE) { this.audioSource.PlayOneShot(this.healClip); }
		}

		public void Damage(int _value, bool _se = true)
		{
			if (!this.IsActiveComponent()) { return; }
			if (_value < 0) { Debug.LogWarning("0未満は処理されません。", this); return; }

			var tmp = this.Value - _value;
			this.Value = Mathf.Clamp(this.Value - _value, 0, this.maxValue);

			if (_se && this.canDamageSE) { this.audioSource.PlayOneShot(this.healClip); }
		}

		protected void Start()
		{
			this.canHealSE = !(this.audioSource is null) && !(this.healClip is null);
			this.canDamageSE = !(this.audioSource is null) && !(this.damageClip is null);

			this.Value = this.maxValue;
		}
	}
}
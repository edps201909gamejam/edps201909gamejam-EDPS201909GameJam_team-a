using uf7lib.DP;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
	public class TimeManager : SingletonMonoBehaviour<TimeManager>, IActiveable
	{
		[SerializeField]
		private bool isActiveComponent = true;
		public bool IsActiveComponent() { return this.isActiveComponent; }
		public void SetActiveComponent(bool _isActive) { this.isActiveComponent = _isActive; }

		[SerializeField]
		private float maoTime = 30.0f;
		[SerializeField]
		private float mainGameTime = 120.0f;
		[SerializeField]
		private Text timerText;

		public bool MaoTimePhase { get; private set; } = true;
		public bool IsFinished { get; private set; } = false;
		private float elapsedTime = 0.0f;

		protected override void OnInitialize()
		{
			this.elapsedTime = 0.0f;
		}

		private void Update()
		{
			if (!this.IsActiveComponent()) { return; }
			if (this.IsFinished) { return; }

			this.elapsedTime += Time.deltaTime;

			if (this.MaoTimePhase)
			{
				if (this.maoTime <= this.elapsedTime)
				{
					this.MaoTimePhase = false;
					this.elapsedTime = 0.0f;
				}
			}
			else
			{
				if (this.mainGameTime <= this.elapsedTime)
				{
					this.IsFinished = true;
					this.elapsedTime = 0.0f;
				}
			}

			this.Draw();
		}

		private void Draw()
		{
			var time = (this.MaoTimePhase) ?
				this.maoTime - this.elapsedTime :
				this.mainGameTime - this.elapsedTime;
			var minutes = Mathf.FloorToInt(time / 60F);
			var seconds = Mathf.FloorToInt(time - minutes * 60);
			var str = string.Format("{0:00}:{1:00}", minutes, seconds);
			this.timerText.text = str;
		}
	}
}
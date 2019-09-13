using uf7lib;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace InGame
{
	public sealed class FTimer : AbstractManagerBehaviour
	{
		[SerializeField] int minutes;
		[SerializeField] float seconds;
		private Text timerText;

		protected override void OnSubStart()
		{
			minutes = 2;
			seconds = 0f;
			timerText = GetComponentInChildren<Text>();
		}

		protected override void OnSubUpdate()
		{
			seconds -= Time.deltaTime;
			if (seconds <= 0)
			{
				if (minutes <= 0)
				{
					SceneManager.LoadScene("ResultTest");
				}
				minutes--;
				seconds += 59;
			}
			timerText.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
		}

		protected override void OnSubEnd()
		{
		}
	}
}
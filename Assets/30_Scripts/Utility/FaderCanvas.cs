using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Image))]
public sealed class FaderCanvas : MonoBehaviour
{
	[SerializeField, Min(0.0f), Tooltip("second")]
	private float fadeTime = 2.0f;
	[SerializeField, Range(0.0f, 1.0f)]
	private float startAlpha = 0.0f;

	private CanvasGroup canvasGroup = null;
	private Image image = null;

	public bool IsFadeIn { get; private set; } = false;
	private float fadeInElapsedTime = 0.0f;
	public bool IsFadeOut { get; private set; } = false;
	private float fadeOutElapsedTime = 0.0f;

	private float Alpha
	{
		get => this.canvasGroup.alpha;
		set => this.canvasGroup.alpha = value;
	}

	private void Start()
	{
		this.canvasGroup = GetComponent<CanvasGroup>();
		this.image = GetComponent<Image>();
	}

	private void Update()
	{
		if (!this.IsFadeIn) { this.fadeInElapsedTime = 0.0f; }
		if (!this.IsFadeOut) { this.fadeOutElapsedTime = 0.0f; }

		var dt = Time.deltaTime;
		if (this.IsFadeIn)
		{
			this.fadeInElapsedTime += dt;
			this.Alpha = Mathf.Lerp(0.0f, this.fadeTime, this.fadeInElapsedTime);

			if (1.0f <= this.Alpha) { this.IsFadeIn = false; }
		}

		if (this.IsFadeOut)
		{
			this.fadeOutElapsedTime += dt;
			this.Alpha = 1.0f - Mathf.Lerp(0.0f, this.fadeTime, this.fadeOutElapsedTime);

			if (this.Alpha <= 0.0f) { this.IsFadeOut = false; }
		}
	}

	public void FadeIn()
	{
		if (this.IsFadeIn) { return; }
		if (this.IsFadeOut) { this.IsFadeOut = false; }

		this.IsFadeIn = true;
	}

	public void FadeOut()
	{
		if (this.IsFadeOut) { return; }
		if (this.IsFadeIn) { this.IsFadeIn = false; }

		this.IsFadeOut = true;
	}
}
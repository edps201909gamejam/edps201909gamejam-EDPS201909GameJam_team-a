using UnityEngine;
using UnityEngine.UI;

public class Gage3DUI : MonoBehaviour
{
	[SerializeField]
	private Image image = null;
	private void Start()
    {
        if (this.image is null) { Debug.LogError("Image is null.", this); }
    }

	public void SetRate(float _rate)
	{
		this.image.fillAmount = _rate;
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMangaer : MonoBehaviour
{
	[SerializeField]
	private FaderCanvas faderCanvas;
	[SerializeField]
	private float fadeTime = 2.0f;
	[SerializeField]
	private Axes pl1axes;
	[SerializeField]
	private KeyCode pl1key;
	[SerializeField]
	private Axes pl2axes;
	[SerializeField]
	private KeyCode pl2key;
	private float elapsedTime;
	[SerializeField]
	private string gameSceneName = "";
	[SerializeField]
	private string gameSceneName2 = "";
	[SerializeField]
	private string gameSceneName3 = "";

	private string scene = "";

	private void Start()
	{
		this.faderCanvas.FadeIn();

		var r = Random.Range(0, 3);
		this.scene = (r == 0) ? this.gameSceneName :
					 (r == 1) ? this.gameSceneName2 :
					 (r == 2) ? this.gameSceneName3 :
					 this.gameSceneName;
	}

	private void Update()
	{
		this.elapsedTime += Time.deltaTime;

		if (this.fadeTime <= this.elapsedTime)
		{
			if (InputController.Inst.GetButtonDown(this.pl1axes) ||
				InputController.Inst.GetButtonDown(this.pl2axes) ||
				Input.GetKeyDown(this.pl1key) ||
				Input.GetKeyDown(this.pl2key))
			{
				SceneManager.LoadScene(this.scene);
			}
		}
	}
}

using uf7lib;
using UnityEngine;
using UnityEngine.UI;

public sealed class TalkManager : AbstractManagerBehaviour
{
	[System.Serializable]
	public class Talk
	{
		[SerializeField]
		private bool isEnableText = false;
		[SerializeField]
		private int spriteIndex = 0;
		[SerializeField]
		private string text = string.Empty;

		public bool IsEnableText { get => this.isEnableText; }
		public int SpriteIndex { get => this.spriteIndex; }
		public string Text { get => this.text; }
	}

	[SerializeField]
	private Sprite[] characterSprites = null;
	[SerializeField]
	private Image characterImage = null;
	[SerializeField]
	private Image textBoxImage = null;
	[SerializeField]
	private Text text = null;
	[Space(16)]
	[SerializeField]
	private Talk[] talks = null;

	public bool IsFinished { get => this.talks.Length <= this.currentTalkIndex + 1; }

	private int currentTalkIndex = 0;

	public bool Next()
	{
		if (this.IsFinished) { return false; }

		++this.currentTalkIndex;
		this.Set(this.talks[this.currentTalkIndex]);
		return true;
	}


	protected override void OnSubStart()
	{
		this.NullCheck(this.characterSprites);
		this.NullCheck(this.characterImage);
		this.NullCheck(this.textBoxImage);
		this.NullCheck(this.text);
		this.NullCheck(this.talks);

		if (this.characterSprites.Length <= 0)
		{
			Debug.LogError("CharacterSprites is Empty!!");
			Debug.Break();
		}

		if (this.talks.Length <= 0)
		{
			Debug.LogError("Talks is Empty!!");
			Debug.Break();
		}

		this.currentTalkIndex = 0;
		this.Set(this.talks[this.currentTalkIndex]);
	}

	protected override void OnSubUpdate()
	{
	}

	protected override void OnSubEnd()
	{
	}

	private void Start()
	{
		this.SubStart();
	}

	private void Update()
	{
		if (this.IsFinished)
		{
			Debug.Log("Finished");
			return;
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			this.Next();
		}
	}

	private void Set(Talk _talk)
	{
		if (_talk.IsEnableText)
		{
			this.textBoxImage.enabled = false;
			this.text.text = string.Empty;
		}
		else
		{
			this.textBoxImage.enabled = true;
			this.text.text = _talk.Text;
		}

		var isOutOfIndex = this.characterSprites.Length <= _talk.SpriteIndex;
		if (isOutOfIndex)
		{
			Debug.LogWarning("Talk: ImageIndex is out of index.");
			return;
		}

		this.characterImage.sprite = this.characterSprites[_talk.SpriteIndex];
	}

	private void NullCheck(object _obj)
	{
		if (_obj is null)
		{
			Debug.LogError(_obj.GetType().Name + " is null!!");
			Debug.Break();
		}
	}
}
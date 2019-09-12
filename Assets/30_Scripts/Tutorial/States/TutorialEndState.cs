using uf7lib;
using UnityEngine;

namespace Tutorial
{
	/// <summary>
	/// チュートリアル終了時の破棄ステート by flanny7
	/// </summary>
	public sealed class TutorialEndState : AbstractTutorialState, IStateable
	{
		public TutorialEndState(TutorialStateChange _change, bool _isDebug) :
			   base(_change, _isDebug) { }

		protected override void OnSubStart()
		{
		}

		protected override void OnSubUpdate()
		{
			this.TestUpdate();
		}

		protected override void OnSubEnd()
		{
		}

		private void TestUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{
				this.Change(TutorialStateManager.State.Initialize);
			}
		}
	}
}
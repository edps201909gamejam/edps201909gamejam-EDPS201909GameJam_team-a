using uf7lib;
using UnityEngine;

namespace Tutorial
{
	/// <summary>
	/// チュートリアル開始時の初期化ステート by flanny7
	/// </summary>
	public sealed class TutorialInitializeState : AbstractTutorialState, IStateable
	{
		public TutorialInitializeState(TutorialStateChange _change, bool _isDebug) :
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
				this.Change(TutorialStateManager.State.Mao);
			}
		}
	}
}
using uf7lib;
using UnityEngine;

namespace InGame
{
	/// <summary>
	/// InGameのポーズ中ステート by flanny7
	/// </summary>
	public sealed class InGamePauseState : AbstractInGameState, IStateable
	{
		public InGamePauseState(InGameStateChange _change, bool _isDebug) :
			   base(_change, _isDebug)
		{ }

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
				this.Change(InGameStateManager.State.Result);
			}
		}
	}
}
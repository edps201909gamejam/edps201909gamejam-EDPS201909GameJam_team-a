using uf7lib;
using UnityEngine;

namespace InGame
{
	/// <summary>
	/// InGame開始時の初期化ステート by flanny7
	/// </summary>
	public sealed class InGameInitializeState : AbstractInGameState, IStateable
	{
		public InGameInitializeState(InGameStateChange _change, bool _isDebug) :
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
				this.Change(InGameStateManager.State.Game);
			}
		}
	}
}
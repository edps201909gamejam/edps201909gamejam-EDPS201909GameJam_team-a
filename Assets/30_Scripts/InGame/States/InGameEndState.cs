using uf7lib;
using UnityEngine;

namespace InGame
{
	/// <summary>
	/// InGameの破棄処理用ステート by flanny7
	/// </summary>
	public sealed class InGameEndState : AbstractInGameState, IStateable
	{
		public InGameEndState(InGameStateChange _change, bool _isDebug) :
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
				this.Change(InGameStateManager.State.Initialize);
			}
		}
	}
}
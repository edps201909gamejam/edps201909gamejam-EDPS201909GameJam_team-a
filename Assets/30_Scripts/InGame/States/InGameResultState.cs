using uf7lib;
using UnityEngine;

namespace InGame
{
	/// <summary>
	/// InGameのリザルトステート by flanny7
	/// </summary>
	public sealed class InGameResultState : AbstractInGameState, IStateable
	{
		public InGameResultState(InGameStateChange _change, bool _isDebug) :
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
				this.Change(InGameStateManager.State.End);
			}
		}
	}
}
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
			// player
			InGameManager.Inst.MaoManager.SubStart();
			InGameManager.Inst.BraverManager.SubStart();

			// npc
			InGameManager.Inst.MonsterManager.SubStart();

			// gimmick
			InGameManager.Inst.GateManager.SubStart();
			InGameManager.Inst.CrystalManager.SubStart();
			InGameManager.Inst.StatueManager.SubStart();
		}

		protected override void OnSubUpdate()
		{
			this.Change(InGameStateManager.State.Game);
		}

		protected override void OnSubEnd()
		{
		}

		private void TestUpdate()
		{
		}
	}
}
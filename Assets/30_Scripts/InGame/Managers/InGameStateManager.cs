using uf7lib;
using UnityEngine;

namespace InGame
{
	public delegate void InGameStateChange(InGameStateManager.State _state);

	public sealed class InGameStateManager : AbstractManagerBehaviour
	{
		public enum State
		{
			Initialize,
			Game,
			Pause,
			Result,
			End,
		}

		/// <summary>
		/// ステートマネージャー by flanny7
		/// </summary>
		private StateManager<State> stateManager = null;
		private InGameInitializeState initState = null;
		private InGameGameState gameState = null;
		private InGamePauseState pauseState = null;
		private InGameResultState resultState = null;
		private InGameEndState endState = null;

		public void Change(State _state)
		{
			if (this.stateManager is null)
			{
				DebugText.Inst.AddDebugText("stateManager is null!!", "red");
				Debug.Break();
				return;
			}

			this.stateManager.Change(_state);
		}

		protected override void OnSubStart()
		{
			// managerのinstance生成と初期化 by flanny7
			this.stateManager = new StateManager<State>();
			this.stateManager.SubStart();

			// instanceの生成 by flanny7
			this.initState = new InGameInitializeState(this.Change, true);
			this.gameState = new InGameGameState(this.Change, true);
			this.pauseState = new InGamePauseState(this.Change, true);
			this.resultState = new InGameResultState(this.Change, true);
			this.endState = new InGameEndState(this.Change, true);

			// Stateの追加 by flanny7
			this.stateManager.Add(State.Initialize, this.initState);
			this.stateManager.Add(State.Game, this.gameState);
			this.stateManager.Add(State.Pause, this.pauseState);
			this.stateManager.Add(State.Result, this.resultState);
			this.stateManager.Add(State.End, this.endState);

			this.stateManager.Change(State.Initialize);
		}

		protected override void OnSubUpdate()
		{
			if (this.stateManager.IsEmpty) { return; }

			this.stateManager.SubUpdate();
		}

		protected override void OnSubEnd()
		{
		}
	}
}
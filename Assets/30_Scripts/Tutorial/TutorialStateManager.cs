using uf7lib;
using UnityEngine;

namespace Tutorial
{
	public delegate void TutorialStateChange(TutorialStateManager.State _state);

	public sealed class TutorialStateManager : AbstractManagerBehaviour
	{
		public enum State
		{
			Initialize,
			Mao,
			Braver,
			End,
		}

		/// <summary>
		/// ステートマネージャー by flanny7
		/// </summary>
		private StateManager<State> stateManager = null;
		private TutorialInitializeState initState = null;
		private TutorialMaoState maoState = null;
		private TutorialBraverState braverState = null;
		private TutorialEndState endState = null;

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
			this.initState = new TutorialInitializeState(this.stateManager.Change, true);
			this.maoState = new TutorialMaoState(this.stateManager.Change, true);
			this.braverState = new TutorialBraverState(this.stateManager.Change, true);
			this.endState = new TutorialEndState(this.stateManager.Change, true);

			// Stateの追加 by flanny7
			this.stateManager.Add(State.Initialize, this.initState);
			this.stateManager.Add(State.Mao, this.maoState);
			this.stateManager.Add(State.Braver, this.braverState);
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
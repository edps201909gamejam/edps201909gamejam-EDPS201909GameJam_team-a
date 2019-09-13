using uf7lib;
using UnityEngine;

namespace InGame
{
	/// <summary>
	/// InGameのゲーム中ステート by flanny7
	/// </summary>
	public sealed class InGameGameState : AbstractInGameState, IStateable
	{
		public enum State
		{
			Stop,
			MaoOnly,
			Play,
			CutIn,
		}

		private State currentState = State.Stop;

		public InGameGameState(InGameStateChange _change, bool _isDebug) : base(_change, _isDebug) { }

		protected override void OnSubStart()
		{
			this.currentState = State.Stop;
		}

		protected override void OnSubUpdate()
		{
			switch (this.currentState)
			{
				case State.Stop:    this.Stop(); break;
				case State.MaoOnly:	this.MaoOnly(); break;
				case State.Play:    this.Play(); break;
				case State.CutIn:   this.CutIn(); break;
			}
		}

		protected override void OnSubEnd()
		{
		}

		private void Stop()
		{
			if (this.IsDebug) { DebugText.Inst.AddDebugText("InGame/Game: Stop."); }

			if (Input.GetKeyDown(KeyCode.Return)) { this.SubChange(State.MaoOnly); }
		}

		private void MaoOnly()
		{
			if (this.IsDebug) { DebugText.Inst.AddDebugText("InGame/Game: MaoOnly."); }

			if (Input.GetKeyDown(KeyCode.Return)) { this.SubChange(State.Play); }
		}

		private void Play()
		{
			if (this.IsDebug) { DebugText.Inst.AddDebugText("InGame/Game: Play."); }

			// player
			InGameManager.Inst.MaoManager.SubUpdate();
			InGameManager.Inst.BraverManager.SubUpdate();

			// npc
			InGameManager.Inst.MonsterManager.SubUpdate();

			// gimmick
			InGameManager.Inst.GateManager.SubUpdate();
			InGameManager.Inst.CrystalManager.SubUpdate();
			InGameManager.Inst.StatueManager.SubUpdate();

			// timer
			InGameManager.Inst.Timer.SubUpdate();

			if (Input.GetKeyDown(KeyCode.Return)) { this.SubChange(State.CutIn); }
		}

		private void CutIn()
		{
			if (this.IsDebug) { DebugText.Inst.AddDebugText("InGame/Game: CutIn."); }

			if (Input.GetKeyDown(KeyCode.Return)) { this.Change(InGameStateManager.State.Pause); }
		}

		private void SubChange(State _state)
		{
			this.currentState = _state;
		}
	}
}
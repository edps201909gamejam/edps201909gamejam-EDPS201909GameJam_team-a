using uf7lib;
using UnityEngine;

// ToDo
// 魔王の解説をする
// - 魔王は勇者から逃げる
// - ゲートを開いて中に逃げ切れば勝利
// - 勇者に直接攻撃されたり、時間制限を超えると敗北
// - クリスタルに魔力を与えて起動し、モンスターを召喚することができる
// - 女神像を破壊するとゲートが少し開く
// - ゲートの前で魔力を与えると少しずつ開く
// - 魔王にはゲーム開始直前に準備時間が与えられる
// - クリスタルで勇者を妨害しつつ、女神像を壊してゲートを開き、逃げ切ることが目的

namespace Tutorial
{
	/// <summary>
	/// 魔王を解説するステート by flanny7
	/// </summary>
	public sealed class TutorialMaoState : AbstractTutorialState, IStateable
	{
		public TutorialMaoState(TutorialStateChange _change, bool _isDebug) :
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
				this.Change(TutorialStateManager.State.Braver);
			}
		}
	}
}
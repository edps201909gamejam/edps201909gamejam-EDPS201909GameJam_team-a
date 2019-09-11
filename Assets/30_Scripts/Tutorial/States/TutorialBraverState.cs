using uf7lib;
using UnityEngine;

// ToDo
// 勇者の解説をする
// - 勇者は魔王を倒す/逃がさない
// - 直接攻撃をして魔王を倒すか、制限時間まで逃がさなければ勝利
// - 魔王がゲートに逃げた時点で敗北
// - 勇者は魔王とモンスターに直接攻撃ができる
// - 勇者は死んでも蘇る（ただし、リスポーンする間は動けない）
// - 起動したクリスタルを破壊することで魔力が得られる
// - 魔力を消費してスキルを使うことができる
// - スキルを魔王に当てると怯ませることができる（妨害）
// - クリスタルを破壊して魔王を足止めし、倒したり/邪魔をし続けることが目的

namespace Tutorial
{
	/// <summary>
	/// 勇者の解説をするステート by flanny7
	/// </summary>
	public sealed class TutorialBraverState : AbstractTutorialState, IStateable
	{
		public TutorialBraverState(TutorialStateChange _change, bool _isDebug) :
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
				this.Change(TutorialStateManager.State.End);
			}
		}
	}
}
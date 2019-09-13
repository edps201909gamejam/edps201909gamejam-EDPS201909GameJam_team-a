using uf7lib;
using UnityEngine;

namespace InGame
{
	public class MaoManager : AbstractManagerBehaviour
	{
		[SerializeField]
		private FPlayer player = null;
		[SerializeField]
		private FMao mao = null;

		protected override void OnSubStart()
		{
			if (this.player is null) { Debug.LogError("player is null."); }
			if (this.mao is null) { Debug.LogError("mao is null."); }

			this.player.SubStart();
			this.mao.SubStart();
		}

		protected override void OnSubUpdate()
		{
			this.player.SubUpdate();
			this.mao.SubUpdate();
		}

		protected override void OnSubEnd()
		{
			this.player.SubEnd();
			this.mao.SubEnd();
		}
	}
}
using System.Collections.Generic;
using uf7lib;
using UnityEngine;

namespace InGame
{
	public class BraverManager : AbstractManagerBehaviour
	{
		[SerializeField]
		private FPlayer player = null;
		[SerializeField]
		private FBraver braver = null;

		private List<FBraverSkill> skills = null;

		public void ChangeBraver(FBraver _braver)
		{
			this.braver.SubEnd();
			this.braver = _braver;
			this.player = this.braver.GetComponent<FPlayer>();
			this.braver.SubStart();
		}

		public void AddSkill(FBraverSkill _skill)
		{
			this.skills.Add(_skill);
			_skill.SubStart();
		}

		protected override void OnSubStart()
		{
			if (this.player is null) { Debug.LogError("player is null."); }
			if (this.braver is null) { Debug.LogError("braver is null."); }

			this.skills = new List<FBraverSkill>();

			this.player.SubStart();
			this.braver.SubStart();
		}

		protected override void OnSubUpdate()
		{
			this.player.SubUpdate();
			this.braver.SubUpdate();

			for (var i = 0; i < this.skills.Count; ++i)
			{
				if (this.skills[i] is null) { continue; }

				this.skills[i].SubUpdate();
			}
		}

		protected override void OnSubEnd()
		{
			this.braver.SubEnd();
			this.braver.SubEnd();

			for (var i = 0; i < this.skills.Count; ++i)
			{
				if (this.skills[i] is null) { continue; }

				this.skills[i].SubEnd();
			}
		}
	}
}
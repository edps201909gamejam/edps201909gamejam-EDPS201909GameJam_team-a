using System.Collections.Generic;
using uf7lib;
using UnityEngine;

namespace InGame
{
	public class CrystalManager : AbstractManagerBehaviour
	{
		[SerializeField]
		private FMagicCircle[] magicCircles = null;

		private List<FCrystal> crystals = null;

		public void AddCrystal(FCrystal _crystal)
		{
			this.crystals.Add(_crystal);
			_crystal.SubStart();
		}

		protected override void OnSubStart()
		{
			if (this.magicCircles is null) { Debug.LogError("magicCircles is null."); }
			for (var i = 0; i < this.magicCircles.Length; ++i)
			{
				this.magicCircles[i].SubStart();
			}
			this.crystals = new List<FCrystal>();
		}

		protected override void OnSubUpdate()
		{
			for (var i = 0; i < this.magicCircles.Length; ++i)
			{
				if (this.magicCircles[i] is null) { continue; }

				this.magicCircles[i].SubUpdate();
			}

			for (var i = 0; i < this.crystals.Count; ++i)
			{
				if (this.crystals[i] is null) { continue; }

				this.crystals[i].SubUpdate();
			}
		}

		protected override void OnSubEnd()
		{
			for (var i = 0; i < this.magicCircles.Length; ++i)
			{
				if (this.magicCircles[i] is null) { continue; }

				this.magicCircles[i].SubEnd();
			}

			for (var i = 0; i < this.crystals.Count; ++i)
			{
				if (this.crystals[i] is null) { continue; }

				this.crystals[i].SubEnd();
			}
		}
	}
}
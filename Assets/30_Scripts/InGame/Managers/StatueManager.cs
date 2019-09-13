using uf7lib;
using UnityEngine;

namespace InGame
{
	public sealed class StatueManager : AbstractManagerBehaviour
	{
		[SerializeField]
		private FSymbolArea[] symbolAreas = null;

		protected override void OnSubStart()
		{
			if (this.symbolAreas is null) { Debug.LogError("symbolAreas is null."); }

			for (var i = 0; i < this.symbolAreas.Length; ++i)
			{
				this.symbolAreas[i].SubStart();
			}
		}

		protected override void OnSubUpdate()
		{
			for (var i = 0; i < this.symbolAreas.Length; ++i)
			{
				if (this.symbolAreas[i] is null) { continue; }

				this.symbolAreas[i].SubUpdate();
			}
		}

		protected override void OnSubEnd()
		{
			for (var i = 0; i < this.symbolAreas.Length; ++i)
			{
				if (this.symbolAreas[i] is null) { continue; }

				this.symbolAreas[i].SubEnd();
			}
		}
	}
}
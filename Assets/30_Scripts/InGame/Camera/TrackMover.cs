using UnityEngine;

namespace InGame
{
	public sealed class TrackMover : MonoBehaviour
	{
		private static readonly Vector3 VECTOR3_ZERO = Vector3.zero;

		[SerializeField]
		private Transform targetTransform = null;
		[SerializeField]
		private Vector3 bufferPosition = VECTOR3_ZERO;
		[Space(8)]
		[SerializeField]
		private bool isFreezeX = false;
		[SerializeField]
		private bool isFreezeY = true;
		[SerializeField]
		private bool isFreezeZ = true;

		private Vector3 prevPosition = VECTOR3_ZERO;

		public void SubStart()
		{
			if (this.targetTransform is null)
			{
				Debug.LogError("targetTransform is null!!", this.gameObject);
				Debug.Break();
				return;
			}

			var nextPos = this.targetTransform.position + this.bufferPosition;
			var pos = this.transform.position;
			if (this.isFreezeX) { nextPos.x = pos.x; }
			if (this.isFreezeY) { nextPos.y = pos.y; }
			if (this.isFreezeZ) { nextPos.z = pos.z; }
			this.transform.position = nextPos;

			this.prevPosition = this.targetTransform.position;
		}

		public void SubUpdate()
		{
			var currentPosition = this.targetTransform.position;
			var diff = currentPosition - this.prevPosition;

			var isMove = diff != VECTOR3_ZERO;
			if (isMove) { this.Move(diff); }

			this.prevPosition = currentPosition;
		}

		private void Start() { this.SubStart(); }

		private void Update() { this.SubUpdate(); }

		private void Move(Vector3 _diff)
		{
			var tmp = this.transform.position;

			if (!this.isFreezeX) { tmp.x += _diff.x; }
			if (!this.isFreezeY) { tmp.y += _diff.y; }
			if (!this.isFreezeZ) { tmp.z += _diff.z; }

			this.transform.position = tmp;
		}
	}
}
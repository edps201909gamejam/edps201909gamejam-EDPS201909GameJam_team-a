using UnityEngine;

namespace uf7lib
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class MeshScroll : MonoBehaviour
    {
        #region Private Member (SerializeField)

        [SerializeField] private Vector2 scrollSpeed = Vector2.one * 2.0f;

        #endregion

        #region Private Member
        // cache
        private MeshRenderer meshRender = null;
        // status
        private float elapsedTime = 0.0f;
        private bool isPlay = true;
        #endregion

        #region Private Propaty
        private Material Material { get => this.meshRender.material; }
        #endregion

        #region Public Function
        /// <summary>
        /// スクロールを止める by flanny7
        /// </summary>
        public void Stop()
        {
            this.isPlay = false;
        }

        /// <summary>
        /// スクロールを開始する by flanny7
        /// </summary>
        public void Play()
        {
            this.isPlay = true;
        }
        #endregion

        #region Private Function
        private void Start()
        {
            // 初期化
            this.meshRender = this.GetComponent<MeshRenderer>();
            this.elapsedTime = 0.0f;
            this.isPlay = true;

            // Nullチェック
			if (this.meshRender is null)
			{
				Debug.LogError(this.meshRender.name + " is null.", this);
			}
        }

        private void Update()
        {
            if (!this.isPlay) { return; }

            this.elapsedTime += Time.deltaTime;

            var x = Mathf.Repeat(this.elapsedTime * this.scrollSpeed.x, 1f);
            var y = Mathf.Repeat(this.elapsedTime * this.scrollSpeed.y, 1f);
            this.Material.SetTextureOffset("_MainTex", new Vector2(x, y));
        }
        #endregion
    }
}
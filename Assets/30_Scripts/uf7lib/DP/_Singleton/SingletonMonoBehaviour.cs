using UnityEngine;

namespace uf7lib.DP
{
    /// <summary>
    /// SingletonなMonoBehaviourクラス by flanny7
    /// </summary>
    /// <typeparam name="T">継承先のクラス</typeparam>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        #region Public Propaty
        /// <summary>
        /// 初期化フラグ by flanny7
        /// </summary>
        public bool IsInitialize { get; private set; } = false;
        #endregion

        #region Static Private Member
        private static T instance = null;
        #endregion

        /// <summary>
        /// コンストラクタ by flanny7
        /// </summary>
        protected SingletonMonoBehaviour()
        {
            this.IsInitialize = false;
        }

        /// <summary>
        /// インスタンスのアクセサ by flanny7
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    Debug.LogError("<color=#f00>" + typeof(T) + "</color> is nothing");
                    Debug.Break();
                }

                if (instance != null && !instance.IsInitialize)
                {
                    instance.Initialize();
                }

                return instance;
            }
        }

        /// <summary>
        /// インスタンスのアクセサ（省略形） by flanny7
        /// </summary>
        public static T Inst { get => Instance; }

        /// <summary>
        /// 非明示的なoverrideをしてはいけない by flanny7
        /// </summary>
        private void Start()
        {
            this.Initialize();
        }

        /// <summary>
        /// 初期化関数 by flanny7
        /// </summary>
        private void Initialize()
        {
            if (this == Instance)
            {
                if (this.IsInitialize) { return; }

                this.OnInitialize();
                this.IsInitialize = true;

                return;
            }

            Destroy(this);

            Debug.LogError("<color=#f00>" + typeof(T) + "</color> is duplicated");
            Debug.Break();
        }

        /// <summary>
        /// 初めて参照されたとき,またはStart()で呼び出される初期化関数 by flanny7
        /// </summary>
        protected abstract void OnInitialize();
    }
}
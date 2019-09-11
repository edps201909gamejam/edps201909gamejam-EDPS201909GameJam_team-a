namespace uf7lib.DP
{
    /// <summary>
    /// Singletonなクラス by flanny7
    /// </summary>
    /// <typeparam name="T">継承先のクラス</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        #region Private Static Member
        private static T instance = null;
        #endregion
        
        /// <summary>
        /// インスタンスのアクセサ by flanny7
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance != null) { return instance; }

                instance = new T();

                return instance;
            }
        }
        
        /// <summary>
        /// インスタンスのアクセサ by flanny7
        /// </summary>
        public static T Inst { get => Instance; }
    }
}
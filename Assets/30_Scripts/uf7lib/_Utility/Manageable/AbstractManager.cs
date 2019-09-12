namespace uf7lib
{
    public abstract class AbstractManager : IManageable
    {
        public void SubStart()
        {
            this.OnSubStart();
        }
        public void SubUpdate()
        {
            this.OnSubUpdate();
        }

        public void SubEnd()
        {
            this.OnSubEnd();
        }

        protected abstract void OnSubStart();
        protected abstract void OnSubUpdate();
        protected abstract void OnSubEnd();
    }
}
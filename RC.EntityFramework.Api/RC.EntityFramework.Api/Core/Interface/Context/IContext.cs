namespace RC.EntityFramework.Api.Core.Interface.Context
{
    public interface IContext
    {
        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}
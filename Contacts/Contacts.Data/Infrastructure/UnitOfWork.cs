
namespace Contacts.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _dbFactory;

        protected ContactsEntities DbContext
        {
            get { return _dbFactory.Get(); }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}


namespace Contacts.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ContactsEntities _dataContext;

        public ContactsEntities Get()
        {
            return _dataContext ?? (_dataContext = new ContactsEntities());
        }

        protected override void DisposeBase()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
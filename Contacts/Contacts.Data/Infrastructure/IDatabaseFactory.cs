using System;

namespace Contacts.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ContactsEntities Get();
    }
}
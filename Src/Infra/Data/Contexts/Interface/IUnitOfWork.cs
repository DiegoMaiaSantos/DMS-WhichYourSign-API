﻿namespace DMS_WhichYourSign_API.Src.Infra.Data.Contexts.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public Task BeginTransaction();
        public Task Commit();
        public Task Rollback();
    }
}

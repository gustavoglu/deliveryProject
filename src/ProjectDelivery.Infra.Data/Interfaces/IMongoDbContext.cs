using MongoDB.Driver;
using ProjectDelivery.Domain.Core.Entitys;
using ProjectDelivery.Infra.Data.Context;
using System;

namespace ProjectDelivery.Infra.Data.Interfaces
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoDatabase GetConnection();
        void ActionInDatabase(Action actionInDatabase);
        SaveChangesResponse SaveChanges();
        void CriaEntity<T>(T Entity) where T : Entity;
        void AtualizaEntity<T>(T Entity) where T : Entity;
        void DeletaEntity<T>(T Entity) where T : Entity;
    }
}

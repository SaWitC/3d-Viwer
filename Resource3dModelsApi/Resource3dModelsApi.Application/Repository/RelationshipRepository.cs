using Microsoft.EntityFrameworkCore.ChangeTracking;
using Resource3dModelsApi.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource3dModelsApi.Application.Repository
{
    public interface RelationshipRepository
    {
        Task<EntityEntry<TSaveTable>> Create<TSaveTable, TParticipant1, TParticipant2>(TParticipant1 participant1, TParticipant2 participant2) where TSaveTable : class, IEntity where TParticipant1 : class, IEntity where TParticipant2 : class, IEntity;
        //Task<EntityEntry<TSaveTable>> Delete<TSaveTable, TParticipant1, TParticipant2>() where TSaveTable : class, IEntity where TParticipant1 : class, IEntity where TParticipant2 : class, IEntity;
    }
}

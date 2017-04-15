﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenEye.Backend.Core.Entity
{
    public interface IEntityEntry
    {
        IEntity Entity { get; }
        EntityEntryState State { get; }
    }

    public class EntityEntry : IEntityEntry
    {
        public EntityEntryState State { get; private set; }

        public IEntity Entity { get; private set; }

        public EntityEntry(EntityEntryState state, IEntity entity)
        {
            State = state;
            Entity = entity;
        }
    }

    public enum EntityEntryState
    {
        //
        // Summary:
        //     The entity is not being tracked by the context.
        Detached = 0,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database. Its property
        //     values have not changed from the values in the database.
        Unchanged = 1,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database. It has
        //     been marked for deletion from the database.
        Deleted = 2,
        //
        // Summary:
        //     The entity is being tracked by the context and exists in the database. Some or
        //     all of its property values have been modified.
        Modified = 3,
        //
        // Summary:
        //     The entity is being tracked by the context but does not yet exist in the database.
        Added = 4
    }
}

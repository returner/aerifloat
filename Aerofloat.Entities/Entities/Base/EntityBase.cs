﻿namespace Aerofloat.Entities.Entities.Base;

public class EntityBase<T> : IEntityAggregateRoot where T : struct
{
    public T Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
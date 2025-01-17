﻿using Ardalis.Specification;

namespace Aerifloat.Core.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IEntityAggregateRoot
{
}

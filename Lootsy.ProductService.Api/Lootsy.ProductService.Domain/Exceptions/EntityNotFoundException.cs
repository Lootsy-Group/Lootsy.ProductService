﻿namespace Lootsy.ProductService.Domain.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(string message) : base(message) { }
}

﻿namespace ImplementingCqrsPattern.Entities.General;
public class BaseEntity<T> where T : struct
{
    public T Id { get; set; }
}


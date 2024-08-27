namespace ImplementingCqrsPattern.Entities.General;
public class AggregateRoot<T> : BaseEntity<T> where T : struct;
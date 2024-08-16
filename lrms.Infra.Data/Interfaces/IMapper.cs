using System;

namespace lrms.Infra.Data.Interfaces;

public interface IMapper<Entity, Aggregate>
{
    Entity ToPersistance(Aggregate aggregate);
    Aggregate ToDomain(Entity entity);
}

using MediatR;
using SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    
public abstract class EntityBase
{
  public DateTime CreatedAt { get; private set; }
  public Guid? CreatedBy { get; private set; }
  public DateTime ModifiedAt { get; private set; }
  public Guid? ModifiedBy { get; private set; }

  public List<Event> DomainEvents = new();


  public void SetCreatedBy(Guid? id)
  {
    if (id == null)
    {
      return;
    }

    CreatedAt = DateTime.Now;
    CreatedBy = id;
  }

  public void SetModifiedBy(Guid? id)
  {
    if (id == null)
    {
      return;
    }

    ModifiedAt = DateTime.Now;
    ModifiedBy = id;
  }

    public void AddDomainEvent(Event eventItem)
    {
        DomainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
        {
            DomainEvents.Clear();
        }
    }
}

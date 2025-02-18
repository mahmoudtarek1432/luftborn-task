using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    
public abstract class EntityBase<TId>
{
  public TId Id { get; private set; }

  public DateTime CreatedAt { get; private set; }
  public Guid? CreatedBy { get; private set; }
  public DateTime ModifiedAt { get; private set; }
  public Guid? ModifiedBy { get; private set; }

  public List<INotification> Events = new();

  public void SetId(TId id)
  {
    Id = id;
  }

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
}

}

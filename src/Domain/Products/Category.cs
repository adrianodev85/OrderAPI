using Flunt.Validations;

namespace OrderAPI.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;
        Active = true;

        Validate();

    }

    public void EditInfo(string name, bool active)
    {
        Name = name;
        Active = active;

        Validate();
    }
}

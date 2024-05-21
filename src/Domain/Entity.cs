using Flunt.Notifications;
using Flunt.Validations;
using OrderAPI.Domain.Products;

namespace OrderAPI.Domain;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? EditedBy { get; set; }
    public DateTime? EditedOn { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected void Validate()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name", "Name is Required")
                    .IsGreaterOrEqualsThan(Name, 3, "Name")
                    .IsNotNullOrEmpty(CreatedBy, "CreatedBy", "Created By is Required")
                    .IsNotNullOrEmpty(EditedBy, "EditedBy", "Edited By is Required");
        AddNotifications(contract);
    }

    protected void EditInfo()
    {
    } 
}

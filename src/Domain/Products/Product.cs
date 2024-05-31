using Flunt.Validations;

namespace OrderAPI.Domain.Products;

public class Product : Entity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public double Price { get; private set; }
    public bool HasStock { get; private set; }
    public Category Category { get; private set; }

    public Product()
    {        
    }
    public Product(string name, string? description, double price, bool hasStock, Category category,
        string createdBy, string editedBy)
    {
        Name = name;
        Description = description;
        Price = price;
        HasStock = hasStock;
        Category = category;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }

    public void Validate()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name", "Name is Required")
                    .IsGreaterOrEqualsThan(Name, 3, "Name")
                    .IsNotNullOrEmpty(CreatedBy, "CreatedBy", "Created By is Required")
                    .IsNotNullOrEmpty(EditedBy, "EditedBy", "Edited By is Required");
        AddNotifications(contract);
    }

    public void EditInfo(string name, string description, double price, bool hasStock, Category category, 
        string createdBy, string editedBy)
    {
        Name = name;
        Description = description;
        Price = price;
        HasStock = hasStock;
        Category = category;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();
    }


}

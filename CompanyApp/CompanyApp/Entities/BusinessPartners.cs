namespace CompanyApp.Entities
{
    public class BusinessPartners : EntityBase
    {
        public string? Name { get; set; }
        public string? OwnerName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Description { get; set; }
        public override string ToString() => $"Id: {Id}, Name: {Name} , OwnerName: {OwnerName}, ContactNumber :{ContactNumber} Description: {Description} ";
    }
}

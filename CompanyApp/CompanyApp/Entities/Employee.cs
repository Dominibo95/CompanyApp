namespace CompanyApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString() => $"id: {Id}, FirstName: {FirstName}";

    }
}

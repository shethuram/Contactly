namespace Contactly_API.Models.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }  // must required 

        public string? Email { get; set; }  // can be null

        public required string Phone { get; set; }

        public bool Favorite { get; set; }

    }
}

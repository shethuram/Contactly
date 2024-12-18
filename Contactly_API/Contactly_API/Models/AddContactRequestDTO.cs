namespace Contactly_API.Models
{
    public class AddContactRequestDTO
    {
      // id is not received from frontend , we create here 
        public required string Name { get; set; }  // must required 

        public string? Email { get; set; }  // can be null

        public required string Phone { get; set; }

        public bool Favorite { get; set; }

    }
}

global using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net6WebAPIEF
{
    public class Contact
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [Key]
        public string Email { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }    
        
        public string AccountName { get; set; }

        [JsonIgnore]
        public List<Incident> Incidents { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Net6WebAPIEF
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IncidentName { get; set; }    

        public string IncidentDescription { get; set; }

        
        public Account Account { get; set; }

        public string AccountName { get; set; }

        
        public Contact Contact { get; set; }

        public string ContactEmail { get; set; }

    }
}

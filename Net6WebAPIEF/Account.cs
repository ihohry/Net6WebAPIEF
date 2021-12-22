namespace Net6WebAPIEF
{
    public class Account
    {
        [Key]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Contact> Contacts { get; set; }
        
        [JsonIgnore]
        public List<Incident> Incidents { get; set; }
    }
}

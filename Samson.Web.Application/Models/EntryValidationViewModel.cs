namespace Samson.Web.Application.Models
{
    /// <summary>
    /// Entrance validation information. Provide information about actual clients number and possibility to entry.
    /// </summary>
    public class EntryValidationViewModel
    {
        public bool HasValidPass { get; set; }
        public bool IsGymFull { get; set; }
        public int MaximumNumberOfClients { get; set; }
        public int CurrentNumberOfClients { get; set; }
    }
}

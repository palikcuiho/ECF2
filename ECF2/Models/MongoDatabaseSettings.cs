namespace ECF2.Models
{

    public class MongoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string StatisticsCollectionName { get; set; } = null!;
    }
    
}

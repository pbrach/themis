namespace Persistence.DbTypes
{
    public class DbChore
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string DbPlanId { get; set; }
    }
}
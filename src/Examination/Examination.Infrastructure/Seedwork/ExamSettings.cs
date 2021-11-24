namespace Examination.Infrastructure.SeedWork
{
    public class ExamSettings
    {
        public string IdentityUrl { get; set; }

        public DatabaseSettings DatabaseSettings { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString = "mongodb://linh2nguyen:mr6iLL5KNp5piiK1M8gSFoiEqlVrYyMl0gcwv2LdbN2tlAITKnzTIij8TbkwnsxWkHUMFEv878y6ypY9RqVHzw==@linh2nguyen.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@linh2nguyen";
        public string DatabaseName = "Education";
    }
}
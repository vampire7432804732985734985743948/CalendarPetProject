namespace CalendarPetProject.Data
{
    public static class DataBaseConstantsCollector
    {
        public readonly static string DBConnectionString = "Data Source=DESKTOP-M2458CE\\SQLEXPRESS;Initial Catalog=CalendarDb;Integrated Security=True;Trust Server Certificate=True";
        public static WebApplication WebApplicationData { get; private set; }

        public static void GetAppData(WebApplication app)
        {
            if (app != null)
            {
                WebApplicationData = app;
            }
        }
    }
}

namespace Versta.Web
{
    public class SD
    {
        public static string? BaseUrl { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            //PUT,
            //DELETE
        }

        public enum ViewType
        {
	        Create,
	        Info
	        //Edit,
	        //Delete
        }
	}
}

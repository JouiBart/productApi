using Swashbuckle.AspNetCore.Filters;

namespace Product.API.Examples
{
    public class NotFoundErrorExample : IExamplesProvider<string>
    {
        public string GetExamples()
        {
            return "";
        }
    }
}

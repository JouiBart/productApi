using Swashbuckle.AspNetCore.Filters;

namespace Product.API.Examples
{
    public class BadRequestErrorExample : IExamplesProvider<string>
    {
        public string GetExamples()
        {
            return "Error message will be there";
        }
    }
}

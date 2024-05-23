
namespace Catalog.API.Products.GetProductByCatagory
{
    //public record GetProductByCatagoryRequest();
    public record GetProductByCatagoryResponse(IEnumerable<Product> Products);
    public class GetProductByCatagoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/product/catagory/{catagory}", async (string catagory, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCatagoryQuery(catagory));
                var response = result.Adapt<GetProductByCatagoryResponse>();
                return Results.Ok(response);

            })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCatagoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
        }
    }
}

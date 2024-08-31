namespace Catalog.API.Products.GetProductByCategory;

//public record GetProductByCategoryRequest();

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(category));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductByCategoryEndpoint")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithSummary("GetProductByCategoryEndpoint")
        .WithDisplayName("GetProductByCategoryEndpoint");
    }
}
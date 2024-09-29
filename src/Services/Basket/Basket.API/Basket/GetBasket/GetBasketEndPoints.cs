using Mapster;

namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string Username);

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = result.Adapt<GetBasketResponse>();
            
            return Results.Ok(response);
        })
        .WithName("GetBasketEndpoints")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Basket Endpoints by id")
        .WithDescription("Get Basket Endpoints by userName");
    }
}
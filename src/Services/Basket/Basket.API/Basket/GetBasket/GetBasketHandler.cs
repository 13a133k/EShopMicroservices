namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQuerHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //todo: get basket from database
        //var basket = await _repository.GetBasket(query.UserName);

        return new GetBasketResult(new ShoppingCart("swn"));
    }
}
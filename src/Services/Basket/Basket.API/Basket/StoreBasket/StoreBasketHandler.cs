namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(command => command.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(command => command.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        RuleFor(command => command.Cart.Items).NotEmpty();
        RuleForEach(command => command.Cart.Items)
            .ChildRules(item =>
            {
                item.RuleFor(cart => cart.Quantity).GreaterThan(0);
                item.RuleFor(cart => cart.Color).NotEmpty();
                item.RuleFor(cart => cart.Price).GreaterThan(0);
                item.RuleFor(cart => cart.ProductId).NotEmpty();
                item.RuleFor(cart => cart.ProductName).NotEmpty();
            });
    }
}

public class StoreBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var newCart = await repository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(newCart.UserName);
    }
}
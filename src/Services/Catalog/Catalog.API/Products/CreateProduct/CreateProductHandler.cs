namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage("Product name must be between 5 and 50 characters");

        RuleFor(x => x.Category)
            .NotEmpty()
            .NotNull()
            .WithMessage("Category cannot be empty");

        RuleFor(x => x.ImageFile)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please specify an image file.");

        RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}

internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@command}", command);

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //TODO
        //save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //return CreateProductResult result
        return new CreateProductResult(product.Id);
    }
}
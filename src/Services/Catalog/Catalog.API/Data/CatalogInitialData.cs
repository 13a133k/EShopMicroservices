using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(token: cancellation))
        {
            return;
        }

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new()
        {
            Id = new Guid("01919598-b8fc-4a9b-be24-08c963d99b04"),
            Name = "Product 1",
            Category = ["Category 1"],
            Description = "Description 1",
            ImageFile = "Image 1",
            Price = 10.99m
        },
        new()
        {
            Id = new Guid("0191af72-8522-44a2-96e3-03b68226e7d9"),
            Name = "Product 2",
            Category = ["Category 2"],
            Description = "Description 2",
            ImageFile = "Image 2",
            Price = 19.99m
        },
        new()
        {
            Id = new Guid("0191af72-8522-49a2-96e3-02b68226e6d9"),
            Name = "Product 3",
            Category = ["Category 3"],
            Description = "Description 3",
            ImageFile = "Image 3",
            Price = 7.99m
        },
        new()
        {
            Id = new Guid("0191af72-8522-49a2-96e3-02b68116e7d9"),
            Name = "Product 4",
            Category = ["Category 3"],
            Description = "Description 4",
            ImageFile = "Image 4",
            Price = 17.99m
        },
        new()
        {
            Id = new Guid("1191af74-4422-66a2-96e3-02b68226e6d9"),
            Name = "Product 5",
            Category = ["Category 3"],
            Description = "Description 1",
            ImageFile = "Image 5",
            Price = 7.99m
        },
        new()
        {
            Id = new Guid("0121af72-8522-49a2-96e3-02b68446e7d9"),
            Name = "Product 6",
            Category = ["Category 2"],
            Description = "Description 6",
            ImageFile = "Image 6",
            Price = 17.99m
        }
    };
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public static class CatalogController
{
    public static void MapCatalogApiV1(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/catalog/items", async (int pageSize = 10, int pageIndex = 0, string apiVersion) =>
        {
            // Placeholder response
            var response = new
            {
                pageIndex,
                pageSize,
                count = 100,
                data = new[]
                {
                    new
                    {
                        id = 1,
                        name = "Item 1",
                        description = "Description for Item 1",
                        price = 10.99,
                        pictureFileName = "item1.png",
                        catalogTypeId = 1,
                        catalogType = new { id = 1, type = "Type1" },
                        catalogBrandId = 1,
                        catalogBrand = new { id = 1, brand = "Brand1" },
                        availableStock = 100,
                        restockThreshold = 10,
                        maxStockThreshold = 500,
                        onReorder = false
                    }
                }
            };

            return Results.Ok(response);
        })
        .WithName("ListItems")
        .Produces(200)
        .ProducesProblem(400);
    }
}
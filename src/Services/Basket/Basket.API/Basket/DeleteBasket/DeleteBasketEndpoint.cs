﻿
namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UserName}", async (string UserName, ISender sender) =>
        {
            var command = await sender.Send(new DeleteBasketCommand(UserName));

            var response = command.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
        })
            .WithName("DeleteProduct")
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}

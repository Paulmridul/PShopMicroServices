﻿
using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,string Description,List<string> Catagories,string ImageUrl,float Price) :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create Product Object
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Catagories = command.Catagories,
                ImageUrl = command.ImageUrl,
                price = command.Price
            };
            //TODO
            // Save into DB
            session.Store(product);
            await session.SaveChangesAsync();

            // Return Result Object
            return new CreateProductResult(product.Id);

        }
    }
}

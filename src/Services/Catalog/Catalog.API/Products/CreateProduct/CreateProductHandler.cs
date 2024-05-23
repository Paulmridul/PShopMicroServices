
using BuildingBlocks.CQRS;
using Catalog.API.Models;
using FluentValidation;
using Marten;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,string Description,List<string> Catagories,string ImageUrl,decimal Price) :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductValidators : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidators() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Catagories).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
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
                Price = command.Price
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

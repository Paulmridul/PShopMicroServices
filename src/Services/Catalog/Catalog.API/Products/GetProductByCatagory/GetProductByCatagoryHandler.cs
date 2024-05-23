

namespace Catalog.API.Products.GetProductByCatagory
{
    public record GetProductByCatagoryQuery(string Catagory):IQuery<GetProductByCatagoryResult>;
    public record GetProductByCatagoryResult(IEnumerable<Product> Products);
    internal class GetProductByCatagoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCatagoryQuery, GetProductByCatagoryResult>
    {
        public async Task<GetProductByCatagoryResult> Handle(GetProductByCatagoryQuery query, CancellationToken cancellationToken)
        {
            
            var products = await session.Query<Product>().Where(x=>x.Catagories.Contains(query.Catagory)).ToListAsync(cancellationToken);
            return new GetProductByCatagoryResult(products);
        }
    }
}

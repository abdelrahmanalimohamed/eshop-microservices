﻿namespace Catalog.API.Products.GetProducts;
public record GetProductsQuery() : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);
public class GetProductsHandler
	  (IDocumentSession session , 
		 ILogger<GetProductsHandler> logger)
		: IQueryHandler<GetProductsQuery, GetProductsResult>
{
	public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
	{
		logger.LogInformation("log for get all products {Query}" , query);

		var products = await session.Query<Product>().ToListAsync(cancellationToken);

		return new GetProductsResult(products);
	}
}
namespace Catalog.API.Products.CreateProduct;

    public record CreateProductCommand(
	string Name,
	List<string> Category,
	string Description,
	string ImageFile,
	decimal Price) : ICommand<CreateProductResult>;
	public record CreateProductResult(Guid id);

	public class CreateProductValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
			RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
			RuleFor(x => x.Price).NotEqual(0).WithMessage("The Price must be greater than 0");
		}
	}
	public class CreateProductHandler
		 (IDocumentSession session) 
		: ICommandHandler<CreateProductCommand, CreateProductResult>
	{
		public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			 var product = new Product
			{
				Name = request.Name , 
				Description = request.Description , 
				ImageFile = request.ImageFile , 
				Category = request.Category , 
				Price = request.Price
			};

			session.Store(product);
			await session.SaveChangesAsync();

			return new CreateProductResult(product.Id);
		}
	}
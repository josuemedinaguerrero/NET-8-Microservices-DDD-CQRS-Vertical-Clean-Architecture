using BuildingBlocks.Exceptions;

namespace Catalog.Exceptions
{
	public class ProductNotFoundException : NotFoundException
	{
		public ProductNotFoundException(Guid Id) : base("Product", Id)
		{
		}
	}
}

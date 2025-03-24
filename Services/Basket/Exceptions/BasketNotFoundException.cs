using BuildingBlocks.Exceptions;

namespace Basket.Exceptions
{
   public class BasketNotFoundException : NotFoundException
   {
      public BasketNotFoundException(string userName) : base("Basket", userName)
      {
      }
   }
}

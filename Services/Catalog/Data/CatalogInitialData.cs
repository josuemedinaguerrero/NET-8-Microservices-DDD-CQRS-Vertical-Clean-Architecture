using Marten.Schema;

namespace Catalog.Data
{
   public class CatalogInitialData : IInitialData
   {
      public async Task Populate(IDocumentStore store, CancellationToken cancellation)
      {
         using var session = store.LightweightSession();

         if (await session.Query<Product>().AnyAsync(token: cancellation)) return;

         session.Store<Product>(new List<Product>{
            new()
               {
                  Id = new Guid("0195aee8-1f58-4e93-897b-7520aa11473e"),
                  Name = "IPHONE 2005",
                  ImageFile = "image2.png",
                  Category = ["Smart Phone"],
                  Description = "Product Description Malo",
                  Price = 5000
            },
            new()
               {
                  Id = new Guid("0195aee8-1f58-4e93-897b-7520bb114990"),
                  Name = "SAMSUNG 25",
                  ImageFile = "image3.png",
                  Category = ["Smart Phone"],
                  Description = "Product Description Malo",
                  Price = 5000
            },
            new()
               {
                  Id = new Guid("a7e94f16-95ea-4e6f-8b3e-2d1c12a1a129"),
                  Name = "Google Pixel 7",
                  ImageFile = "pixel7.png",
                  Category = ["Smart Phone", "Android"],
                  Description = "Latest Google flagship with advanced AI capabilities",
                  Price = 7499
            },
            new()
               {
                  Id = new Guid("b8c7d5a3-1e9f-4f8a-9b2c-3d4e5f6a7b8c"),
                  Name = "MacBook Pro M3",
                  ImageFile = "macbook_pro.png",
                  Category = ["Laptop", "Apple"],
                  Description = "Powerful laptop with the latest Apple silicon",
                  Price = 15999
            },
            new()
               {
                  Id = new Guid("c9d8e7f6-5a4b-3c2d-1e0f-9a8b7c6d5e4f"),
                  Name = "Sony PlayStation 5",
                  ImageFile = "ps5.png",
                  Category = ["Gaming", "Console"],
                  Description = "Next-gen gaming console with stunning graphics",
                  Price = 4999
            },
            new()
               {
                  Id = new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"),
                  Name = "Dell XPS 15",
                  ImageFile = "dell_xps.png",
                  Category = ["Laptop", "Windows"],
                  Description = "Premium Windows laptop with InfinityEdge display",
                  Price = 12499
            },
            new()
               {
                  Id = new Guid("e5f6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"),
                  Name = "Samsung QLED 4K TV",
                  ImageFile = "samsung_tv.png",
                  Category = ["TV", "Home Entertainment"],
                  Description = "Ultra HD Smart TV with Quantum Dot technology",
                  Price = 8999
            },
            new()
               {
                  Id = new Guid("f1a2b3c4-d5e6-f7a8-b9c0-d1e2f3a4b5c6"),
                  Name = "Bose QuietComfort Earbuds",
                  ImageFile = "bose_earbuds.png",
                  Category = ["Audio", "Headphones"],
                  Description = "Noise cancelling wireless earbuds with premium sound",
                  Price = 2499
            },
            new()
               {
                  Id = new Guid("a1b2c3d4-e5f6-a7b8-c9d0-e1f2a3b4c5d6"),
                  Name = "Canon EOS R6",
                  ImageFile = "canon_r6.png",
                  Category = ["Camera", "Photography"],
                  Description = "Full-frame mirrorless camera for professional photography",
                  Price = 16999
            },
            new()
               {
                  Id = new Guid("b2c3d4e5-f6a7-b8c9-d0e1-f2a3b4c5d6e7"),
                  Name = "Dyson V12 Detect",
                  ImageFile = "dyson_v12.png",
                  Category = ["Home Appliance", "Vacuum"],
                  Description = "Cordless vacuum with laser dust detection",
                  Price = 5999
            }
         });

         await session.SaveChangesAsync(cancellation);
      }
   }
}

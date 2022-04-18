using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly Guid[] _guids;

        public ProductSeed(Guid[] guids)
        {
            _guids = guids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product{Id = Guid.NewGuid(),Stock = 100,Name = "Dolma Pencil",CategoryId = _guids[0], Price = 12.53m},
                new Product{Id = Guid.NewGuid(),Stock = 100,Name = "Tükenmez Pencil",CategoryId = _guids[0], Price = 122.53m},
                new Product{Id = Guid.NewGuid(),Stock = 100,Name = "Kurşun Pencil",CategoryId = _guids[0], Price = 62.53m}, 
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Çizgili Book", CategoryId = _guids[1], Price = 23.53m },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Kareli Book", CategoryId = _guids[1], Price = 11.53m },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Dümdüz Book", CategoryId = _guids[1], Price = 44.53m }
            );
        }
    }
}

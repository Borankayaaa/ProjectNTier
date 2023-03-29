using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class CategoryMap :BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("kategoriler");
            Property(x => x.CategoryName).HasColumnName("Kategori İsmi");
            Property(x =>x.Description).HasColumnName("Açıklama");
        }
    }
}

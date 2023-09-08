using Duvido.GestãoDeGame.WEB_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Duvido.GestãoDeGame.WEB_API.Data.Map
{
    public class ListaMap : IEntityTypeConfiguration<ListaViewModel>
    {
        public void Configure(EntityTypeBuilder<ListaViewModel> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.NomeDaLista).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NomeDaLista).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Categoria).IsRequired().HasMaxLength(200);

            

            // Configurando a relação com ItensDaListaViewModel

        }
    }
}

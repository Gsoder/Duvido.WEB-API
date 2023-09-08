using Duvido.GestãoDeGame.WEB_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Duvido.GestãoDeGame.WEB_API.Data.Map
{
    public class ItensDaListaMap : IEntityTypeConfiguration<ItensDaListaViewModel>
    {
        public void Configure(EntityTypeBuilder<ItensDaListaViewModel> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.IDDaLista).IsRequired();
            builder.Property(x => x.Posicao).IsRequired();
            builder.Property(x => x.NomeDoItem).IsRequired().HasMaxLength(30);


        }
    }
}

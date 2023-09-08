using Duvido.GestãoDeGame.WEB_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Duvido.GestãoDeGame.WEB_API.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioViewModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioViewModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.username).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FotoPerfil).IsRequired().HasMaxLength(300);
        }
    }
}

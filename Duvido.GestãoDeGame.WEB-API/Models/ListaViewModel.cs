using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duvido.GestãoDeGame.WEB_API.Models
{
    public class ListaViewModel
    {
        [Key]
        public int ID { get; set; }
        public string? NomeDaLista { get; set; }
        public string? Categoria { get; set; }
        public virtual ICollection<ItensDaListaViewModel>? ItensDaLista { get; set; }
    }
}

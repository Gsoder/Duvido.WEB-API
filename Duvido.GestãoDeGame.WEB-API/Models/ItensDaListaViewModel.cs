using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Duvido.GestãoDeGame.WEB_API.Models
{
    public class ItensDaListaViewModel
    {
        [Key]
        public int ID { get; set; }
        public int IDDaLista { get; set; }
        public int Posicao { get; set; }
        public string? NomeDoItem { get; set; }



    }
}

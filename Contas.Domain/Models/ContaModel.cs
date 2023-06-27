using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.Domain.Models
{
    public class ContaModel:BaseModel
    {
        public int ContaId { get; set; }
        public string Nome { get; set; }      
        public string Descricao { get; set; }
    }
}

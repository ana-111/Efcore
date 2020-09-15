using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Efcore.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }


        [NotMapped] //Não mapeia a propriedade no banco de dados
        [JsonIgnore] //ignora propriedades no retorno no json
        public IFormFile Imagem { get; set; }

        //Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }

        //propriedades referente ao relacionamento na classe com a classe pedido
        public List <PedidoItem> PedidoItens { get; set; }
        
    }
}

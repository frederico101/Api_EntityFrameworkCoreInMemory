using System;

namespace API.Data
{
    public class Produto
    {
      public int Id { get; set; }
      public string Codigo { get; set; }
      public string Descricao { get; set; }
      public Decimal Valor { get; set; }
    }
}
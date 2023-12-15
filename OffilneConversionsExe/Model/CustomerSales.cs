using System;
namespace OfflineConversions.Model
{
    public class CustomerSales
    {
        public int Id { get; set; }
        public string StoreType { get; set; }
        public string StoreRedeLojas { get; set; }
        public string StoreDescRedeLojas { get; set; }
        public string Bar1 { get; set; }
        public DateTime EventCreatedAt { get; set; }
        public int IdTransacao { get; set; }
        public int QuantidadeProdutos { get; set; }
        public decimal TotalFrete { get; set; }
        public decimal Revenue { get; set; }
        public int IdLoja { get; set; }
        public string Loja { get; set; }
        public string CodigoVendedor { get; set; }
        public string Vendedor { get; set; }
        public decimal Desconto { get; set; }
        public string Bar2 { get; set; }
        public decimal DescontoItem { get; set; }
        public int Quantidade { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public string Grupo { get; set; }
        public string Subgrupo { get; set; }
        public string Colecao { get; set; }
        public string Linha { get; set; }
        public string Grife { get; set; }
        public string Modelo { get; set; }
        public string ProdRedeLojas { get; set; }
        public string ProductDescRedeLojas { get; set; }
        public string Subcategoria { get; set; }
        public string Categoria { get; set; }
        public string Cor { get; set; }
        public decimal PrecoItem { get; set; }
        public string Tamanho { get; set; }
        public string Operacao { get; set; }
        public string Bar3 { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string UF { get; set; }
        public string Location { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CustomerCreatedAt { get; set; }
        public string Email { get; set; }
        public string Bairro { get; set; }
        public string Celular { get; set; }
        public DateTime CustomerUpdatedAt { get; set; }
        public DateTime CustomerLastPurchaseDate { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string VendaOmni { get; set; }
        public string TipoLoja { get; set; }
        public bool EventCreated { get; set; }
    }
}


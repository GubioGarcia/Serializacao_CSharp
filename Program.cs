using Serializacao.Models;
using Newtonsoft.Json;

DateTime dataAtual = DateTime.Now;
List<Venda> listaVendas = new List<Venda>();

Venda v1 = new Venda(1, "Material de Escritorio", 25.00M, dataAtual);
Venda v2 = new Venda(2, "Material de Construcao", 350.00M, dataAtual);

listaVendas.Add(v1);
listaVendas.Add(v2);

// Serializacao
string serializado = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);
File.WriteAllText("Arquivos/vendas.json", serializado);

// Deserializacao
string conteudoArquivo = File.ReadAllText("Arquivos/vendas.json");
List<Venda> listaVendas2 = JsonConvert.DeserializeObject<List<Venda>>(conteudoArquivo);

foreach (Venda venda in listaVendas2) {
    Console.WriteLine($"Id: {venda.Id}, Produto: {venda.Produto}, " +
                $"Preço: {venda.Preco}, Data: {venda.DataVenda.ToString("dd/MM/yy HH:mm")}");
}
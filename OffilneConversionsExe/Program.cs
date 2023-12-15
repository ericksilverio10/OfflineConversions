using System;
using System.Text;
using System.Security.Cryptography;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfflineConversions.Data;
using OfflineConversions.Model;

namespace OfflineConversionsExe
{
    class Program
    {
        private readonly AppDbContext _context;

        public Program(AppDbContext context)
        {
            _context = context;
        }

        static async Task Main(string[] args)
        {
            using (var dbContext = new AppDbContext()) // Certifique-se de instanciar o DbContext corretamente
            {
                ExecuteOrder(dbContext);
            }

        }

        static void ExecuteOrder(AppDbContext context)
        {

            List<Order> ordersObj = new List<Order>();

            var config = new AppConfig();

            var ordersId = context.customerSales.Where(j => j.EventCreated == null || !j.EventCreated).Select(i => i.IdTransacao).ToList();

            if (ordersId.Count() == 0)
            {
                Console.WriteLine("Not Found.");
            }
            else
            {
                int count = 0;

                foreach (var order in ordersId)
                {
                    List<Product> produtos = new List<Product>();

                    var query = context.customerSales.Where(i => i.IdTransacao == order).Select(i => new { i.IdProduto, i.QuantidadeProdutos, i.Categoria }).ToList();

                    foreach (var item in query)
                    {
                        var produto = new Product(item.IdProduto, item.QuantidadeProdutos, item.Categoria);

                        produtos.Add(produto);
                    }

                    var order_value = context.customerSales.Where(i => i.IdTransacao == order).Select(i => i.Revenue).Distinct().First();

                    var email = context.customerSales.Where(i => i.IdTransacao == order).Select(i => i.Email).Distinct().First();

                    var phone_number = context.customerSales.Where(i => i.IdTransacao == order).Select(i => i.Celular).Distinct().First();

                    var event_created_at = context.customerSales.Where(i => i.IdTransacao == order).Select(i => i.EventCreatedAt).Distinct().First();


                    var unitTimeStamp = (long)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                    ordersObj.Add(

                        new Order(
                            "purchase",
                            unitTimeStamp,
                            new UserData(CalculateHash(email), CalculateHash(phone_number)),
                            new OrderDetails(order, "BRL", order_value, new List<Product>()),
                            "physical_store"
                            )
                        );

                    foreach (var produto in produtos)
                    {
                        ordersObj[count].custom_data.contents.Add(
                            new Product(produto.id, produto.quantity, "home_delivery")
                        );
                    }


                    var updatedOrder = context.customerSales.Where(j => j.IdTransacao == order).First();

                    updatedOrder.EventCreated = true;

                    context.Update(updatedOrder);
                    context.SaveChanges();

                    count++;

                }

                var data = new FinalData(ordersObj);

                string json = JsonConvert.SerializeObject(data);

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://graph.facebook.com/v17.0/1628479744079116/events?access_token=" + config.AccessToken;

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    Task<HttpResponseMessage> responseTask = client.PostAsync(apiUrl, content);

                    responseTask.Wait();

                    HttpResponseMessage response = responseTask.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Dados enviados com sucesso!" + response.Content);
                    }
                    else
                    {
                        Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.RequestMessage}");
                    }

                    Task<string> readTask = response.Content.ReadAsStringAsync();

                    readTask.Wait();

                    string resultContent = readTask.Result;

                    Console.WriteLine(resultContent);

                    Environment.Exit(0);

                }
            }
        }

        static string CalculateHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }

                return hashBuilder.ToString();
            }
        }
    }
}

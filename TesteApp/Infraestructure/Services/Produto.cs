using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Services
{
    public class Produto : Interfaces.IProduto
    {
        public  async Task  create(){
            //var dbName = "TestDatabase";
            await using var dbContext = new Context.SQliteContext();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.Produtos.AddRangeAsync(
                new Model.Produto
                {
                    COD_PRODUTO = "1",
                    DES_PRODUTO = "PRD 1",
                    STA_STATUS = "1"
                },
                new Model.Produto
                {
                    COD_PRODUTO = "2",
                    DES_PRODUTO = "PRD 2",
                    STA_STATUS = "1"
                }
            );

            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Model.Produto> GetAll()
        {
            using var dbContext = new Context.SQliteContext();
            return dbContext.Produtos.ToArray();
        }
    }
}

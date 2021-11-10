using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Services
{
    public class ProdutoCosif : Interfaces.IProdutoCosif
    {
        public async Task create()
        {
            //var dbName = "TestDatabase";
            await using var dbContext = new Context.SQliteContext();
            await dbContext.Database.EnsureCreatedAsync();

            dbContext.ProdutosCosif.Add(new Model.ProdutoCosif
            {
                COD_PRODUTO = "1",
                COD_COSIF = "1",
                COD_CLASSIFICACAO = "COSIF 1",
                STA_STATUS = "1"
            });
            dbContext.ProdutosCosif.Add(new Model.ProdutoCosif
            {
                COD_PRODUTO = "1",
                COD_COSIF = "2",
                COD_CLASSIFICACAO = "COSIF 2",
                STA_STATUS = "1"
            });

            await dbContext.SaveChangesAsync();
            
        }

        public IEnumerable<Model.ProdutoCosif> GetAll()
        {
            using var dbContext = new Context.SQliteContext();
            return dbContext.ProdutosCosif.ToArray();
        }
    }
}

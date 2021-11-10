using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Services
{
    public class MovimentoManual : Interfaces.IMovimentoManual
    {
        public async Task create()
        {
            //var dbName = "TestDatabase";
            await using var dbContext = new Context.SQliteContext();
            await dbContext.Database.EnsureCreatedAsync();
            dbContext.MovimentosManuais.Add(new Model.MovimentoManual
            {
                ID = 1,
                DAT_MES = 5,
                DAT_ANO = 2021,
                NUM_LANCAMENTO = 1,
                COD_PRODUTO = "1",
                COD_COSIF = "1",
                DES_DESCRICAO = "DESC 1",
                DAT_MOVIMENTO = DateTime.Now,
                COD_USUARIO = "TESTE",
                VAL_VALOR = 140
            });

            dbContext.MovimentosManuais.Add(new Model.MovimentoManual
            {
                ID = 2,
                DAT_MES = 2,
                DAT_ANO = 2021,
                NUM_LANCAMENTO = 1,
                COD_PRODUTO = "1",
                COD_COSIF = "2",
                DES_DESCRICAO = "DESC 2",
                DAT_MOVIMENTO = DateTime.Now,
                COD_USUARIO = "TESTE",
                VAL_VALOR = 120
            });
            await dbContext.SaveChangesAsync();
            
        }

        public IEnumerable<Model.MovimentoManual> GetAll()
        {
            using var dbContext = new Context.SQliteContext();
            return dbContext.MovimentosManuais.ToArray();
        }

        public async Task<Model.MovimentoManual> Post(Model.MovimentoManual movimento)
        {
            movimento.COD_USUARIO = "TESTE";
            movimento.DAT_MOVIMENTO = DateTime.Now;
            var t = GetAll();

            //lancamento no mesmo ano e mes
            var movimentosAno = GetAll().ToList().Where(x => x.DAT_ANO == movimento.DAT_ANO && x.DAT_MES == movimento.DAT_MES).OrderByDescending(x => x.NUM_LANCAMENTO);
            int com = movimentosAno.ToList().Count > 0 ? movimentosAno.FirstOrDefault().NUM_LANCAMENTO : 0;
            movimento.NUM_LANCAMENTO = com + 1;
            
            
            


            await using var dbContext = new Context.SQliteContext();
            await dbContext.Database.EnsureCreatedAsync();
            dbContext.MovimentosManuais.Add(movimento);
            await dbContext.SaveChangesAsync();
            return movimento;
        }
    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotaParanaLib;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace UnitTestNotaParanaLib
{
    [TestClass]
    public class NotaParanaWebClientTest
    {
        NotaParanaWebClient target;
        string encryptedPassword = "TqkEjl1tO/9anc4pStN3n1tFxoXQ++xHZ7/tnxEaeAE=";

        [TestInitialize]
        public void Initialize()
        {
            target = new NotaParanaWebClient();
            CryptoHelper ch = new CryptoHelper();
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            target.Dispose();
            target = null;
        }

        [TestMethod]
        public void PesquisarEntidadesPorCnpj_CnpjCompleto_Retorna1Entidade()
        {
            var expected = new Entidade() { CNPJ = "04.086.238/0001-32", RazaoSocial = "ASSOCIACAO DO AMIGO ANIMAL", NomeFantasia = null };

            var actual = target.PesquisarEntidadesPorCnpj("04.086.238/0001-32");

            AssertHelper.JsonAreEqual(expected, actual);
        }

        [TestMethod]
        public void PesquisarEntidadesPorCnpj_CnpjInexistente_RetornaVazio()
        {
            var actual = target.PesquisarEntidadesPorCnpj("11.111.111/1111-11");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void PesquisarEntidadesPorNome_AmigoAnimal_Retorna1Entidade()
        {
            var expected = new List<Entidade>();
            expected.Add(new Entidade() { CNPJ = "04.086.238/0001-32", RazaoSocial = "ASSOCIACAO DO AMIGO ANIMAL", NomeFantasia = null });

            var actual = target.PesquisarEntidadesPorNome("Associacao do Amigo Animal");

            AssertHelper.JsonCollectionAreEqual(expected, actual);
        }

        [TestMethod]
        public void PesquisarEntidadesPorNome_EntidadeInexistente_RetornaVazio()
        {
            var expected = new List<Entidade>();

            var actual = target.PesquisarEntidadesPorNome("EntidadeInexistente");

            AssertHelper.JsonCollectionAreEqual(expected, actual);
        }

        [TestMethod]
        public void PesquisarEntidadesPorNome_aoAnimal_Retorna3Entidades()
        {
            var expected = new List<Entidade>();
            expected.Add(new Entidade() { CNPJ = "24.688.523/0001-30", RazaoSocial = "ASSOCIACAO DE ASSISTENCIA AO ANIMAL ABANDONADO FICA COMIGO", NomeFantasia = "FICA COMIGO" });
            expected.Add(new Entidade() { CNPJ = "16.966.029/0001-62", RazaoSocial = "CORBELIA PROTECAO ANIMAL", NomeFantasia = "PROTECAO ANIMAL" });
            expected.Add(new Entidade() { CNPJ = "08.158.710/0001-56", RazaoSocial = "GRUPO DE AMPARO E PROTECAO ANIMAL - GAPA", NomeFantasia = "ARCA DE NOE" });


            var actual = target.PesquisarEntidadesPorNome("ao Animal");

            AssertHelper.JsonCollectionAreEqual(expected, actual);
        }

        [TestMethod]
        public void PesquisarEntidadesPorNome_Amigo_Retorna305Entidades()
        {
            
            //var expected = 317;
            var entidades = target.PesquisarEntidadesPorNome("amigo");
            //var actual = entidades.Count;
            //Removido a validação do total, pois o site se atualiza e o valor toatal aumenta com o tempo.
            //Assert.AreEqual(expected, actual, "As quantidades das coleções não conferem.");

            var expectedRazao = "A ORGANIZACAO NAO GOVERNAMENTAL AMIGOS DE PATAS - ONG/ADP";
            var actualRazao = (entidades.Where(c => c.RazaoSocial == expectedRazao).ToList())[0].RazaoSocial;
            Assert.AreEqual(expectedRazao, actualRazao, "A Razão do elemento da posição [0] não confere.");

            expectedRazao = "ASSOCIACAO DE PAIS E AMIGOS DOS EXCEPCIONAIS";
            actualRazao = (entidades.Where(c => c.RazaoSocial == expectedRazao).ToList())[0].RazaoSocial;
            Assert.AreEqual(expectedRazao, actualRazao, "A Razão do elemento da posição [150] não confere.");

            expectedRazao = "ASSOCIACAO LAR DA CRIANCA JESUS AMIGO";
            actualRazao = (entidades.Where(c => c.RazaoSocial == expectedRazao).ToList())[0].RazaoSocial;
            Assert.AreEqual(expectedRazao, actualRazao, "A Razão do elemento da posição [305] não confere.");

        }


        [TestMethod]
        public void RecuperarAreasAtuacao_()
        {
            var expected = new List<AreaAtuacao>();
            expected.Add(new AreaAtuacao() { ID = "208", Descricao = "Desportiva" });
            expected.Add(new AreaAtuacao() { ID = "207", Descricao = "Cultural" });
            expected.Add(new AreaAtuacao() { ID = "206", Descricao = "Saúde" });
            expected.Add(new AreaAtuacao() { ID = "205", Descricao = "Assistência Social" });
            expected.Add(new AreaAtuacao() { ID = "209", Descricao = "Defesa e proteção animal" });
         
            var actual = target.RecuperarAreasAtuacao();
            
            AssertHelper.JsonAreEqual(expected, actual);                                                                                 
     
        }

        [TestMethod]
        public void TesteLoginSucesso()
        {
            var response = target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));

            Assert.AreEqual(true, response);
        }

        [TestMethod]
        public void TesteLoginIncorreto()
        {
            var response = target.Login("04972136995", "LALALALALA");

            Assert.AreEqual(false, response);
        }

        [TestMethod]
        public void TesteEnviarNotaSucesso()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));
            var message = target.DoarNota("04086238000132", "41170809551124000130650010009757311001824102");
            Assert.AreEqual("Documento fiscal doado com sucesso!", message, "Verifique se a nota usada no teste não está expirada.");
            
        }

        [TestMethod]
        public void TesteEnviarNotaEntidadeIncorreta()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));
            var message = target.DoarNota("04086238000123", "41170809551124000130650010009757311001824102");
            Assert.AreEqual("CNPJ inválido.", message, "Verifique se a nota usada no teste não está expirada.");

        }

        [TestMethod]
        public void TesteEnviarNotaEntidadeInválida()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));
            var message = target.DoarNota("04086238000", "41170809551124000130650010009757311001824102");
            Assert.AreEqual("CNPJ inválido.", message);

        }

        [TestMethod]
        public void TesteEnviarNotaExpirada()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));

            var message = target.DoarNota("04086238000132", "41170678116670000670650320001096291221755307");

            Assert.AreEqual("O prazo para doar esta nota expirou. A doação deve ocorrer no máximo até o mês seguinte a data de emissão da nota.", message);
        }

        [TestMethod]
        public void TesteEnviarNotaIncorreta()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));

            var message = target.DoarNota("04086238000132", "41170678116670000670650320001096291221755303");

            Assert.AreEqual("Chave de acesso inválida.", message);
        }


        [TestMethod]
        public void TesteEnviarNotasSucessivas()
        {
            target.Login("04972136995", new CryptoHelper().DecryptString(encryptedPassword));
            var message = target.DoarNota("04086238000132", "41170809551124000130650010009757311001824102");
            Assert.AreEqual("Documento fiscal doado com sucesso!", message);

            message = target.DoarNota("04086238000132", "41170678116670000670650320001096291221755307");

            Assert.AreEqual("O prazo para doar esta nota expirou. A doação deve ocorrer no máximo até o mês seguinte a data de emissão da nota.", message);

            message = target.DoarNota("04086238000132", "41170809551124000130650010009757311001824103");
            Assert.AreEqual("Chave de acesso inválida.", message);

            message = target.DoarNota("04086238000132", "41170809551124000130650010009757311001824102");
            Assert.AreEqual("Documento fiscal doado com sucesso!", message);
        }
    }
}

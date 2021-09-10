using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        //Setup
        //Inicializa o projeto
        public AoNavegarParaHome(TextFixture fixture)
        {
            driver = fixture.Driver; //inversão de dependência
        }            

        [Fact]
        public void DadoChromeAbertoDeveMostrarNomeDoTitulo()
        {
            //arrange está no construtor = Setup
           

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChormeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange está no construtor = Setup

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagemDeErro()
        {
            //arrange está no construtor = Setup

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}

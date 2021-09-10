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
            driver = fixture.Driver; //invers�o de depend�ncia
        }            

        [Fact]
        public void DadoChromeAbertoDeveMostrarNomeDoTitulo()
        {
            //arrange est� no construtor = Setup
           

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void DadoChormeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange est� no construtor = Setup

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagemDeErro()
        {
            //arrange est� no construtor = Setup

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

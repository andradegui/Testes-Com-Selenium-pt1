using Alura.LeilaoOnline.Selenium.Fixture;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        //Inicializa o projeto
        public AoEfetuarRegistro(TextFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrPraPaginaAgradecimento()
        {
            //arrange - dado chrome aberto, página inicial do sist. de leilões,
            //dados de registro informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //Password
            var inputPassword = driver.FindElement(By.Id("Password"));

            //ConfirmPassword
            var inputConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));

            //botao de registro
            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Guilherme");
            inputEmail.SendKeys("guilima102013@gmail.com");
            inputPassword.SendKeys("123");            
            inputConfirmPassword.SendKeys("123");

            //act - efetuo o registro
            btnRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "guilima102013@gmail.com", "123", "123")]
        [InlineData("Guilherme", "guilima102013", "123", "123")]
        [InlineData("Guilherme", "guilima102013@gmail,com", "123", "223")]
        [InlineData("Guilherme", "guilima102013@gmail,com", "123", "")]
        public void DadoInfoInvalidasDeveIrContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange - dado chrome aberto, página inicial do sist. de leilões,
            //dados de registro informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //Email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //Password
            var inputPassword = driver.FindElement(By.Id("Password"));

            //ConfirmPassword
            var inputConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));

            //botao de registro
            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(senha);
            inputConfirmPassword.SendKeys(confirmSenha);

            //act - efetuo o registro
            btnRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //botao de registro
            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            btnRegistro.Click();

            //assert        
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "guilima",
                senha: "",
                confirmSenha: ""
              );

            /* outra maneira de enviar dados ao form
             
            - pegando email
            var inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("guilima");
            
            - botao de registro
            var btnRegistro = driver.FindElement(By.Id("btnRegistro"));*/

            //act
            registroPO.SubmeteFormulario();

            //assert            
            Assert.Equal("Please enter a valid email address.", 
                registroPO.EmailMensagemErro);
        }


        

    }
}


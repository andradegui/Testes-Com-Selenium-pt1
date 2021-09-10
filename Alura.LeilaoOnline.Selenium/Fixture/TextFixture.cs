using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixture
{
    public class TextFixture : IDisposable
    {
        public IWebDriver Driver { get; set; }

        //Setup
        public TextFixture()
        {
            Driver = new ChromeDriver(TesteHelpers.PastaDoExecutavel);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}

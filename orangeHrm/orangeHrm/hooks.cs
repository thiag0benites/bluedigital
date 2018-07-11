//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Controla execuções utilizando specflow.
//*************************************************************************************************//
//*************************************************************************************************//

using System;
using System.Configuration;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace orangeHrm
{
    [Binding]
    //public sealed class hooks
    public class hooks
    {
        public static IWebDriver driver { get; set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //Registra Início do teste
            Console.WriteLine(DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + " : -- Início dos testes --");

            //Inicia navegador e acessa o sistema
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Registra fim do teste
            Console.WriteLine(DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + " : -- Fim dos testes --");
            
            //Fecha o Browser depois que termina os cenarios
            driver.Close();
            driver.Dispose();
        }   
        
    }
}

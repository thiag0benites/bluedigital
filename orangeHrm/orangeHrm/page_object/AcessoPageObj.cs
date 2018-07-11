//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Page Objects da tela de Login.
//*************************************************************************************************//
//*************************************************************************************************//

using OpenQA.Selenium;

namespace orangeHrm.step_definitions
{
    public class AcessoPageObj
    {
        private IWebDriver browser;

        public AcessoPageObj()
        {
            browser = hooks.driver;
        }

        // Formulário de Login //
        public IWebElement txt_usuario  { get { return browser.FindElement(By.Id("txtUsername")); } }
        public IWebElement txt_senha    { get { return browser.FindElement(By.Id("txtPassword")); } }
        public IWebElement btn_login    { get { return browser.FindElement(By.Id("btnLogin")); } }
        public IWebElement lbl_mensagem { get { return browser.FindElement(By.Id("spanMessage")); } }
    }
}
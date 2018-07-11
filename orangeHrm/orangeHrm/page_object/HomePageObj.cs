//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Page Objects da HomePage.
//*************************************************************************************************//
//*************************************************************************************************//

using OpenQA.Selenium;

namespace orangeHrm.page_object
{
    class HomePageObj
    {
        private IWebDriver browser;

        public HomePageObj()
        {
            browser = hooks.driver;
        }

        // HomePage //
        public IWebElement lbl_welcome { get { return browser.FindElement(By.Id("welcome")); } }

        // Menu Principal //
        public IWebElement lbl_menu_admin { get { return browser.FindElement(By.LinkText("Admin")); } }
    }
}

//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Passos dos testes de Acesso.
//*************************************************************************************************//
//*************************************************************************************************//

using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using orangeHrm.lib_auxiliar;
using orangeHrm.page_object;

namespace orangeHrm.step_definitions
{
    [Binding]
    public class AcessoSteps : AcessoPageObj
    {
        private MetodosAuxiliares Auxiliar;
        private HomePageObj HomePage;

        private AcessoSteps()
        {
            Auxiliar = new MetodosAuxiliares();
            HomePage = new HomePageObj();
        }

        [Given(@"que forneço os dados válidos de usuário ""(.*)"" e senha ""(.*)""")]
        public void DadoQueFornecoOsDadosValidosDeUsuarioESenha(string usuario, string senha)
        {
            txt_usuario.SendKeys(usuario);
            txt_senha.SendKeys(senha);
        }

        [When(@"efetuo click no botão login")]
        public void QuandoEfetuoClickNoBotaoLogin()
        {
            btn_login.Click();
        }

        [Then(@"o usuário deve ser redirecionado para home page")]
        public void EntaoOUsuarioDeveSerRedirecionadoParaHomePage()
        {
            Auxiliar.aguardaElemento(HomePage.lbl_welcome);
        }

        [Then(@"é apresentada a mensagem ""(.*)""")]
        public void EntaoEApresentadaAMensagem(string mensagem)
        {
            Auxiliar.aguardaElemento(lbl_mensagem);
            Assert.AreEqual(lbl_mensagem.Text, mensagem);
        }
    }
}
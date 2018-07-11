//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Passos dos testes de cadastro.
//*************************************************************************************************//
//*************************************************************************************************//

using orangeHrm.lib_auxiliar;
using orangeHrm.page_object;
using TechTalk.SpecFlow;

namespace orangeHrm.step_definitions
{
    [Binding]
    public class CadastrarSteps
    {
        private CadastroPageObj Cadastrar;
        private MetodosAuxiliares Auxiliar;
        private HomePageObj HomePage;

        private CadastrarSteps()
        {
            Cadastrar = new CadastroPageObj();
            Auxiliar = new MetodosAuxiliares();
            HomePage = new HomePageObj();
        }

        [Given(@"que acesso o menu ""(.*)""")]
        public void DadoQueAcessoOMenu(string itemMenu)
        {
            HomePage.lbl_menu_admin.Click();
            Auxiliar.aguardaElemento(Cadastrar.btn_add);
        }

        [When(@"efetuo click no botão Add")]
        public void QuandoEfetuoClickNoBotaoAdd()
        {
            Cadastrar.btn_add.Click();
            Auxiliar.aguardaElemento(Cadastrar.cbo_userrole);
        }

        [Then(@"cadastro e valido inclusão do\(s\) usuário\(s\)")]
        public void EntaoCadastroEValidoInclusaoDoSUsuarioS(Table tabela)
        {
            Cadastrar.cadastrarUsuarios(tabela);
        }
    }
}
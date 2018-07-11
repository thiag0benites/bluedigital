//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Page Objects da tela de cadastro.
//*************************************************************************************************//
//*************************************************************************************************//

using NUnit.Framework;
using OpenQA.Selenium;
using orangeHrm.lib_auxiliar;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace orangeHrm.page_object
{
    class CadastroPageObj
    {
        private IWebDriver browser;
        private MetodosAuxiliares Auxiliar;

        public CadastroPageObj()
        {
            Auxiliar = new MetodosAuxiliares();
            browser = hooks.driver;
        }

        // Elementos iniciais do Cadastro //
        public IWebElement btn_add         { get { return browser.FindElement(By.Id("btnAdd")); } }
        public IWebElement tbl_usuarios    { get { return browser.FindElement(By.Id("tableWrapper")); } }

        // Formulário de cadastro de usuário //
        public IWebElement cbo_userrole    { get { return browser.FindElement(By.Id("systemUser_userType")); } }
        public IWebElement txt_employee    { get { return browser.FindElement(By.Id("systemUser_employeeName_empName")); } }
        public IWebElement txt_username    { get { return browser.FindElement(By.Id("systemUser_userName")); } }
        public IWebElement cbo_status      { get { return browser.FindElement(By.Id("systemUser_status")); } }
        public IWebElement txt_password    { get { return browser.FindElement(By.Id("systemUser_password")); } }
        public IWebElement txt_confirmpass { get { return browser.FindElement(By.Id("systemUser_confirmPassword")); } }
        public IWebElement btn_save        { get { return browser.FindElement(By.Id("btnSave")); } }


        //***********************************************************************************************************//
        // MÉTODOS DE CADASTRO
        //***********************************************************************************************************//
        public void cadastrarUsuarios(Table tabela)
        {
            try
            {
                var dados = tabela.CreateSet<MassaDados>();

                foreach (MassaDados dado in dados)
                {
                    cbo_userrole.SendKeys(dado.UserRole);
                    txt_employee.SendKeys(dado.EmployeeName);
                    txt_username.SendKeys(dado.UserName);
                    cbo_status.SendKeys(dado.Status);
                    txt_password.SendKeys(dado.Password);
                    txt_confirmpass.SendKeys(dado.Password);

                    btn_save.Click();
                    Auxiliar.aguardaElemento(btn_add);

                    //Array para validação do cadastro
                    string[] validacao = new string[] { dado.UserName, dado.UserRole, dado.EmployeeName, dado.Status };
                    validaCadastro(validacao);

                    btn_add.Click();
                    Auxiliar.aguardaElemento(cbo_userrole);
                }

            } catch(Exception e){
                Assert.Fail("Erro: Não foi possível cadastrar usuário(s)! Exceção: " + e.Message);
            }
        }

        public void validaCadastro(string[] dados)
        {
            int contLinha = 1;
            bool valorLocalizado = false;
            string valorEsperado = null;
            string valorEncontrado = null;

            try
            {
                var linhas = tbl_usuarios.FindElements(By.TagName("tr"));

                foreach (var linha in linhas)
                {
                    int contColuna = 0;
                    var colunas = linha.FindElements(By.TagName("td"));

                    foreach (var coluna in colunas)
                    {
                        // Ignora primeira coluna com checkbox
                        if (contColuna > 0)
                        {
                            valorEsperado = dados[contColuna - 1];
                            valorEncontrado = coluna.Text;

                            // Compara dados cadastrados com massa de dados
                            if (valorEsperado == valorEncontrado)
                            {
                                valorLocalizado = true;
                            }
                        }

                        contColuna++;
                    }

                    contLinha++;
                }

                if (valorLocalizado == false)
                {
                    Assert.Fail("Cadastro não foi realizado corretamente! Linha: " + contLinha + " | Valor Esperado: " + valorEsperado + " | Valor Encontrado: " + valorEncontrado);
                }

            }
            catch (Exception e)
            {
                Assert.Fail("Erro: Não foi possível validar o cadastro! Exceção: " + e.Message);
            }    
        }
    }
}
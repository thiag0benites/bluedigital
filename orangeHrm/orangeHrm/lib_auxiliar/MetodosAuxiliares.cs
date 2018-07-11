using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
//*************************************************************************************************//
// Projeto: AVALIAÇÃO BLUE DIGITAL
//*************************************************************************************************//
// Autor: Thiago Benites
// Data: 11/07/2018
// Sistema: OrangeHrm Demo
// Descrição: Métodos auxiliares de elementos.
//*************************************************************************************************//
//*************************************************************************************************//

namespace orangeHrm.lib_auxiliar
{
    public class MetodosAuxiliares
    {
        public void aguardaElemento(IWebElement elemento)
        {
            int cont = 0;

            do
            {
                cont++;

                if (!elemento.Displayed && cont == 30)
                {
                    Assert.Fail("O elemento " + elemento + " não foi encontrado!");
                    break;
                }
                else if (elemento.Displayed)
                {
                    //Elemento visivel
                    break;
                }

                Thread.Sleep(1000);

            } while (cont <= 30);
        }
    }
}

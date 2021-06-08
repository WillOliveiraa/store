using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Willian Oliveira", "will@teste.com");
        private readonly Product _product = new Product("Teclado Gamer", 350, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));
        
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var order = new Order(_customer, 15, _discount);
            
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 15, _discount);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }
    }
}

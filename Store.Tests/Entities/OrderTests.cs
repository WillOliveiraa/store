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
        private Order _order;

        [TestInitialize]
        public void SetUp()
        {
            _order = new Order(_customer, 15, _discount);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            Assert.AreEqual(8, _order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingPayment);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            _order.AddItem(_product, 1);
            _order.Pay(355);
            Assert.AreEqual(_order.Status, EOrderStatus.WaitingDelivery);
        }
    }
}

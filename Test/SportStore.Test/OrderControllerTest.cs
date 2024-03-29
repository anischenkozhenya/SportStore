﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using SportStore.Models;
using SportStore.Controllers;
using Xunit;

namespace SportStore.Test
{
    public class OrderControllerTest
    {

        [Fact]
        public void Cannot_Empty_Cart()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            Order order = new Order();
            OrderController target = new OrderController(mock.Object, cart);
            ViewResult result = target.Checkout(order) as ViewResult;
            mock.Verify(m=>m.SaveOrder(It.IsAny<Order>()),Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);
        }
        [Fact]
        public void Cannot_Invalid_ShippingDetails()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);
            target.ModelState.AddModelError("error", "error");
            ViewResult result = target.Checkout(new Order()) as ViewResult;

            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            Assert.False(result.ViewData.ModelState.IsValid);

        }
        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);
            RedirectToActionResult result = target.Checkout(new Order()) as RedirectToActionResult;
            mock.Verify(m=>m.SaveOrder(It.IsAny<Order>()),Times.Once);
            Assert.Equal("Completed", result.ActionName);
        }
    }
}

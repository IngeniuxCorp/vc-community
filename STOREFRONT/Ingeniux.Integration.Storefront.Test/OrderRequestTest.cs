using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtoCommerce.Client.Model;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class OrderRequestTest : StorefrontTestBase
	{
		[TestMethod]
		public void GetPaymentMethodsForStoreTest()
		{
			var stores = StoreApi.StoreModuleGetStores();
			Assert.IsTrue(stores.Any());

			var store = stores.FirstOrDefault();
			if (store != null)
			{
				var paymentMethods = ShoppingCartApi.CartModuleGetPaymentMethodsForStore(store.Id);
				Assert.IsTrue(paymentMethods.Any());

				var storePaymentMethods = store.PaymentMethods.Where(x => x.IsActive == true).ToList();
				Assert.IsTrue(storePaymentMethods.Any());
			}
		}

		[TestMethod]
		public void CreateOrderTest()
		{
			var testOrder = GetTestOrder("order");
			var order = OrderApi.OrderModuleCreateOrder(testOrder);
			Assert.IsTrue(order != null);
		}

		private VirtoCommerceOrderModuleWebModelCustomerOrder GetTestOrder(string id)
		{
			var order = new VirtoCommerceOrderModuleWebModelCustomerOrder
			{
				Id = id,
				Currency = "USD",
				CustomerId = "vasja customer",
				EmployeeId = "employe",
				StoreId = "test store",
				Addresses = new []
				{
					new VirtoCommerceOrderModuleWebModelAddress {
					AddressType = "2", //Shipping 
					City = "london",
					Phone = "+68787687",
					PostalCode = "22222",
					CountryCode = "ENG",
					CountryName = "England",
					Email = "user@mail.com",
					FirstName = "first name",
					LastName = "last name",
					Line1 = "line 1",
					Organization = "org1"
					}
				}.ToList(),
				Discount = new VirtoCommerceOrderModuleWebModelDiscount
				{
					PromotionId = "testPromotion",
					Currency = "USD",
					DiscountAmount = 12,
					Coupon = new VirtoCommerceOrderModuleWebModelCoupon
					{
						Code = "ssss"
					}
				}
			};
			var item1 = new VirtoCommerceOrderModuleWebModelLineItem
			{
				Sku = "1",
				BasePrice = 10,
				Price = 9,
				DisplayName = "shoes",
				ProductId = "shoes",
				CatalogId = "catalog",
				Currency = "USD",
				CategoryId = "category",
				Name = "shoes",
				Quantity = 2,
				FulfilmentLocationCode = "warehouse1",
				ShippingMethodCode = "EMS",
				Discount = new VirtoCommerceOrderModuleWebModelDiscount
				{
					PromotionId = "itemPromotion",
					Currency = "USD",
					DiscountAmount = 12,
					Coupon = new VirtoCommerceOrderModuleWebModelCoupon
					{
						Code = "ssss"
					}
				}
			};
			var item2 = new VirtoCommerceOrderModuleWebModelLineItem
			{
				Sku = "2",
                BasePrice = 100,
				Price = 100,
				DisplayName = "t-shirt",
				ProductId = "t-shirt",
				CatalogId = "catalog",
				CategoryId = "category",
				Currency = "USD",
				Name = "t-shirt",
				Quantity = 2,
				FulfilmentLocationCode = "warehouse1",
				ShippingMethodCode = "EMS",
				Discount = new VirtoCommerceOrderModuleWebModelDiscount
				{
					PromotionId = "testPromotion",
					Currency = "USD",
					DiscountAmount = 12,
					Coupon = new VirtoCommerceOrderModuleWebModelCoupon
					{
						Code = "ssss"
					}
				}
			};
			order.Items = new List<VirtoCommerceOrderModuleWebModelLineItem> {item1, item2};

			var shipment = new VirtoCommerceOrderModuleWebModelShipment
			{
				Currency = "USD",
				DeliveryAddress = new VirtoCommerceOrderModuleWebModelAddress
				{
					City = "london",
					CountryName = "England",
					Phone = "+68787687",
					PostalCode = "2222",
					CountryCode = "ENG",
					Email = "user@mail.com",
					FirstName = "first name",
					LastName = "last name",
					Line1 = "line 1",
					Organization = "org1"
				},
				Discount = new VirtoCommerceOrderModuleWebModelDiscount
				{
					PromotionId = "testPromotion",
					Currency = "USD",
					DiscountAmount = 12,
					Coupon = new VirtoCommerceOrderModuleWebModelCoupon
					{
						Code = "ssss"
					}
				},

			};

			shipment.Items = new List<VirtoCommerceOrderModuleWebModelShipmentItem>();
			shipment.Items.AddRange(order.Items.Select(x => new VirtoCommerceOrderModuleWebModelShipmentItem { Quantity = x.Quantity, LineItem = x }));

			order.Shipments = new List<VirtoCommerceOrderModuleWebModelShipment> {shipment};

			var payment = new VirtoCommerceOrderModuleWebModelPaymentIn
			{
				Currency = "USD",
				Sum = 10,
				CustomerId = "et"
			};
			order.InPayments = new List<VirtoCommerceOrderModuleWebModelPaymentIn> {payment};

			return order;
		}
	}
}

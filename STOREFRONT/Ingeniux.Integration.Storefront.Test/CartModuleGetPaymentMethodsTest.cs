using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class CartModuleGetPaymentMethodsTest : StorefrontTestBase
	{
		[TestMethod]
		public void GetPaymentMethodsForStoreTest()
		{
			var paymentMethods = ShoppingCartApi.CartModuleGetPaymentMethodsForStore(StoreId);
			Assert.IsTrue(paymentMethods.Any());
		}

		[TestMethod]
		public void GetActivePaymentMethods()
		{
			var store = StoreApi.StoreModuleGetStoreById(StoreId);
			var storePaymentMethods = store.PaymentMethods.Where(x => x.IsActive == true).ToList();
			Assert.IsTrue(storePaymentMethods.Any());
		}
	}
}

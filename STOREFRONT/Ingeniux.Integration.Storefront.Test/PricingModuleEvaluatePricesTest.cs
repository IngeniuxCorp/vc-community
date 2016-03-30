using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtoCommerce.Client.Model;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class PricingModuleEvaluatePricesTest : StorefrontTestBase
	{
		private readonly string catalogId = "7187a9b3f1914a1fb4cea9d56419dc83";
		private readonly string _currency = "USD";
		private readonly string _searchCriteriaResponseGroup = "Full";

		[TestMethod]
		public void EvaluatePricesTest()
		{
			var priceLists = PricingApi.PricingModuleGetPriceLists();
			Assert.IsTrue(priceLists.Any());

			var searchResult = CatalogSearchAllProducts();
			Assert.IsTrue(searchResult.ProductsTotalCount > 0);

			var product = searchResult.Products.FirstOrDefault();
			if (product != null)
			{
				//Evaluate products prices
				var evalContext = new VirtoCommerceDomainPricingModelPriceEvaluationContext
				{
					ProductIds = new List<string> {product.Id},
					CatalogId = catalogId,
					StoreId = StoreId,
					Currency = _currency,
				};

				//anonymous registration
				evalContext.Tags = new List<string> { "ANONYMOUS" };
				var evaluatePrice = PricingApi.PricingModuleEvaluatePrices(evalContext);
				Assert.IsTrue(evaluatePrice.Any() && evaluatePrice[0].List == 100);

				//registered
				evalContext.Tags = new List<string> { "REGISTERED" };
				evaluatePrice = PricingApi.PricingModuleEvaluatePrices(evalContext);
				Assert.IsTrue(evaluatePrice.Any() && evaluatePrice[0].List == 99);

				//registered with certain location
				evalContext.Tags = new List<string> { "REGISTERED", "USA" };
				evaluatePrice = PricingApi.PricingModuleEvaluatePrices(evalContext);
				Assert.IsTrue(evaluatePrice.Count >= 2 && evaluatePrice.First().List == 98);

				evalContext.Tags = new List<string> { "DEU", "REGISTERED" };
				evaluatePrice = PricingApi.PricingModuleEvaluatePrices(evalContext);
				Assert.IsTrue(evaluatePrice.Any() && evaluatePrice[0].List == 97);

				evalContext.Tags = new List<string> { "ITA" };
				evaluatePrice = PricingApi.PricingModuleEvaluatePrices(evalContext);
				Assert.IsTrue(evaluatePrice.Any() && evaluatePrice[0].List == 96);
			}
		}

		private VirtoCommerceCatalogModuleWebModelCatalogSearchResult CatalogSearchAllProducts()
		{
			var searchCriteria = new VirtoCommerceDomainCatalogModelSearchCriteria
			{
				StoreId = StoreId,
				CatalogId = catalogId,
				Currency = _currency,
				ResponseGroup = _searchCriteriaResponseGroup,
				Skip = 0,
				Take = 10,
				WithHidden = false,
				SearchInChildren = true,
			};

			return CatalogApi.CatalogModuleSearchSearch(searchCriteria);
		}
    }
}

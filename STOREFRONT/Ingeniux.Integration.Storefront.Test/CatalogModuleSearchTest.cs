using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtoCommerce.Client.Model;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class CatalogModuleSearchTest : StorefrontTestBase
	{
		private readonly string _catalogId = "7187a9b3f1914a1fb4cea9d56419dc83";
		private readonly string _currency = "USD";
		private readonly string _searchCriteriaResponseGroup = "Full";

		[TestMethod]
		public void SearchTest()
		{
			var tagsTestCollection = new Dictionary<string, double>
			{
				{ "ANONYMOUS", 100 }, //tag isn't defined
				{ "REGISTERED", 99 },
				{ "USA", 98 },
				{ "DEU", 97 },
				{ "ITA", 96 },
				{ "demo@site.com", 95 },
			};

			foreach (var pairTagValue in tagsTestCollection)
			{
				var tag = pairTagValue.Key;
				var successValue = pairTagValue.Value;

				var tags = tag == "ANONYMOUS" ? null : new List<string> {tag};
                var priceLists = GetPriceListsByTags(tags);
				Assert.IsTrue(priceLists.Any());

				var searchResult = CatalogSearchByPricelistIds(priceLists.Select(x => x.Id).ToList());
				Assert.IsTrue(searchResult.ProductsTotalCount > 0);

				var product = searchResult.Products.First(x => x.Id == "770f6c850c9143a7a95342c7ff7aa9d5");
                var evaluatePrices = GetEvaluatePrices(new List<string> {product.Id}, priceLists.Select(x => x.Id).ToList());
				Assert.IsTrue(evaluatePrices.Any() && evaluatePrices[0].List == successValue);
			}
		}



		private List<VirtoCommercePricingModuleWebModelPricelist> GetPriceListsByTags(List<string> tags)
		{
			//Evaluate products prices
			var evalContext = new VirtoCommerceDomainPricingModelPriceEvaluationContext
			{
				CatalogId = _catalogId,
				StoreId = StoreId,
				Currency = _currency,
				Tags = tags
			};

			return PricingApi.PricingModuleEvaluatePriceLists(evalContext);
		}

		private VirtoCommerceCatalogModuleWebModelCatalogSearchResult CatalogSearchByPricelistIds(List<string> pricelistIds)
		{
			var searchCriteria = new VirtoCommerceDomainCatalogModelSearchCriteria
			{
				StoreId = StoreId,
				CatalogId = _catalogId,
				Currency = _currency,
				ResponseGroup = _searchCriteriaResponseGroup,
				Skip = 0,
				Take = 10,
				WithHidden = false,
				SearchInChildren = true,
				PricelistIds = pricelistIds,
				StartPrice = 0.01
			};

			return CatalogApi.CatalogModuleSearchSearch(searchCriteria);
		}

		private List<VirtoCommercePricingModuleWebModelPrice> GetEvaluatePrices(List<string> productIds, List<string> pricelistIds)
		{
			//Evaluate products prices
			var evalContext = new VirtoCommerceDomainPricingModelPriceEvaluationContext
			{
				ProductIds = productIds,
				PricelistIds = pricelistIds,
				CatalogId = _catalogId,
				StoreId = StoreId,
				Currency = _currency,
			};

			return PricingApi.PricingModuleEvaluatePrices(evalContext);
		}
	}
}

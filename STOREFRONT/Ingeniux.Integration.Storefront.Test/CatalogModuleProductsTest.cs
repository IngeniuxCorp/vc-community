using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtoCommerce.Client.Model;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class CatalogModuleProductsTest: StorefrontTestBase
	{
		private readonly string _productId = "cbb10a2516ba4126b767a3f421b5d759";
		private readonly string _requiredAssociationName = "Required";
		private readonly string _relatedAssociationName = "Related Items";

		//enum ItemResponseGroup:
		//ItemSmall = ItemInfo | ItemAssets | ItemEditorialReviews | Seo,
		//ItemMedium = ItemSmall | ItemAssociations | ItemProperties,
		//ItemLarge = ItemMedium | Variations | Links | Inventory | ItemWithPrices | ItemWithDiscounts

		private readonly string _associationsResponseGroup = "ItemAssociations";
		private readonly string _productResponseGroup = "ItemLarge";

		[TestMethod]
		public void GetProductAssociations()
		{
			var result = CatalogApi.CatalogModuleProductsGetProductByIds(new List<string> {_productId}, _associationsResponseGroup);
			Assert.IsTrue(result.Any());

			if (result.Any())
			{
				var associations = result[0].Associations;
				Assert.IsTrue(associations.Any(x => x.Name == _requiredAssociationName));

				var requiredProducts = CatalogApi.CatalogModuleProductsGetProductByIds(
					associations.Where(x => x.Name == _requiredAssociationName).Select(x => x.ProductId).ToList(), _productResponseGroup);

				Assert.IsTrue(requiredProducts.Any());

				Assert.IsTrue(associations.Any(x => x.Name == _relatedAssociationName));

				var relatedProducts = CatalogApi.CatalogModuleProductsGetProductByIds(
					associations.Where(x => x.Name == _requiredAssociationName).Select(x => x.ProductId).ToList(), _productResponseGroup);

				Assert.IsTrue(relatedProducts.Any());
			}
		}
	}
}

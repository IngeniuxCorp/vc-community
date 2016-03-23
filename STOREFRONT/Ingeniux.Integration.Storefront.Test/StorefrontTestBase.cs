using System;
using System.Configuration;
using VirtoCommerce.Client;
using VirtoCommerce.Client.Api;
using VirtoCommerce.Client.Client;

namespace Ingeniux.Integration.Storefront.Test
{
	public class StorefrontTestBase
	{
		public CatalogModuleApi CatalogApi;
		public CMSContentModuleApi CmsContentApi;
		public CommerceCoreModuleApi CommerceApi;
		public CustomerManagementModuleApi CustomerManagementApi;
		public InventoryModuleApi InventoryApi;
		public MarketingModuleApi MarketingApi;
		public OrderModuleApi OrderApi;
		public PricingModuleApi PricingApi;
		public QuoteModuleApi QuoteApi;
		public SearchModuleApi SearchApi;
		public ShoppingCartModuleApi ShoppingCartApi;
		public StoreModuleApi StoreApi;
		public VirtoCommercePlatformApi VirtoCommercePlatformApi;

		public StorefrontTestBase()
		{
			var apiClientCfg = new VirtoCommerce.Client.Client.Configuration(GetApiClient());

			CatalogApi = new CatalogModuleApi(apiClientCfg);
			CmsContentApi = new CMSContentModuleApi(apiClientCfg);
			CommerceApi = new CommerceCoreModuleApi(apiClientCfg);
			CustomerManagementApi = new CustomerManagementModuleApi(apiClientCfg);
			InventoryApi = new InventoryModuleApi(apiClientCfg);
			MarketingApi = new MarketingModuleApi(apiClientCfg);
			OrderApi = new OrderModuleApi(apiClientCfg);
			PricingApi = new PricingModuleApi(apiClientCfg);
			QuoteApi = new QuoteModuleApi(apiClientCfg);
			SearchApi = new SearchModuleApi(apiClientCfg);
			ShoppingCartApi = new ShoppingCartModuleApi(apiClientCfg);
			StoreApi = new StoreModuleApi(apiClientCfg);
			VirtoCommercePlatformApi = new VirtoCommercePlatformApi(apiClientCfg);
		}

		protected ApiClient GetApiClient()
		{
			var baseUrl = ConfigurationManager.ConnectionStrings["VirtoCommerceBaseUrl"].ConnectionString;
			var apiClient = new HmacApiClient(baseUrl, ConfigurationManager.AppSettings["vc-public-ApiAppId"], ConfigurationManager.AppSettings["vc-public-ApiSecretKey"]);
			return apiClient;
		}
	}
}

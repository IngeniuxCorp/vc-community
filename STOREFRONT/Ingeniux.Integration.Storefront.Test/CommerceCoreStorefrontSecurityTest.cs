using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtoCommerce.Client.Api;
using VirtoCommerce.Client.Model;

namespace Ingeniux.Integration.Storefront.Test
{
	[TestClass]
	public class CommerceCoreStorefrontSecurityTest : StorefrontTestBase
	{
		private VirtoCommerceCoreModuleWebModelStorefrontUser _user;

		[TestInitialize]
		public void Initialize()
		{
			_user = CommerceCoreApi.StorefrontSecurityGetUserByName("frontend");
		}

		[TestMethod]
		public void StorefrontSecurityCreateTest()
		{
			var user = new VirtoCommercePlatformCoreSecurityApplicationUserExtended
			{
				Email = "test@site.com",
				Password = "store",
				UserName = "test@site.com",
				UserType = "Customer",
				StoreId = StoreId,
			};

			var result = CommerceCoreApi.StorefrontSecurityCreate(user);
			Assert.IsTrue(result != null);

			if (result.Succeeded == true)
			{
				var storefrontUser = CommerceCoreApi.StorefrontSecurityGetUserByName(user.UserName);
				Assert.IsTrue(storefrontUser != null);
			}
			else
			{
				Assert.IsTrue(result.Errors[0] == @"Name test@site.com is already taken.");
			}
		}
	}
}

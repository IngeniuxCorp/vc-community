using Ingeniux.OracleSoa.Services;
using Microsoft.Practices.Unity;
using VirtoCommerce.Platform.Core.Modularity;

namespace Ingeniux.OracleSoa
{
	public class Module : ModuleBase
	{
		private readonly IUnityContainer _container;

		public Module(IUnityContainer container)
		{
			_container = container;
		}

		public override void SetupDatabase()
		{
		}
		public override void Initialize()
		{
			_container.RegisterType<IUserService, MockUserService>();
			_container.RegisterType<IOrderService, MockOrderService>();

			base.Initialize();
		}
		public override void PostInitialize()
		{
		}
	}
}

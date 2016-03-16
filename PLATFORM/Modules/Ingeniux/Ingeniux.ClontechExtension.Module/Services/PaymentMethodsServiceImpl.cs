using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Payment.Model;
using VirtoCommerce.Domain.Payment.Services;

namespace Ingeniux.ClontechExtension.Module.Services
{
    public class PaymentMethodsServiceImpl : IPaymentMethodsService
    {
        private List<Func<PaymentMethod>> _paymentMethods = new List<Func<PaymentMethod>>();

        public PaymentMethod[] GetAllPaymentMethods()
        {
            return _paymentMethods.Select(x => x()).ToArray();
        }

        public void RegisterPaymentMethod(Func<PaymentMethod> methodGetter)
        {
            if (methodGetter == null)
            {
                throw new ArgumentNullException("methodGetter");
            }

            var existedPaymentMethodFunc = _paymentMethods.FirstOrDefault(p => p().Code == methodGetter().Code);
            if(existedPaymentMethodFunc != null)
            {
                _paymentMethods.Remove(existedPaymentMethodFunc);
            }

            _paymentMethods.Add(methodGetter);
        }
    }
}
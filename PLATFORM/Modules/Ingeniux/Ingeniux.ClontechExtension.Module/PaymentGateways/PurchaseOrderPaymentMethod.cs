﻿using System;
using VirtoCommerce.Domain.Payment.Model;

namespace Ingeniux.ClontechExtension.Module.PaymentGateways
{
    public class PurchaseOrderPaymentMethod : PaymentMethod
    {
        public PurchaseOrderPaymentMethod(string name) : base(name)
        {
        }


        public override PaymentMethodType PaymentMethodType
        {
            get { return PaymentMethodType.Unknown; }
        }

        public override PaymentMethodGroupType PaymentMethodGroupType
        {
            get { return PaymentMethodGroupType.Manual; }
        }

        public override ProcessPaymentResult ProcessPayment(ProcessPaymentEvaluationContext context)
        {
            context.Payment.PaymentStatus = PaymentStatus.Authorized;
            context.Payment.OuterId = context.Payment.Number;
            context.Payment.CapturedDate = DateTime.UtcNow;
            return new ProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Authorized };
        }

        public override PostProcessPaymentResult PostProcessPayment(PostProcessPaymentEvaluationContext context)
        {
            throw new NotImplementedException();
        }

        public override VoidProcessPaymentResult VoidProcessPayment(VoidProcessPaymentEvaluationContext context)
        {
            context.Payment.IsApproved = false;
            context.Payment.PaymentStatus = PaymentStatus.Voided;
            context.Payment.VoidedDate = DateTime.UtcNow;
            context.Payment.IsCancelled = true;
            context.Payment.CancelledDate = DateTime.UtcNow;
            return new VoidProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Voided };
        }

        public override CaptureProcessPaymentResult CaptureProcessPayment(CaptureProcessPaymentEvaluationContext context)
        {
            context.Payment.IsApproved = true;
            context.Payment.PaymentStatus = PaymentStatus.Paid;
            context.Payment.VoidedDate = DateTime.UtcNow;
            return new CaptureProcessPaymentResult { IsSuccess = true, NewPaymentStatus = PaymentStatus.Paid };
        }

        public override RefundProcessPaymentResult RefundProcessPayment(RefundProcessPaymentEvaluationContext context)
        {
            throw new NotImplementedException();
        }

        public override ValidatePostProcessRequestResult ValidatePostProcessRequest(System.Collections.Specialized.NameValueCollection queryString)
        {
            return new ValidatePostProcessRequestResult { IsSuccess = false };
        }
    }
}
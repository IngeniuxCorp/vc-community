﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using VirtoCommerce.Domain.Common;
using VirtoCommerce.Domain.Marketing.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.MarketingModule.Expressions.Promotion
{
	public class PromoDynamicExpressionTree : DynamicExpression, IConditionExpression, IRewardExpression
	{
		#region IConditionExpression Members

		public System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetConditionExpression()
		{
			var retVal = PredicateBuilder.True<IEvaluationContext>();
			foreach (var expression in Children.OfType<IConditionExpression>().Select(x => x.GetConditionExpression()).Where(x=> x != null))
			{
				retVal = retVal.And(expression);
			}
			return retVal;
		}

		#endregion

		#region IActionExpression Members

		public PromotionReward[] GetRewards()
		{
			var retVal = Children.OfType<IRewardExpression>().SelectMany(x => x.GetRewards()).OfType<PromotionReward>().ToArray();

			return retVal;
		}

		#endregion
	}
}
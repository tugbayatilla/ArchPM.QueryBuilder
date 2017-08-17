﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ArchPM.Core.Extensions.ObjectExtensions;
using ArchPM.Core.Extensions.TypeExtensions;
using ArchPM.Core.Extensions;
using ArchPM.QueryBuilder.ContentItems;

namespace ArchPM.QueryBuilder.MethodCalls
{
    class StartsWith : IMethodCall
    {
        public String Name { get { return "StartsWith"; } }

        public void Handle(DecisionMaker DecisionMaker, List<IContentItem> sb, MethodCallExpression expression)
        {
            DecisionMaker.ExpressionHandle(sb, expression.Object);
            sb.Add(new OperatorContentItem(Operators.LIKE));
            DecisionMaker.ExpressionHandle(sb, expression.Arguments[0]);
            var last = sb.Last();
            last.Value = String.Format("{0}{1}", last.Value, Operators.PERCENT.GetDescription());
        }
    }
}
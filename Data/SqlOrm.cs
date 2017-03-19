using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Data
{
    public class SqlOrm
    {
        public List<T> Query<T>(Expression<Func<T, bool>> expr)
        {
            AnalysisExpression(expr);
            return null;
        }

        public void AnalysisExpression(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Call:
                    MethodCallExpression method = expression as MethodCallExpression;
                    for (var i = 0; i < method.Arguments.Count; i++)
                        AnalysisExpression(method.Arguments[i]);
                    break;
                case ExpressionType.Lambda:
                    LambdaExpression lambda = expression as LambdaExpression;
                    AnalysisExpression(lambda.Body);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                    BinaryExpression binary = expression as BinaryExpression;
                    AnalysisExpression(binary.Left);
                    AnalysisExpression(binary.Right);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constant = expression as ConstantExpression;
                    var str = constant.Value;
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression member = expression as MemberExpression;
                    var str1 = member.Member.Name;
                    break;
                default: break;
            }
        }
    }
}

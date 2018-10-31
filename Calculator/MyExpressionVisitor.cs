using Extensions;
using System.Linq.Expressions;
using System.Text;

namespace Calculator
{
    class MyExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var needParentheses = false;
            if (node.NodeType == ExpressionType.Divide && node.Left is BinaryExpression)
                    needParentheses = true;
            else if (node.NodeType.In(ExpressionType.Multiply, ExpressionType.MultiplyChecked) &&
                        node.Left is BinaryExpression b1 && b1.NodeType.In(ExpressionType.Add, ExpressionType.AddChecked, ExpressionType.Subtract, ExpressionType.SubtractChecked))
                    needParentheses = true;

            if (needParentheses)
                s.Append("(");

            Visit(node.Left);

            if (needParentheses)
                s.Append(")");

            switch (node.NodeType)
            {
                case ExpressionType.AddChecked:
                case ExpressionType.Add:
                    s.Append(" + ");
                    break;
                case ExpressionType.Divide:
                    s.Append(" / ");
                    break;
                case ExpressionType.SubtractChecked:
                case ExpressionType.Subtract:
                    s.Append(" - ");
                    break;
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Multiply:
                    s.Append(" * ");
                    break;
            }

            Visit(node.Right);


            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is double d)
                s.Append(d.ToString("0.##"));
            else if (node.Value is decimal m)
                s.Append(m.ToString("0.##"));

            return node;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            s.Append(node.Name);
            return node;
        }

        StringBuilder s = new StringBuilder();
        public string GetStringRepresentation(Expression ex)
        {
            Clear();
            Visit(ex);
            return s.ToString();
        }
        public void Clear() => s = new StringBuilder();
    }
}

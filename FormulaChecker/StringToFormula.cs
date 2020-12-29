using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaChecker
{
	public static class StringToFormula
	{
		private static string[] _operators = { "-", "+", "/", "*", "^" };
		private static Func<double, double, double>[] _operations = {
		(a1, a2) => a1 - a2,
		(a1, a2) => a1 + a2,
		(a1, a2) => a1 / a2,
		(a1, a2) => a1 * a2,
		(a1, a2) => Math.Pow(a1, a2)
		};

		public static double Eval(string expression)
		{
			var tokens = getTokens(expression);
			var operandList = new List<double>();
			var operatorList = new List<string>();
			int tokenIndex = 0;

			while (tokenIndex < tokens.Count)
			{
				var token = tokens[tokenIndex];
				if (token == "(")
				{
					var subExpr = getSubExpression(tokens, ref tokenIndex);
					operandList.Add(Eval(subExpr));
					continue;
				}
				if (token == ")")
				{
					throw new ArgumentException("Mis-matched parentheses in expression");
				}
				//If this is an operator  
				if (Array.IndexOf(_operators, token) >= 0)
				{
					operatorList.Add(token);
				}
				else
				{
					operandList.Add(double.Parse(token));
				}
				tokenIndex += 1;
			}

			while (operatorList.Count > 0)
			{
				var op = operatorList.GetAndDeleteFirstElement();
				var operatorIndex = Array.IndexOf(_operators, op);

				var arg1 = operandList.GetAndDeleteFirstElement();
				var arg2 = operandList.GetAndDeleteFirstElement();

				var result = _operations[operatorIndex](arg1, arg2);

				operandList.Insert(0,result);
			}

			var commonResult = operandList.GetAndDeleteFirstElement();

			return commonResult;
		}

		private static string getSubExpression(List<string> tokens, ref int index)
		{
			var subExpr = new StringBuilder();
			var parenlevels = 1;
			index += 1;
			while (index < tokens.Count && parenlevels > 0)
			{
				var token = tokens[index];
				if (tokens[index] == "(")
				{
					parenlevels += 1;
				}

				if (tokens[index] == ")")
				{
					parenlevels -= 1;
				}

				if (parenlevels > 0)
				{
					subExpr.Append(token);
				}

				index += 1;
			}

			if ((parenlevels > 0))
			{
				throw new ArgumentException("Mis-matched parentheses in expression");
			}
			return subExpr.ToString();
		}

		private static List<string> getTokens(string expression)
		{
			var operators = "()^*/+-";
			var tokens = new List<string>();
			var sb = new StringBuilder();

			foreach (var c in expression.Replace(" ", string.Empty))
			{
				if (operators.IndexOf(c) >= 0)
				{
					if (sb.Length == 0 && "-".IndexOf(c) >= 0)
					{
						tokens.Add("0");
						tokens.Add(c.ToString());
					}
					else
					{
						if ((sb.Length > 0))
						{
							tokens.Add(sb.ToString());
							sb.Length = 0;
						}

						tokens.Add(c.ToString());
					}
				}
				else
				{
					sb.Append(c);
				}
			}

			if ((sb.Length > 0))
			{
				tokens.Add(sb.ToString());
			}
			return tokens;
		}

		private static T GetAndDeleteFirstElement<T>(this List<T> source)
		{
			var result = source.First();
			source.RemoveAt(0);
			return result;
		}
	}
}

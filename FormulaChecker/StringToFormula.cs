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

		public static double Calculate (string expression)
        {
			var tempList = GetTokens(expression);
			var formula = GetExpressionFromTokens(tempList);

			var result = Eval(formula);

			return result;
		}
		
		private static double Eval(string expression)
		{
			var tokens = GetTokens(expression);
			var operandList = new List<double>();
			var operatorList = new List<string>();
			int tokenIndex = 0;

			while (tokenIndex < tokens.Count)
			{
				var token = tokens[tokenIndex];
				if (token == "(")
				{
					var subExpr = GetSubExpression(tokens, ref tokenIndex);
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

		private static string GetSubExpression(List<string> tokens, ref int index)
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

		private static List<string> GetTokens(string expression)
		{
			var operators = "()^*/+-";
			var tokens = new List<string>();
			var subString = new StringBuilder();

			expression = expression.Replace(" ", string.Empty);

			var expressionAsArray = expression.ToArray();

			var index = 0;

			foreach (var element in expression)
			{
				if (operators.IndexOf(element) >= 0)
				{
					char previousElement;
					if (index == 0)
                    {
						previousElement = expressionAsArray[index];
					}
					else
                    {
						previousElement = expressionAsArray[index - 1];

					}

					if (subString.Length == 0 && "-".IndexOf(element) >= 0 && previousElement == '(')
					{
						tokens.Add("0");
						tokens.Add(element.ToString());
					}
					else
					{
						if ((subString.Length > 0))
						{
							tokens.Add(subString.ToString());
							subString.Length = 0;
						}

						tokens.Add(element.ToString());
					}
				}
				else
				{
					subString.Append(element);
				}
				index++;
			}

			if ((subString.Length > 0))
			{
				tokens.Add(subString.ToString());
			}

			return tokens;
		}

		private static string GetExpressionFromTokens(List<string> tokens)
        {
			AddBracketsForOperationPrioritization(tokens, "^");
			AddBracketsForOperationPrioritization(tokens, "*");

			var result = new StringBuilder();

			foreach(var element in tokens)
            {
				result.Append(element);
            }

			return result.ToString();
        }

		private static void AddBracketsForOperationPrioritization(List<string> source, string operation)
        {
			var counter = 0;
			var sourceCountFromZero = source.Count - 1;
			while (counter < sourceCountFromZero)
            {
				if (counter == 0)
				{
					counter++;
					continue;
				}

				var element = source[counter];
				var previousElement = source[counter - 1];


				if (element == operation)
                {
					if (counter == 1)
                    {
						source.Insert(0, "(");
						sourceCountFromZero++;
						counter++;

						var nextElement = source[counter + 1];

						if (nextElement != "(")
						{
							source.Insert(counter + 2, ")");
							sourceCountFromZero++;
							counter += 3;
						}
						else
						{
							var indexForCloseBracket = GetIndexForCloseBracket(source, counter);
							source.Insert(counter + indexForCloseBracket, ")");
							sourceCountFromZero++;
							counter++;
						}
					}
					else
                    {
						if (previousElement != ")")
                        {
							source.Insert(counter - 1, "(");
							sourceCountFromZero++;
							counter++;

							var nextElement = source[counter + 1];

							if (nextElement != "(")
                            {
								source.Insert(counter + 2, ")");
								sourceCountFromZero++;
								counter += 3;
							}
							else
                            {
								var indexForCloseBracket = GetIndexForCloseBracket(source, counter);
								source.Insert(counter + indexForCloseBracket, ")");
								sourceCountFromZero++;
								counter++;
							}
						}
						else
                        {
							var indexForOpenBracket = GetIndexForOpenBracket(source, counter);

							source.Insert(indexForOpenBracket, "(");
							sourceCountFromZero++;
							counter ++ ;

							var nextElement = source[counter + 1];

							if (nextElement != "(")
							{
								source.Insert(counter + 2, ")");
								sourceCountFromZero++;
								counter += 3;
							}
							else
							{
								var indexForCloseBracket = GetIndexForCloseBracket(source, counter);
								source.Insert(counter + indexForCloseBracket, ")");
								sourceCountFromZero++;
								counter++;
							}
						}
						
					}
                }
				else
                {
					counter++;
				}
            }

			var a = 1 + 1;
        }

		private static int GetIndexForOpenBracket (List<string> source, int counter)
        {
			var tempList = source.GetRange(0, counter - 1);

			var index = counter - 2;
			var bracketsCounter = 1;

			while (index > 0)
			{
				if (bracketsCounter == 0)
				{
					break;
				}

				if (tempList[index] == "(")
				{
					bracketsCounter--;
					index--;
					continue;
				}

				if (tempList[index] == ")")
				{
					bracketsCounter++;
					index--;
					continue;
				}

				index--;
			}
			
			return index+1;
        }

		private static int GetIndexForCloseBracket(List<string> source, int counter)
		{
			var tempList = source.GetRange(counter+2,source.Count-counter-2);

			var index = 0;
			var bracketsCounter = 1;

			while (index <= tempList.Count-1)
			{
				if (bracketsCounter == 0)
				{
					break;
				}

				if (tempList[index] == ")")
				{
					bracketsCounter--;
					index++;
					continue;
				}

				if (tempList[index] == "(")
				{
					bracketsCounter++;
					index++;
					continue;
				}

				index++;
			}

			return index + 2;
		}

		private static T GetAndDeleteFirstElement<T>(this List<T> source)
		{
			var result = source.First();
			source.RemoveAt(0);
			return result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FormulaChecker.Enums;
using FormulaChecker.Helpers;

namespace FormulaChecker
{
    public static class CommonClass
    {
        private static string formulaForStudent;
        private static string formulaForValidation;

        public static void CommonInitialization(Label label)
        {
            var formulas = RandomizeFormulaForTask().Split(';');

            formulaForStudent = formulas[0];
            formulaForValidation = formulas[1];

            RandomizeCoefficientInFormula();

            label.Text = label.Text.Replace("{formula}", formulaForStudent);
        }

        public static void TestValueInitialization(Label label, TextBox textBox, double testValue)
        {
            label.Text = $"x={testValue}";

            string tempFormula = String.Empty;

            if (testValue < 0)
            {
                tempFormula = formulaForValidation.Replace("{variable}", "(" + testValue.ToString() + ")");
            }
            else
            {
                tempFormula = formulaForValidation.Replace("{variable}", testValue.ToString());
            }

            var tempList = StringToFormula.getTokens(tempFormula);
            var formula = StringToFormula.getExpressionFromTokens(tempList);

            var rightValue = StringToFormula.Eval(formula);

            textBox.Tag = rightValue.ToString();
        }

        public static void GenerateTestValueList(List<double> list)
        {
            var random = new Random();

            while (list.Count() < 5)
            {
                var randomValue = random.Next(-50, 50);

                if (list.Contains(randomValue))
                {
                    continue;
                }
                else
                {
                    list.Add(randomValue);
                }

            }
        }

        private static string RandomizeFormulaForTask()
        {
            var values = Enum.GetValues(typeof(Formulas));
            var random = new Random();

            var enumMember = (Formulas)values.GetValue(random.Next(values.Length));

            var result = enumMember.GetValue();

            return result;
        }

        private static void RandomizeCoefficientInFormula()
        {
            var counter = Regex.Matches(formulaForValidation, "{coefficient}").Count-1;
            
            var random = new Random();
            while (counter >= 0)
            {
                var coefficient = random.Next(1,50);
                var coefficientFroReplacing = "{coefficient}"+$"[{counter}]";
                counter--;
                if (coefficient < 0)
                {
                    formulaForValidation = formulaForValidation.Replace(coefficientFroReplacing, "(" + coefficient.ToString() + ")");
                    formulaForStudent = formulaForStudent.Replace(coefficientFroReplacing, "(" + coefficient.ToString() + ")");
                }
                else
                {
                    formulaForValidation = formulaForValidation.Replace(coefficientFroReplacing, coefficient.ToString());
                    formulaForStudent = formulaForStudent.Replace(coefficientFroReplacing, coefficient.ToString());
                }    
                
            }
        }

    }
}

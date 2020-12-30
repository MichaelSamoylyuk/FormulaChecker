using System.ComponentModel;

namespace FormulaChecker.Enums
{
    public enum Formulas
    {
        [Description("y={coefficient}[0]x-{coefficient}[1];{coefficient}[0]*{variable}-{coefficient}[1]")]
        First,
        [Description("y={coefficient}[0]x+{coefficient}[1];{coefficient}[0]*{variable}+{coefficient}[1]")]
        Second,
        [Description("y={coefficient}[0]x^2+{coefficient}[1];{coefficient}[0]*{variable}^2+{coefficient}[1]")]
        Third
    }
}

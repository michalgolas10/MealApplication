using System.Text.RegularExpressions;

namespace KuceZBronksuBLL.Validations
{
	public class Validation
	{
		public static bool ValidationIfNumbers(string ValueInt)
		{
			Regex rx = new Regex(@"^[0-9]+$",
			RegexOptions.Compiled | RegexOptions.IgnoreCase);
			return rx.IsMatch(ValueInt);
		}

		public static bool ValidationIfMealTypeCorrect(string mealType)
		{
			if (mealType == "breakfast" || mealType == "teatime" || mealType == "lunch/dinner")
				return true;
			else
				return false;
		}
	}
}
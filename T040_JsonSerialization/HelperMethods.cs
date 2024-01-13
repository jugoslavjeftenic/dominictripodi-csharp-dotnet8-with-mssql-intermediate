namespace T040_JsonSerialization
{
	public class HelperMethods
	{
		public static string EscapeSingleQuote(string input)
		{
			string output = input.Replace("'", "''");

			return output;
		}
	}
}

namespace VsoBackup.Utilities
{
    public class StringUtilities
    {
        public static string FormatDateTeamProjectAndRepository(string today, string name, string repo)
        {
            return today + @"\" + name + @"\" + repo;
        }

        public static string FormatDateAndTeamProject(string today, string clientName)
        {
            return today + @"\" + clientName;
        }

        public static bool EndsWith(string value, string character)
        {
            return value.EndsWith(character);
        }
    }
}

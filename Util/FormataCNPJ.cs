namespace Manager.Util
{
    public static class FormataCNPJ
    {

        public static string SemFormatacao(string codigo)
        {
            return codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
    }
}

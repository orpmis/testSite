namespace testASP.Service
{
    public static class Extentions
    {
        public static string CutControllerPart(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}

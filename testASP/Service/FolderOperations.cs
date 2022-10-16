namespace testASP.Service
{
    public static class FolderOperations
    {
        public static void CreateFolderForGoods(HttpContext root,int id)
        {
            Directory.CreateDirectory(root.Request.PathBase + "App_Data/" + id);
        }
    }
}

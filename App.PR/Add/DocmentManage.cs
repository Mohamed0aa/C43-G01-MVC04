namespace App.PR.Add
{
    public static class DocmentManage
    {
        //upload
        public static string Upload(IFormFile file)
        {
            
           var FileNmae = $"{Guid.NewGuid()}{ file.Name}";

           var ppath= Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Image", FileNmae);

            using var filePath = new FileStream(ppath, FileMode.Create);

            file.CopyTo(filePath);

            return FileNmae;
        }


        //Delete

        public static void Delete(string FileName)
        {
            var Path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Image", FileName);
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }
    }
}

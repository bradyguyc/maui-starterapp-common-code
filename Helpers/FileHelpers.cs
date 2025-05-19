using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCode.Helpers
{
    public static  class FileHelpers
    {
        public static async Task<string> ReadTextFile(string filePath)
        {
            await using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            return await reader.ReadToEndAsync();
        }
    }
}

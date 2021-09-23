using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace MySuperBank
{
    public class Read
    {
        internal static bool ReadAllLines(out IEnumerable<Transaction> transactions)
        {
            string sAttrRead = ConfigurationManager.AppSettings.Get("Key1");
            var readFilePath = new DirectoryInfo(sAttrRead);

            try
            {
                var sortFile = readFilePath.GetFiles().OrderByDescending(f => f.LastWriteTime).First().ToString();
                var fileContent = File.ReadAllText(sortFile);
                transactions = JsonSerializer.Deserialize<IEnumerable<Transaction>>(fileContent);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Intäkter och utgifter från förra månaden kunde inte läsas in. Ignorera om det är första gången du kör programmet.\n\n");
                transactions = null;
                return false;
            }
        }
    }
}

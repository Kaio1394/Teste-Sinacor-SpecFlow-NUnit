using Newtonsoft.Json;
using System.IO;

namespace Nunit_sinacor.data
{
    public class ReadJson
    {
        public static string ReadFileJson(string file, string page, string locator)
        {
            dynamic? _jsonFile = JsonConvert.DeserializeObject(
                File.ReadAllText(@"..\..\..\data\"+file+".json"));
            if(_jsonFile== null)
            {
                throw new Exception("Locator não encontrado.");
            }
            return _jsonFile[page][locator];
        }
    }
}

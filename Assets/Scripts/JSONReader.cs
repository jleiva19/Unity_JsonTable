using Newtonsoft.Json;
public class JSONReader
{
    public Table getTable(string fileData)
    {
        // deserealize the string into the dummy table
        return JsonConvert.DeserializeObject<Table>(fileData);
    }
}


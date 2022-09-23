// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AddressClass
{
    public int place_id { get; set; }
    public string licence { get; set; }
    public string osm_type { get; set; }
    public long osm_id { get; set; }
    public string lat { get; set; }
    public string lon { get; set; }
    public string display_name { get; set; }
}


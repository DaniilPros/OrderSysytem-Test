
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "country")]
	public class Country
	{
		[XmlElement(ElementName = "geo")]
		public string Geo { get; set; }
	}

}

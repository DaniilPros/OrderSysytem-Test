
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "orderarticle")]
	public class Orderarticle
	{
		[XmlElement(ElementName = "artnum")]
		public long Artnum { get; set; }
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "amount")]
		public int Amount { get; set; }
		[XmlElement(ElementName = "brutprice")]
		public double Brutprice { get; set; }
	}

}

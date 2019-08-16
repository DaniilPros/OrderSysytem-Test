
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "billingaddress")]
	public class Billingaddress
	{
		[XmlElement(ElementName = "billemail")]
		public string Billemail { get; set; }
		[XmlElement(ElementName = "billfname")]
		public string Billfname { get; set; }
		[XmlElement(ElementName = "billstreet")]
		public string Billstreet { get; set; }
		[XmlElement(ElementName = "billstreetnr")]
		public short Billstreetnr { get; set; }
		[XmlElement(ElementName = "billcity")]
		public string Billcity { get; set; }
		[XmlElement(ElementName = "country")]
		public Country Country { get; set; }
		[XmlElement(ElementName = "billzip")]
		public int Billzip { get; set; }
	}

}

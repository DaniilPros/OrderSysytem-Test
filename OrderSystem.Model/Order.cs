
using System.Xml.Serialization;
namespace OrderSystem.Model
{

	[XmlRoot(ElementName = "order")]
	public class Order
	{
		[XmlElement(ElementName = "oxid")]
		public long Oxid { get; set; }
		[XmlElement(ElementName = "orderdate")]
		public string Orderdate { get; set; }
		[XmlElement(ElementName = "billingaddress")]
		public Billingaddress Billingaddress { get; set; }
		[XmlElement(ElementName = "payments")]
		public Payments Payments { get; set; }
		[XmlElement(ElementName = "articles")]
		public Articles Articles { get; set; }
	}

}

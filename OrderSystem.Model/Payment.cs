
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "payment")]
	public class Payment
	{
		[XmlElement(ElementName = "method-name")]
		public string Methodname { get; set; }
		[XmlElement(ElementName = "amount")]
		public decimal Amount { get; set; }
	}

}

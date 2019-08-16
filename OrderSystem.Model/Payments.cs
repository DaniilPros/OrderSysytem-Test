
using System.Collections.Generic;
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "payments")]
	public class Payments
	{
		[XmlElement(ElementName = "payment")]
		public List<Payment> Payment { get; set; }
	}

}

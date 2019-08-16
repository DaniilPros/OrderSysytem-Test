
using System.Collections.Generic;
using System.Xml.Serialization;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "orders")]
	public class OrdersXML
	{
		[XmlElement(ElementName = "order")]
		public List<Order> Order { get; set; }
	}

}

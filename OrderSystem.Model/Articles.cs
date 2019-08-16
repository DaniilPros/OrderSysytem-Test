
using System.Xml.Serialization;
using System.Collections.Generic;
namespace OrderSystem.Model
{
	[XmlRoot(ElementName = "articles")]
	public class Articles
	{
		[XmlElement(ElementName = "orderarticle")]
		public List<Orderarticle> Orderarticle { get; set; }
	}

}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using OrderSystem.Model;
using OrderSystem.Models;

namespace OrderSystem.Convertors
{
	public class OrderConvertor : IOrderConvertor
	{
		public Orders Convert(Order ord)
		{
			return new Orders()
			{
				OxId = ord.Oxid,
				OrderDatetime = DateTime.Parse(ord.Orderdate),
				BillingAddresses = new BillingAddresses()
				{
					Email = ord.Billingaddress.Billemail,
					City = ord.Billingaddress.Billcity,
					Country = ord.Billingaddress.Country.Geo,
					Fullname = ord.Billingaddress.Billfname,
					Street = ord.Billingaddress.Billstreet,
					HomeNumber = ord.Billingaddress.Billstreetnr,
					Zip = ord.Billingaddress.Billzip
				},
				Payments = ord.Payments.Payment.Select(p => new Models.Payments()
				{
					MethodName = p.Methodname,
					Amount = p.Amount
				}).ToList(),
				Articles = ord.Articles.Orderarticle.Select(art => new Models.Articles()
				{
					BrutPrice = art.Brutprice,
					Amount = art.Amount,
					Title = art.Title,
					Nomenclature = art.Artnum
				}).ToList()

			};
		}
	}
}

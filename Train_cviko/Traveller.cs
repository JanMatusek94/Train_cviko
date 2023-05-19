using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
	internal class Traveller : Person {
		public int CardNo;
		public Discount sleva;
		public static int pocitadloCardNo;
		public Traveller(string firstName, string lastName, Discount sleva = Discount.normal) : base(firstName, lastName) {
			this.CardNo = ++pocitadloCardNo;
			this.sleva = sleva;
		}

	}
}

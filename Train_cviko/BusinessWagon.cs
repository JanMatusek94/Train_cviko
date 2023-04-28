using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class BusinessWagon : PersonalWagon {
        private Person steward;
        public Person Steward {
            get { return steward; }
            set { steward = value; }
        }
        public BusinessWagon(Person steward, int numberOfChairs) : base(numberOfChairs) {
            this.steward = steward;
        }
        public override string ToString() {
            return $"Druh vagonu: {this.GetType().Name}, počet sedadel: {NumberOfChairs}, steward: {steward}";
        }
    }
}

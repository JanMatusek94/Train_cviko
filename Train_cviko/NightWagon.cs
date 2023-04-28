using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class NightWagon : PersonalWagon {
        private Bed[] beds;
        private int numberOfBeds;
        public Bed[] Beds {
            get { return this.beds; }
            set { this.beds = value; }
        }
        public int NumberOfBeds {
            get { return this.numberOfBeds;}
            set { this.numberOfBeds = value;}
        }
        public NightWagon(int numberOfChairs, int numberOfBeds) : base (numberOfChairs){
            this.numberOfBeds = numberOfBeds;
            beds = new Bed[numberOfBeds];
        }
        public override string ToString() {
            return $"Druh vagonu: {this.GetType().Name}, počet sedadel: {NumberOfChairs}, počet postelí: {numberOfBeds}";
        }
    }
}

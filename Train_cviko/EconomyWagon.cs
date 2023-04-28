using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class EconomyWagon : PersonalWagon {
        public EconomyWagon(int numberOfChairs) : base(numberOfChairs){
        }
        public override string ToString() {
            return $"Druh vagonu: {this.GetType().Name}, počet sedadel: {NumberOfChairs}";
        }
    }
}

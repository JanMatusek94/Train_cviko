using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class Hopper : IConnectionable {
        private double loadingCapacity;
        public double LoadingCapacity { 
            get { return loadingCapacity; } 
            set {  loadingCapacity = value; } 
        }
        public Hopper(double tonnage) {
            loadingCapacity = tonnage;
        }
        public void ConnectWagon(Train vlak) {
            if ((vlak.Locomotive.Engine == Engine.parní)  && vlak.Wagons.Count >= 5) {
                Console.WriteLine("Parní vlak může mít maximálně 5 vagonů");
            }
            else {
                vlak.Wagons.Add(this);
            }
        }
        public void DisconnectWagon(Train vlak) {
            if (vlak.Wagons.Contains(this)) {
                vlak.Wagons.Remove(this);
            }
            else {
                Console.WriteLine("Tento vagon není součástí tohoto vlaku.");
            }
        }
        public override string ToString() {
            return $"Druh vagonu: {this.GetType().Name}, nosnost {loadingCapacity}";
        }
    }
}

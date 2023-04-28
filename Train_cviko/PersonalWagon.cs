using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    abstract internal class PersonalWagon : IConnectionable {
        private List<Door> doors;
        private List<Chair> chairs;
        private int numberOfChairs;
        public int NumberOfChairs {
            get { return numberOfChairs; }
            set { numberOfChairs = value; }
        }
        public List<Chair> Chairs { get { return chairs; } }
        public PersonalWagon(int numberOfChairs) {
            this.numberOfChairs = numberOfChairs;
            this.doors = new List<Door>();
            this.chairs = new List<Chair>();
            for (int i = 1; i <= numberOfChairs; i++) {
                chairs.Add(new Chair(i, false));
            }
            
        }
        public void ConnectWagon(Train vlak) {
            if ((vlak.Locomotive.Engine.Type == "parní") && vlak.Wagons.Count >= 5) {
                Console.WriteLine("Parní vlak může mít maximálně 5 vagonů");
            }
            else {
                vlak.Wagons.Add(this);
            }
        }
        public void DisconnectWagon(Train vlak) {
            if (vlak.Wagons.Contains(this)) {
                vlak.Wagons.Remove(this);
            } else {
                Console.WriteLine("Tento vagon není součástí tohoto vlaku.");
            }
            
        }
    }
}

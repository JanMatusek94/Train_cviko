using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {

    internal class Train {
        private Locomotive locomotive;
        public Locomotive Locomotive {
            get { return locomotive; }
            set { locomotive = value; }
        }
        private List<IConnectionable> wagons;
        public List<IConnectionable> Wagons { get { return wagons; } 
            set { this.wagons = value; }
        }
        public Train() {
            this.locomotive = new Locomotive();
            wagons = new List<IConnectionable>();
        }
        public Train(Locomotive locomotive) {
            this.locomotive = locomotive;
            wagons = new List<IConnectionable>();
        }
        public Train(Locomotive locomotive, List<IConnectionable> wagons) : this (locomotive){
            this.wagons = wagons;
        }
        public void ConnectWagon (IConnectionable wagon) {
            wagon.ConnectWagon(this);
        }
        public void DisconnectWagon(IConnectionable wagon) {
            wagon.DisconnectWagon(this);
        }

        public void ReserveChair(int wagonNumber, int seatNumber) {
            if ((wagons[wagonNumber].GetType() != typeof(Hopper))) {
                if (wagonNumber <= wagons.Count && wagonNumber > 0) {
                    if (seatNumber <= ((PersonalWagon)wagons[wagonNumber-1]).NumberOfChairs && seatNumber > 0) {
                        if (((PersonalWagon)wagons[wagonNumber-1]).Chairs[seatNumber-1].Reserved == false) {
                            ((PersonalWagon)wagons[wagonNumber-1]).Chairs[seatNumber-1].Reserved = true;
                            Console.WriteLine($"Křeslo {seatNumber} ve vagonu {wagonNumber} bylo rezervováno.");
                        }
                        else {
                            Console.WriteLine("Místo je již rezervováno");
                        }
                    }
                    else {
                        Console.WriteLine("Tolik míst v tomto vagonu není");
                    }
                } else {
                    Console.WriteLine("Tolik vagonu zde není");
                }
            } else {
                Console.WriteLine($"Tento vagon nemá místa k sezeni");
            }
        }
        public void ListReservedChairs() {
            foreach (IConnectionable wagon in wagons) {
                if (wagon.GetType() != typeof(Hopper)) {
                    Console.WriteLine($"Reservovaná místa ve vagonu {wagons.IndexOf(wagon)+1} jsou:");
                    foreach (Chair chair in ((PersonalWagon)wagon).Chairs) {
                        if (chair.Reserved == true) {
                            Console.WriteLine(chair);
                        }
                    }
                }
            }
        }
        public override string ToString() {
            string str = $"{this.GetType().Name}: \n";
            foreach (IConnectionable wagon in wagons) {
                str += wagon.ToString()+"\n";
            }
            str += locomotive;
            return str;
        }
    }
}

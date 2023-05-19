using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Train_cviko {

    internal class Train {
        private Locomotive locomotive;
    public static int pocetVlaku = 1;
    public int cisloVlaku;
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
			cisloVlaku = pocetVlaku++;
		}
        public Train(Locomotive locomotive) {
            this.locomotive = locomotive;
            wagons = new List<IConnectionable>();
      cisloVlaku = pocetVlaku++;
           
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
		public void ReserveChair(int wagonNumber, int seatNumber, Traveller cestujici) {
			if ((wagons[wagonNumber].GetType() != typeof(Hopper))) {
				if (wagonNumber <= wagons.Count && wagonNumber > 0) {
					if (seatNumber <= ((PersonalWagon)wagons[wagonNumber - 1]).NumberOfChairs && seatNumber > 0) {
						if (((PersonalWagon)wagons[wagonNumber - 1]).Chairs[seatNumber - 1].Reserved == false) {
							((PersonalWagon)wagons[wagonNumber - 1]).Chairs[seatNumber - 1].Reserved = true;
              ((PersonalWagon)wagons[wagonNumber - 1]).Chairs[seatNumber - 1].reservedToCardNo = cestujici.CardNo;
							Console.WriteLine($"Křeslo {seatNumber} ve vagonu {wagonNumber} bylo rezervováno cestujícímu s ID {cestujici.CardNo}.");
						}
						else {
							Console.WriteLine("Místo je již rezervováno");
						}
					}
					else {
						Console.WriteLine("Tolik míst v tomto vagonu není");
					}
				}
				else {
					Console.WriteLine("Tolik vagonu zde není");
				}
			}
			else {
				Console.WriteLine($"Tento vagon nemá místa k sezeni");
			}
		}
		public void ListReservedChairs() {
            foreach (IConnectionable wagon in wagons) {
                if (wagon.GetType() != typeof(Hopper)) {
                    Console.WriteLine($"Reservovaná místa ve vagonu {wagons.IndexOf(wagon)+1} jsou:");
                    foreach (Chair chair in ((PersonalWagon)wagon).Chairs) {
                        if (chair.Reserved == true) {
                            Console.WriteLine($"Křeslo {chair} rezervováno cesujícímu s ID {chair.reservedToCardNo}");
                        }
                    }
                }
            }
        }
        public override string ToString() {
            string str = $"{this.GetType().Name}{cisloVlaku}: \n";
            foreach (IConnectionable wagon in wagons) {
                str += wagon.ToString()+"\n";
            }
            str += locomotive;
            return str;
        }
    public static Train operator +(Train hlavni, Train vedlejsi) {
      List<IConnectionable> pom = new List<IConnectionable>();
      foreach (IConnectionable vagon in hlavni.wagons) {
        pom.Add(vagon);
      }
      foreach (IConnectionable vagon in vedlejsi.wagons) {
				pom.Add(vagon);
			}
      return new Train(hlavni.locomotive, pom);
    }

    public static Train operator -(Train vlak, int pocet) {
			if (pocet <= vlak.wagons.Count) {
				List<IConnectionable> pom = new List<IConnectionable>();
			foreach (IConnectionable vagon in vlak.wagons) {
				pom.Add(vagon);
			}
        pom.RemoveRange(pom.Count - pocet, pocet);
				return new Train(vlak.locomotive, pom);
			} else {
        throw new ArithmeticException("Nelze oddělit víc vagonu než kolik vlak má");
      }

		}

    public static bool operator ==(Train vlak1, Train vlak2) {
      if (vlak1.wagons.Count == vlak2.wagons.Count) { return true; }
      else { return false; }
    }
		public static bool operator !=(Train vlak1, Train vlak2) {
			if (vlak1.wagons.Count == vlak2.wagons.Count) { return false; }
			else { return true; }
		}
	}

}

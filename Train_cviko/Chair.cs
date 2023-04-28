using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class Chair {
        private bool nearWindow;
        private int number;
        private bool reserved;

        public bool NearWindow {
            get { return nearWindow; }
            set { nearWindow = value; }
        }
        public int Number {
            get { return number; }
            set { this.number = value; }
        }
        public bool Reserved {
            get { return reserved; }
            set { reserved = value; }
        }
        public Chair(int number, bool nearWindow) {
            this.number = number;
            this.nearWindow = nearWindow;
            this.reserved = false;
        }
        public override string ToString() {
            return $"Číslo sedadla: {number}";
        }
    }
}

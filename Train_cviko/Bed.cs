using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class Bed {
        private int number;
        private bool reserved;
        public int Number {
            get { return number; }
            set { number = value; }
        }
        public bool Reserved {
            get { return reserved; }
            set { reserved = value; }
        }
        public Bed() {
        }
    }
}

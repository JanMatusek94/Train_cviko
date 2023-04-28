using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class Door {
        private double height;
        private double width;
        public double Height {
            get { return height; }
            set { this.height = value; }}
        public double Width {
            get { return width; }
            set { this.width = value; }
        }
        public Door(double height, double width) {
            this.height = height;
            this.width = width;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal class Locomotive {
        private Person driver;
        private Engine engine;
        public Engine Engine {
            get { return engine; }
            set { engine = value; }
        }
        public Locomotive() {
            driver = new Person("John", "Doe");
            engine = Engine.dieselová;
        }
        public Locomotive(Person driver, Engine engine) {
            this.driver = driver;
            this.engine = engine;
        }
        public override string ToString() {
            return $"Šofér lokomotivy: {driver}, endžín: {engine}";
        }
    }
}

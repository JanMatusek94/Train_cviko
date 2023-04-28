using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_cviko {
    internal interface IConnectionable {
        void ConnectWagon(Train vlak);
        void DisconnectWagon(Train vlak);
    }
}

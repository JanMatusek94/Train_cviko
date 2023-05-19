namespace Train_cviko;
class Program {
    public static void Main() {
        Person stew1 = new Person("Lenka", "Kozáková");
        EconomyWagon vagon1 = new EconomyWagon(50);
        BusinessWagon vagon2 = new BusinessWagon(stew1, 40);
        NightWagon vagon3 = new NightWagon(2, 30);
        Hopper vagon4 = new Hopper(10);
        Person strojv1 = new Person("Karel", "Novák");
        Locomotive lok1 = new Locomotive(strojv1, Engine.dieselová);
        Train vlak1 = new Train(lok1, new List<IConnectionable> {vagon1,
        vagon2, vagon3, vagon4});
        Hopper vagon5 = new Hopper(20);

        Locomotive lok2 = new Locomotive(strojv1, Engine.parní);
        Train vlak2 = new Train(lok2, new List<IConnectionable> {
            vagon1, vagon2, vagon4, vagon5, vagon2, vagon4, vagon5 });
        vlak2.ConnectWagon(vagon5);
        foreach(IConnectionable wagon in vlak1.Wagons) {
            Console.WriteLine(wagon);
        }
    Traveller cest1 = new Traveller("Jan", "Matušek", Discount.student);
    Traveller cest2 = new Traveller("Petr", "Skamene", Discount.pensioner);

        vlak1.ReserveChair(3, 9, cest2);
        vlak1.ReserveChair(2, 40, cest1);
        vlak1.ReserveChair(1, 10, cest2);
        vlak1.ReserveChair(1, 10);

        vlak1.ListReservedChairs();
    //vlak2.ConnectWagon(vagon5);
        //vlak2.DisconnectWagon(vagon5);
        Console.WriteLine();
        Console.WriteLine(vlak1);
        Console.WriteLine(vlak2);
    Train vlak3 = vlak1 + vlak2;
    Console.WriteLine(vlak3);
    Console.WriteLine(vlak1);
    try {
      Train vlak4 = vlak1 - 0;
			Console.WriteLine(vlak4);
  }
    catch (ArithmeticException ex) { Console.WriteLine(ex.Message); }

Console.WriteLine(vlak1);
    bool pravda = vlak1 != vlak2;
    Console.WriteLine(pravda);
    }
}

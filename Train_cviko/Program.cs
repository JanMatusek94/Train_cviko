namespace Train_cviko;
class Program {
    public static void Main() {
        Person stew1 = new Person("Lenka", "Kozáková");
        EconomyWagon vagon1 = new EconomyWagon(50);
        BusinessWagon vagon2 = new BusinessWagon(stew1, 40);
        NightWagon vagon3 = new NightWagon(2, 30);
        Hopper vagon4 = new Hopper(10);
        Person strojv1 = new Person("Karel", "Novák");
        Locomotive lok1 = new Locomotive(strojv1, new Engine("diesel"));
        Train vlak1 = new Train(lok1, new List<IConnectionable> {vagon1,
        vagon2, vagon3, vagon4});
        Hopper vagon5 = new Hopper(20);

        Locomotive lok2 = new Locomotive(strojv1, new Engine("parní"));
        Train vlak2 = new Train(lok2, new List<IConnectionable> {
            vagon1, vagon2, vagon3, vagon4, vagon5 });
        vlak2.ConnectWagon(vagon5);
        foreach(IConnectionable wagon in vlak1.Wagons) {
            Console.WriteLine(wagon);
        }

        vlak1.ReserveChair(3, 9);
        vlak1.ReserveChair(2, 40);
        vlak1.ReserveChair(1, 10);
        vlak1.ReserveChair(1, 10);

        vlak1.ListReservedChairs();
        vlak2.DisconnectWagon(vagon5);
        Console.WriteLine();
        Console.WriteLine(vlak1);
        Console.WriteLine(vlak2);
    }
}

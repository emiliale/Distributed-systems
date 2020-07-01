public class MyClient {
    public static void main(String[] args) {
        String wynik;
        String wynik2;
        ObjInfo zObiekt;
        Andora zObiekt2;

        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
            return;
        }
        String adres = args[0];
        String adres2 = args[1];

        
        try {
            zObiekt = (ObjInfo) java.rmi.Naming.lookup(adres);
            zObiekt2 = (Andora) java.rmi.Naming.lookup(adres2);
           


        } catch (Exception e) {
            System.out.println("Nie mozna pobrac referencji do "+adres);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do "+adres+" jest pobrana.");
        try {
            wynik = zObiekt.getInfo("Lebiedowska", 'a', 242473);
            wynik2 = zObiekt2.balast(242473, 1.5, "Lebiedowska");


        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik = "+wynik);
        System.out.println("Wynik2 = "+wynik2);

        return;
    }
}

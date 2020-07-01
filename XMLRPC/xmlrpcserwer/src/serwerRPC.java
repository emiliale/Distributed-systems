import org.apache.xmlrpc.WebServer;

public class serwerRPC {

    public String fun13(boolean b, String s, int i) {
        return  s;
    }

    public static void main(String[] args) {
        try {
            int port = 34005;
            WebServer server = new WebServer(port);
            server.addHandler("Lebiedowska", new serwerRPC());
            server.start();

        } catch (Exception e) {
            System.err.println("Serwer XML-RPC: " + e);
        }
    }

}
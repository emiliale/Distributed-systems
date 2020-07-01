import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ObjInfo extends Remote {
    public String getInfo(String s, char c, int i) throws RemoteException;
}

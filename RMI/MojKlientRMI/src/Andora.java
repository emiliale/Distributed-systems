import java.rmi.Remote;
import java.rmi.RemoteException;

public interface Andora extends Remote{
	
	public String balast(long l, double d, String s) throws RemoteException;
}

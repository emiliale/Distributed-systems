import java.util.Vector;

import org.apache.xmlrpc.XmlRpcClient;

public class klientRPC {
	
	
	public static void main(String[] args) {
		
		
		try {
			
			XmlRpcClient srv = new
					XmlRpcClient("http://156.17.130.166:34005"); 
			
			Vector<String> params = new Vector<String>();
			params.addElement(new String("Lebiedowska")); 
			params.addElement(new String("242473"));
					Object result =
					srv.execute("Lebiedowska.getProc", params);
					
			String wynik = ((String) result);
			System.out.println(wynik);
			
		    AC cb = new AC();
            Vector<Object> params3 = new Vector<Object>();
            params3.addElement(new String("Lebiedowska"));
            params3.addElement(new Integer(40));
            srv.executeAsync("Lebiedowska.fun204", params3, cb);
            System.out.println("Wywolano synchronicznie");
            
        	Vector<Object> params2 = new Vector<Object>();
			params2.addElement(new Boolean(false)); 
			params2.addElement(new String("Lebiedowska"));
			params2.addElement(new Integer(5));
			Object result2 =
					srv.execute("Lebiedowska.fun13", params2);
			String wynik2 = ((String) result2);
			System.out.println(wynik2);
			

			}catch(Exception exception){
				System.err.println("Klient XML-RPC: " +exception);
				}

	}

}

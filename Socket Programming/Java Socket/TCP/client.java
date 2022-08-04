import java.io.*;
import java.net.*;


public class client {
    // initialize socket and input output streams 
    public static void main(String[] args) throws IOException{
        
        Socket s = new Socket("localhost",4999);
        
        PrintWriter pr = new PrintWriter(s.getOutputStream());
        pr.println("is it working?");
        pr.flush();

        InputStreamReader in = new InputStreamReader(s.getInputStream());
        BufferedReader bf = new BufferedReader(in);
  
        String str = bf.readLine();
        System.out.println("server: "+ str);


    }
    
    
}



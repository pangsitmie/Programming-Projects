//import java.io.BufferedInputStream;
//import java.io.FileOutputStream;
//import java.io.PrintStream;

import java.io.IOException;
import java.io.File;
import java.net.*;
import java.io.*;

public class server {

    public static void main(String[] args) throws IOException {
        //CREATE SOCKET
        ServerSocket ss = new ServerSocket(4333);
        System.out.println("[SERVER STARTED]");

        File file = new File("jinggle.wav");
        int fileLength = (int) file.length();
        System.out.println("[FILE LENGTH]: " + fileLength);

        //WAIT FOR CONENCTION AND ACCEPT SOCKET WHEN IT RECEIVED CONNECTION
        Socket s = ss.accept();

        //FILE INPUT STREAM (READ BYTES FROM A FILE AND PLACE IT INSIDE BUFFER)
        FileInputStream fr = new FileInputStream(file);
        
        //READ BYTES FROM BUFFER AND PLACED IT INTO SOCKET OUTPUT STREAM
        OutputStream os = s.getOutputStream();

        //BUFFER READ-WRITE
        byte buff[] = new byte[50000];
        int len;
        while ((len = fr.read(buff)) != -1) {
            System.out.println("[BYTE LENGTH SENT]: " + len);
            os.write(buff, 0, buff.length);
        }

        System.out.println("[UPLOAD SUCCESSFULL]\n");
        //CLOSE SOCKET
        s.close();
        System.out.println("[SOCKET CLOSED]\n");

    }

}

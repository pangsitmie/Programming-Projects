
import java.net.*;
import java.io.FileInputStream;
import java.net.UnknownHostException;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

import java.io.*;
import sun.audio.AudioStream;
import sun.audio.AudioPlayer;
import javax.swing.JOptionPane;

//audio data
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;

import sun.audio.*;
import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;

public class clientBuffer {

    public static byte[] oo = new byte[30000000];
    public static byte buff[] = new byte[50000];
    public static int len;

    public static void main(String[] args) throws UnknownHostException, IOException, Throwable {
        //FILE NAME
        //String filename = "C:\\java_buffer\\newart.wav";

        //SOCKET
        //Socket ss = new Socket("10.0.2.15", 4333);        
        Socket ss = new Socket("192.168.56.1", 4333);

        System.out.println("[CLIENT STARTED]");

        //INPUT STREAM (GET FROM SOCKET)
        InputStream is = ss.getInputStream();

        //FILE OUTPUT STREAM (WRITE WHAT IS RECEIVED FROM SOOCKET AND PLACED IN BUFFER, TO A FILE)
        //FileOutputStream fr = new FileOutputStream(filename);
        //BUFFER READ AND WRITE
        //BYTE ARRAY FOR TEMPORARY PLACEMENT
        Thread t2 = new Thread(new Runnable() {
            ByteArrayOutputStream output = new ByteArrayOutputStream();
            byte[] out = new byte[50000];

            @Override
            public void run() {
                try {
                    while ((len = is.read(buff)) != -1) {
                        System.out.println("RECEIVING");
                        output.write(buff, 0, buff.length);
                        out = output.toByteArray();
                        oo = out.clone();

                        //System.out.println("[BYTE LENGTH SENT]: " + len);
                        //fr.write(buff,0,buff.length);
                    }
                } catch (IOException ex) {
                    Logger.getLogger(clientBuffer.class.getName()).log(Level.SEVERE, null, ex);
                }

            }
        });
        t2.start();

        Thread t1 = new Thread(new Runnable() {
            @Override
            public void run() {
                while (true) {
                    // code goes here
                    System.out.println("Thread");
                    AudioData audiodata = new AudioData(oo);
                    AudioDataStream audioStream = new AudioDataStream(audiodata);
                    AudioPlayer.player.start(audioStream);
                }

            }
        });
        t1.sleep(500);
        t1.start();

        //CLOSE SOCKET
        ss.close();
        System.out.println("LOADING COMPLETE...");
        System.out.println("[SOCKET CLOSED]\n");
        t1.interrupt();

        /*
        //PLAY THE MUSIC THROUGH BUFFER
        AudioData audiodata = new AudioData(out);
        AudioDataStream audioStream = new AudioDataStream(audiodata);
        AudioPlayer.player.start(audioStream);
         */
    }
}

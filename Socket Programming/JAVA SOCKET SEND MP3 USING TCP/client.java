import java.net.*;
import java.io.FileInputStream;
import java.net.UnknownHostException;
import javafx.scene.media.Media;
import javafx.scene.media.MediaPlayer;

import java.io.*;
import sun.audio.AudioStream;
import sun.audio.AudioPlayer;
import javax.swing.JOptionPane;



public class client {
    public static void main(String[] args) throws UnknownHostException, IOException, Throwable {
        //FILE NAME
        String filename = "C:\\java_buffer\\newart.wav";
        
        //SOCKET
        //Socket ss = new Socket("10.0.2.15", 4333);        
        Socket ss = new Socket("192.168.56.1", 4333);

        
        System.out.println("[CLIENT STARTED]");

        //INPUT STREAM (GET FROM SOCKET)
        InputStream is = ss.getInputStream();
        
        //FILE OUTPUT STREAM (WRITE WHAT IS RECEIVED FROM SOOCKET AND PLACED IN BUFFER, TO A FILE)
        FileOutputStream fr = new FileOutputStream(filename);

        //BUFFER READ AND WRITE
        byte buff[] = new byte[50000];
        
        int len;
        while ((len = is.read(buff)) !=-1) {
            System.out.println("[BYTE LENGTH SENT]: " + len);
            fr.write(buff,0,buff.length);
        }
        
        //CLOSE SOCKET
        ss.close();
        System.out.println("Download successfull...");
        System.out.println("[SOCKET CLOSED]\n");

        //PLAY THE MUSIC
        
        

        System.out.println("[PLAYING MUSIC]");
        playMusic(filename);        
    }


    
    
    //PLAY MUSIC VOID
    public static void playMusic (String filepath){
        InputStream music;
        try {
            music = new FileInputStream(new File(filepath));
            AudioStream audios = new AudioStream(music);
            AudioPlayer.player.start(audios);
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null,"Error");
        }
        System.out.println("[MUSIC FINISHED]");
    }

}


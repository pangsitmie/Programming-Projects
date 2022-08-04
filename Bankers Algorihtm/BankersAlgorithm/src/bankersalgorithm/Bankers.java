package bankersalgorithm;

import java.util.*;
import java.io.*;   
import java.util.Scanner;  
/**
 *
 * @author jeriel
 */
public class Bankers {
    
     // fidn and calculate the resource needed for each process
     static void findNeedValue(int[][] needArr, int[][] maxArr, int[][] allocationArr, int totalProcess, int totalResources)  
    {  
        for (int i = 0 ; i < totalProcess ; i++){ 
            for (int j = 0 ; j < totalResources ; j++){  
                needArr[i][j] = maxArr[i][j] - allocationArr[i][j];  
            }  
        }  
    }  
     
     // create checkSafeSystem() method to determine whether the system is in safe state or not  
    static boolean checkSafeSystem(int processes[], int[] availableArr, int[][] maxArr, int[][] allocationArr, int totProcess, int totResources)  
    {  
        int [][]needArr = new int[totProcess][totResources];  
  
        // call findNeedValue() method to calculate needArr  
        findNeedValue(needArr, maxArr, allocationArr, totProcess, totResources);  
  
        boolean []finishProcesses = new boolean[totProcess];  
  
        // safeSequenceArr stores the safe sequence
        int []safeSequenceArr = new int[totProcess];  
  
        // initialize workArr as a copy of the available resources  
        int []workArr = new int[totResources];  
          
        for (int i = 0; i < totResources ; i++)    //use for loop to copy each available resource in the workArr  
            workArr[i] = availableArr[i];  
  

        // counter for when system is in not safe state or all process not finish
        int counter = 0;  
          
        //iterating until all processes are not finished  
        while (counter < totProcess)  
        {  
            boolean foundSafeSystem = false;  
            for (int m = 0; m < totProcess; m++)  
            {  
                if (finishProcesses[m] == false)        // process not finished  
                {  
                    int j;  
                      
                    //check whether the needValue > workValue  
                    for (j = 0; j < totResources; j++)  
                        if (needArr[m][j] > workArr[j])      //check current need resource with work  
                            break;  
  

                    if (j == totResources)  
                    {  
                        for (int k = 0 ; k < totResources ; k++)  
                            workArr[k] += allocationArr[m][k];  
  
                        // insert currentProcess to safeSequenceArr  
                        safeSequenceArr[counter++] = m;  
  
                        // finish the process
                        finishProcesses[m] = true;  
  
                        foundSafeSystem = true;  
                    }  
                }  
            } 
            // the system  is not in safe state  if foundSafeSystem is false  
            if (foundSafeSystem == false)  
            {  
                System.out.print("System is not in a safe state due to lack of resource!");  
                return false;  
            }  
        } 
        // print the safe sequence  
        System.out.print("System is in safe state, one of the possible sequence is: ");  
        for (int i = 0; i < totProcess ; i++)  
            System.out.print("P"+safeSequenceArr[i] + " ");  
  
        return true;  
    }
     
}

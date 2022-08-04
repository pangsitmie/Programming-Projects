package bankersalgorithm;

import static bankersalgorithm.Bankers.checkSafeSystem;
import java.util.Scanner;


/**
 *
 * @author jeriel
 */
public class BankersAlgorithm {

    public static void main(String[] args) {
        int nProcesses, nResources;  
          
        //Input Scanner
        Scanner sc = new Scanner(System.in);  
          
        //total number of procesess
        System.out.print("Enter total number of processes: ");  
        nProcesses = sc.nextInt();  
          
        //total number of resources
        System.out.print("Enter total number of resources: ");  
        nResources = sc.nextInt();  
          
        int processes[] = new int[nProcesses];  
        for(int i = 0; i < nProcesses; i++){  
            processes[i] = i;  
        }  
          
        int[] availableArr = new int[nResources];  
        for( int i = 0; i < nResources; i++){  
            System.out.print("Available resource"+ i +": ");  
            availableArr[i] = sc.nextInt();  
        } 
        System.out.println("");
          
        int[][] needArr = new int[nProcesses][nResources];  
        for( int i = 0; i < nProcesses; i++){  
            for( int j = 0; j < nResources; j++){  
                System.out.print("Enter the resource "+ j +" that is needed for process"+ i +": ");  
                needArr[i][j] = sc.nextInt();  
            }
            System.out.println("");
        }  
          
        int[][] allocationArr = new int[nProcesses][nResources];  
        for( int i = 0; i < nProcesses; i++){  
            for( int j = 0; j < nResources; j++){  
                System.out.print("How many instances of resource"+ j +" are allocated to process"+ i +": ");  
                allocationArr[i][j] = sc.nextInt();  
            }
            System.out.println("");
        }  
          
        //check whether the calculation is safe state or not
        checkSafeSystem(processes, availableArr, needArr, allocationArr, nProcesses, nResources);  
    
    }
    
}

package src.ejercicio_inversiones;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.StringTokenizer;

public class Inversiones_Main {

    public static void main(String[] args) {

        //Creamos las listas y las añadimos
        List<Entidad> lista = new ArrayList<Entidad>();
        
        añadirEntidades(lista);

        int[] sol = new int[lista.size()];
        int[] optSol = new int[lista.size()];
        
        double maxProfit = 0;

        bEntity(0,sol,lista,maxProfit,optSol);
        
    } 
    
    public static int[] bEntity(int stage, int[] sol, List<Entidad> lista, double maxProfit, int[] optSol){

        if (stage == sol.length){
            
            double totalProfit = totalProfitCombi(sol,lista);           
            if(totalProfit > maxProfit){
                maxProfit = totalProfitCombi(sol,lista);
                System.arraycopy(sol, 0, optSol, 0, sol.length);
            }
            
        } else {
            for (int i = 0; i <= 1; i++) {
                
                if(isPosible(sol, i, stage, lista)){
                    sol[stage]=i;
                    bEntity(stage+1, sol, lista, maxProfit, optSol);
                }  
            }
        }
        
        return optSol;
    }

    public static void añadirEntidades(List<Entidad> lista){
        
        File file1 = new File("C:\\Users\\B15-04m\\Documents\\Repositorios\\Disenio_de_interfaces\\Ejercicio_Inversiones\\src\\main\\java\\src\\ejercicio_inversiones\\Entidades.txt");
        
        try {
            FileReader ficheroIn = new FileReader(file1);
            BufferedReader bufferficheroIn = new BufferedReader( ficheroIn);
             
            String linea = bufferficheroIn.readLine();
            
            while(linea != null){
                
                StringTokenizer st = new StringTokenizer(linea);

                int start = Integer.parseInt(st.nextToken());
                int end = Integer.parseInt(st.nextToken());
                int profit = Integer.parseInt(st.nextToken());
                
                Entidad e = new Entidad(start,end,profit);
                
                lista.add(e);
                
                System.out.println(e.toString());
                linea = bufferficheroIn.readLine(); 

            }
            
            ficheroIn.close();
            bufferficheroIn.close();
            
        } catch (FileNotFoundException ex) {
            System.out.println("No se ha encontrado el fichero");
        } catch (IOException ex) {
            System.out.println("Error de E/S");
        }
        
    }
    
    public static double totalProfitCombi(int[] combinacion, List<Entidad> lista){
        double total = 0;
        
        for (int i = 0; i < lista.size(); i++) {
            
            if(combinacion[i] == 1){
                total += lista.get(i).totalProfit();
            }
            
        }
        
        return total;
    }
    
    public static boolean isPosible(int[] sol, int i, int stage, List<Entidad> lista){
        
        boolean posib = true;
        
        if(i != 0){
            for (int j = 0; j < stage; j++) {
                if( sol[j]==1 && lista.get(j).isOverlap(lista.get(stage))){
                    posib = false;
                }
            }
        }    
        
        return posib;
    }
    
    public static boolean isBetter(int[] sol, int[] optSol, List<Entidad> lista){
        boolean better = false;
        int addsol = 0, addsolOpt = 0;
        
        for (int i = 0; i < sol.length; i++) {
            addsol+=sol[i]*lista.get(i).totalProfit();
            addsolOpt+=optSol[i]*lista.get(i).totalProfit();   
        }
        
        if (addsol > addsolOpt)
            better = true;
        
        return better;
    }

}

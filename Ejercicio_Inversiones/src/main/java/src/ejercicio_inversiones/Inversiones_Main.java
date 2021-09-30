package src.ejercicio_inversiones;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class Inversiones_Main {

    public static void main(String[] args) {

        //Creamos las listas y las añadimos
        ArrayList<Entidad> lista = new ArrayList<Entidad>();
        
        añadirEntidades(lista);
        
        ArrayList<Boolean> combinacion = new ArrayList<Boolean>();
        ArrayList<Boolean> posibCombinacion = new ArrayList<Boolean>();
        
        double max = 0;
        
    }
    
    public static void inversiones(int stage, ArrayList<Entidad> lista, ArrayList<Boolean> combinacion, ArrayList<Boolean> posibCombinacion, double max){
        
        
        
        if (stage == combinacion.size()){
            
            double posibMax = totalProfitCombi(combinacion, lista);
            if (posibMax > max){
                max = posibMax;
                posibCombinacion = combinacion;
            }
            
        }
        
    }

    public static void añadirEntidades(ArrayList<Entidad> lista){
        
        File file1 = new File("C:\\Users\\chipi\\Documents\\Repositorios\\Disenio_de_interfaces\\Ejercicio_Inversiones\\src\\main\\java\\src\\ejercicio_inversiones\\Entidades.txt");
        
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
    
    public static double totalProfitCombi(ArrayList<Boolean> combinacion, ArrayList<Entidad> lista){
        double total = 0;
        
        for (int i = 0; i < lista.size(); i++) {
            
            if(combinacion.get(i)){
                total += lista.get(i).totalProfit();
            }
            
        }
        
        return total;
    }

}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package priorities;

/**
 *
 * @author chipi
 */
public class Test_Main {
    
    public static void main(String[] args) {
        
        Matrix m = new Matrix();
        m.generateMatrix();
        m.printMatrix();
        
        if(!(m.matrix[1][1].isInTheSamePosition(m.matrix[1][1])))
            System.out.println("\n\nEste método funciona");
       
        
    }
    
}

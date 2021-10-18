/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.util.Random;

/**
 *
 * @author b15-04m
 */
public class RandomNumber {
    
    private static final Random  r  = new Random();
    
    public static int randomNumber(int min, int max){
        
        return min + r.nextInt(max+1 - min);
        
    }
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package priorities;

import java.util.LinkedList;
import java.util.NoSuchElementException;
import java.util.Queue;

/**
 *
 * @author b15-04m
 */
public class Matrix implements DataMatrix {
    
    Character[][] matrix;
    Queue<Character> people;
    SortCharacters priorityQueue;

    public Matrix() {
        this.matrix = new Character[N][M];
        this.people = new LinkedList<Character>();
        generatePeople();
        this.priorityQueue = null;
    }
    
    public void generatePeople(){
        for (int i = 0; i < 200; i++) {
            people.add(new Character());
        }
    }
    
    public void generateMatrix(){
        
        // place neo and smith
        placeMainCharacters();
        
        // llenarla de personas
        poblateMatrix();
        
    }
    
    public void placeMainCharacters(){ //sustituir con un randomPlacement() en Character
        Smith smith = new Smith();
        Neo neo = new Neo();
        
        //smith random placement
        randomPlacement(smith);
        matrix[smith.getX()][smith.getY()] = smith;
        
        //neo couldn't be in the same position as smith
        randomPlacement(neo);
        while (neo.isInTheSamePosition(smith)){
            randomPlacement(neo);
        }
        matrix[neo.getX()][neo.getY()] = neo;

    }

    public void randomPlacement(Character c){ //place a character in a random position of the matrix
        c.setX(RandomNumber.randomNumber(0, M-1));
        c.setY(RandomNumber.randomNumber(0, N-1));
    }
    
    public void poblateMatrix(){ //place characters in the empty spaces
        try {
            for (int i = 0; i < matrix.length; i++) {
                for (int j = 0; j < matrix[0].length; j++) {
                    if(matrix[i][j] == null)
                        matrix[i][j] = people.remove();
                }
            }
        } catch (NoSuchElementException e) {
            System.out.println("No more characters available");
        }
            
        
    }
    
    public void printMatrix(){
        
        for (int i = 0; i < matrix.length; i++) {
            System.out.print("\nx = "+i+" ------------------------------------------------------------------------------------------------------------------------------------------\n");
            
            for (int j = 0; j < matrix[0].length; j++) {
                String name = matrix[i][j].getName();
                while(name.length()<20){
                    name = name.concat(" ");
                }
                System.out.print(name+" y = "+j+" | ");
            }
            
        }
        
    }
    
}

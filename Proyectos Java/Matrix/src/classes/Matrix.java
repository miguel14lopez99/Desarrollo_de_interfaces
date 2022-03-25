/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import java.util.LinkedList;
import java.util.NoSuchElementException;
import java.util.Queue;

/**
 *
 * @author b15-04m
 */
public class Matrix implements DataMatrix {
    
    private Character[][] matrix;
    private Queue<Character> people;
    private SortCharacters priorityQueue;
    
    private Smith smith;
    private Neo neo;

    public Matrix() {
        this.matrix = new Character[N][M];
        this.people = new LinkedList<Character>();
        generatePeople();
        this.priorityQueue = new SortCharacters();
        
        //neo and smith are part of matrix, this makes easy to find them
        smith = new Smith();
        neo = new Neo();
        
        //place all the characters and show it throught the console
        generateMatrix();
        printMatrix();
    }

    public Character[][] getMatrix() {
        return matrix;
    }

    public Queue<Character> getPeople() {
        return people;
    }

    public SortCharacters getPriorityQueue() {
        return priorityQueue;
    }

    public Smith getSmith() {
        return smith;
    }

    public Neo getNeo() {
        return neo;
    }

    
    public void generatePeople(){ // fills the people queue of characters
        for (int i = 0; i < 200; i++) {
            people.add(new Character());
        }
    }
    
    public void generateMatrix(){
        
        // place neo and smith
        placeMainCharacters();
        
        // fill the matrix with characters
        poblateMatrix();
        
    }
    
    public void placeMainCharacters(){ //sustituir con un randomPlacement() en Character
 
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
    
    public void poblateMatrix(){ //place characters in the empty positions
        try {
            for (int i = 0; i < matrix.length; i++) {
                for (int j = 0; j < matrix[0].length; j++) {
                    if(matrix[i][j] == null){
                        matrix[i][j] = people.remove();
                        matrix[i][j].setX(i);
                        matrix[i][j].setY(j);
                    }
                }
            }
        } catch (NoSuchElementException e) {
            System.out.println("No more characters available");
        }

    }
    
    public void fillPriorityQueue(){
        
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                if(!(matrix[i][j] instanceof Neo) && !(matrix[i][j] instanceof Smith) && !(matrix[i][j] == null))
                    priorityQueue.add(matrix[i][j]);
            }
        }    
        
    }
    
    public void printMatrix(){
        
        String name;
        
        for (int i = 0; i < matrix.length; i++) {
            System.out.print("\n-------------------------------------------------------------------------------------------------------------------\n|");
            
            for (int j = 0; j < matrix[0].length; j++) {
                if (matrix[i][j] == null){
                    name = "**Dead**";
                }else{
                    name = matrix[i][j].getName();
                }
                while(name.length()<20){
                    name = name.concat(" ");
                }
                System.out.print(name+" | ");
            }
            
        }
        System.out.print("\n-------------------------------------------------------------------------------------------------------------------\n");;
        
    }
    
    public int deadCharacters(){
        
        int cont = 0; // counts the dead characters
        
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                
                if(matrix[i][j] == null || matrix[i][j].death > DataCharacter.maxDeath){
                    // make this position null
                    matrix[i][j] = null;
                    cont++;
 
                } else {
                    
                    matrix[i][j].addDeath();
                    
                }
                
            }
        }
        
        poblateMatrix(); //fills the null positions
        
        return cont;
    }
    
    public void smithPerform(){ // if there are no people to infect the game is over
        
        fillPriorityQueue(); //takes all the characters and sort them
        
        if(priorityQueue.size() >= smith.getInfect() ){
            for (int i = 0; i < smith.getInfect(); i++) {
                Character c = priorityQueue.remove(); //remove a character of the priority queue
                matrix[c.getX()][c.getY()] = null;    //and then the position is null
            }

        } else {
            for (int i = 0; i < priorityQueue.size(); i++) {
                Character c = priorityQueue.remove(); //remove a character of the priority queue
                matrix[c.getX()][c.getY()] = null;    //and then the position is null
            }
        }
        priorityQueue.makeEmptyQueue(); //clear the priority queue for the next time

    }
    
    public int neoPerform(){
        
        int cont = 0;
        
        neo.updateIsTheOne();
        
        int x = neo.getX();
        int y = neo.getY();
        
        if(neo.IsTheOne()){
            
            for (int i=-1; i<=1; i++){
                for(int j=-1; j<=1; j++){
                    if((x+i)>=0 && (x+i)<=matrix.length-1 && (y+j)>=0 && (y+j)<=matrix.length-1){
                        if(matrix[x+i][y+j] == null){
                            matrix[x+i][y+j] = new Character(); //Neo inserts a <<new>> character in the matrix
                            matrix[x+i][y+j].setX(x+i);         //new character takes his new coordinates
                            matrix[x+i][y+j].setY(y+j);
                            cont++;
                        }
                    }
                }
            }
            
        }
        
        return cont;
    }
    
    public void neoJump(){
        
        //Neo's initial coordinates
        int x = neo.getX();
        int y = neo.getY();
        
        //neo now have other coordinates, not in the matrix
        randomPlacement(neo);
        
        Character c = matrix[neo.getX()][neo.getY()];
        
        if(c != null){
            if(!(c instanceof Neo)){
                //change the character coordinates, not in the matrix 
                c.setX(x);
                c.setY(y);

                //place the character in Neo's initial position, in the matrix
                matrix[x][y] = c;
                //place Neo in the new position, in the matrix
                matrix[neo.getX()][neo.getY()] = neo;
            }
        } else {
            matrix[x][y] = c;
            matrix[neo.getX()][neo.getY()] = neo;
        }
 
    }
    
    public boolean isGameOver(){
        
        boolean end = true;
        
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                if(!(matrix[i][j] instanceof Neo) && !(matrix[i][j] instanceof Smith) && !(matrix[i][j] == null)){
                    end = false;
                }
            }
        }
        
        return end;
    }
}

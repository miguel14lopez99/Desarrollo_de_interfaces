/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package priorities;

import java.util.PriorityQueue;

/**
 *
 * @author b15-04m
 */
public class SortCharacters {
    
    private PriorityQueue<Character> QueueCharacter;

    public SortCharacters() {
        this.QueueCharacter = new PriorityQueue();
    }
    
    public void makeEmptyQueue(){    
        QueueCharacter.clear();  
    }
    
    public boolean isEmpty(){
        return QueueCharacter.isEmpty();
    }
    
    public void add(Character c){      
        QueueCharacter.add(c);
    }
    
    public Character remove(){
        return QueueCharacter.remove();   
    }
    
    public int size(){
        return QueueCharacter.size();
    }
    
    
}

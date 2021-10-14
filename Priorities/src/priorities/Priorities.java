/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package priorities;

/**
 *
 * @author b15-04m
 */
public class Priorities {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
      
        SortCharacters q = new SortCharacters();
        
        for (int i = 0; i < 5; i++) {
            Character c = new Character();
            q.add(c);
        }
        
        while (!q.isEmpty()){
            System.out.println(q.remove().death+" ");
        }
        
    }
    
}

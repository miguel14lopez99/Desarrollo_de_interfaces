/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package priorities;

import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author chipi
 */
public class Test_Main {
    
    public static void main(String[] args) {
        
        Matrix m = new Matrix();
        
        Runnable runnable = new Runnable(){
           
            public void run(){
                
                int max_time = 30; // 30 seconds
                int time = 1;
                boolean gameOver = false;
                
                do{
                    try {
                        if (time % 1 == 0){
                            //System.out.println("Every second");

                            //check the matrix removing death characters or add 10% of death percentage to the alive characters
                            int deaths = m.deadCharacters();
                            System.out.println(deaths + " people have died");

                        }

                        if (time % 2 == 0){
                            //System.out.println("Every 2 seconds");

                            m.getSmith().updateInfection();
                            System.out.println("Smith is ready to attack");

                            m.smithPerform();
                            System.out.println("Smith infected "+ m.getSmith().getInfect() +" people");
                        }

                        if (time % 5 == 0){
                            //System.out.println("Every 5 seconds");

                            int alive = m.neoPerform(); 
                            System.out.println("Neo brings " + alive + " people to Matrix");
                            m.neoJump();
                            System.out.println("Neo jumps");

                            System.out.println("----------------------------------------------------------------------------------------------");

                        }

                        //check the game is over
                        gameOver = m.isGameOver(); // I don't know why this variable is not used

                        m.printMatrix();

                        Thread.sleep(100);
                        time += 1;
                    } catch (InterruptedException ex) {
                        Logger.getLogger(Test_Main.class.getName()).log(Level.SEVERE, null, ex);
                    }

                } while (time <= max_time || !m.isGameOver());
                
                if(m.isGameOver()){
                    System.out.println("Smith has finished with humanity");
                } else {
                    System.out.println("Neo has saved the humanity");
                }
            }
 
            
        };
        
        Thread hilo = new Thread(runnable);
        hilo.start();
        
        
    }
    
}

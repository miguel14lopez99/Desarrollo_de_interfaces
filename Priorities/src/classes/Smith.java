/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

import static classes.DataCharacter.maxInfect;

/**
 *
 * @author b15-04m
 */
class Smith extends Character {
        
    private int infect;

    public Smith() {
        super("Smith",null,-1,-1,-1,-1);   
        this.infect = 0;
    }

    public void updateInfection(){ //takes a random capacity to infect
        infect = RandomNumber.randomNumber(1, maxInfect);
    }

    public int getInfect() {
        return infect;
    }

    
}

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
class Neo extends Character {
        
    private boolean isTheOne;

    public Neo() {

        super("Neo",null,-1,-1,-1,-1);
        this.isTheOne = false;
    }

    public  void updateIsTheOne(){

        int fiftyFifty = RandomNumber.randomNumber(0, 1);

        if(fiftyFifty == 1){
            isTheOne = true;
        } else {
            isTheOne = false;
        }

    }

    public boolean IsTheOne() {
        return isTheOne;
    }
         
        
  
    }

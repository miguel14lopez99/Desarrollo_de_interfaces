/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classes;

/**
 *
 * @author b15-04m
 */
public interface DataCharacter {
    
    final String[] names = {"Jeremy Cowan",
                            "Giselle Cooke",
                            "Matilda Vincent",
                            "Axel Eaton",
                            "Camron Montoya",
                            "Graham Maynard",
                            "Miya Patrick",
                            "Aden Griffith",
                            "Nathaniel Figueroa",
                            "Jessica Duncan",
                            "Ellen Hooper",
                            "Ezekiel Kemp",
                            "Izabelle Morgan",
                            "Alio Li",
                            "Hugo Chang",
                            "Makhi Bailey",
                            "Kingston Bullock",
                            "Dakota Nielsen",
                            "Miguel",
                            "Luis"}; 
    
    final String[] cities ={"Akron, Ohio",
                            "Miami, Florida",
                            "Washington, District of Columbia",
                            "Tulsa, Oklahoma",
                            "Jacksonville, Florida",
                            "Montgomery, Alabama",
                            "Denver, Colorado",
                            "El Paso, Texas",
                            "Philadelphia, Pennsylvania",
                            "Long Beach, California"};
    
    final int maxAge = 100;
    final int minAge = 0;
    final int maxDeath = 70;
    final int minDeath = 0;
    
    final int maxInfect = 7;
    
    void print();
    void prompt();
    void generate();
    
}

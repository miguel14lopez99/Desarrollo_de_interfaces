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
public class Character implements DataCharacter,Comparable<Character> {
    
    class Location {
    
        private double longitude;
        private double latitude;
        private String city;

        public Location() { // inicializarlo en random
            this.longitude = RandomNumber.randomNumber(0, 180);
            this.latitude = RandomNumber.randomNumber(0, 90);
            this.city = cities[RandomNumber.randomNumber(0, cities.length-1)];
        }

        public double getLongitude() {
            return longitude;
        }

        public double getLatitude() {
            return latitude;
        }

        public String getCity() {
            return city;
        }

        @Override
        public String toString() {
            return "Location{" + "longitude=" + longitude + ", latitude=" + latitude + ", city=" + city + '}';
        }
        
    }

    protected String name; 
    protected Location location;
    protected int age;
    protected int death;
    protected int x,y;

    public Character() { // estos datos tambien se generan aleatoriamente
        this.name = names[RandomNumber.randomNumber(0,names.length-1)]; //random de una lista de nombres
        this.location = new Location();
        this.age = RandomNumber.randomNumber(minAge, maxAge);
        this.death = RandomNumber.randomNumber(minDeath, maxDeath);
        this.x = -1;
        this.y = -1;
    }

    public Character(String name, Location location, int age, int death, int x, int y) {
        this.name = name;
        this.location = location;
        this.age = age;
        this.death = death;
        this.x = x;
        this.y = y;
    }
    
    

    public String getName() {
        return name;
    }

    public Location getLocation() {
        return location;
    }

    public int getAge() {
        return age;
    }

    public int getDeath() {
        return death;
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    public void setX(int x) {
        this.x = x;
    }

    public void setY(int y) {
        this.y = y;
    }

    @Override
    public void print() {
        // has not been implemented yet
    }

    @Override
    public void prompt() {
        // has not been implemented yet
    }

    @Override
    public void generate() {
        // has not been implemented yet
    }
    
    @Override
    public String toString() {
        return "Character{" + "name=" + name + ", location=" + location + ", age=" + age + ", death=" + death + ", x=" + x + ", y=" + y + '}';
    }
    
    public int compareTo(Character c){
        int r = 0; // prioridad
        if (c.getDeath() > this.getDeath())
            r--;
        else
            r++;
        
        return r;
    }
    
    public boolean isInTheSamePosition(Character c){
        boolean samePos = false;
        
        if (this.x == c.getX() && this.y == c.getY())
            samePos = true;
        
        return samePos;
    }
    
    public void addDeath(){
        
        if(death > 0) // this makes inmortal neo and smith, because their death variable is -1
            death += 10; 
        
    }
    
}

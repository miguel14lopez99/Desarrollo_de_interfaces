/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bishop;

/**
 *
 * @author b15-04m
 */
public class Cell {
    
    private int row;
    private int column;
    private boolean visited;

    public Cell(int row, int column) {
        this.row = row;
        this.column = column;
    }

    public int getRow() {
        return row;
    }

    public void setRow(int row) {
        this.row = row;
    }

    public int getColumn() {
        return column;
    }

    public void setColumn(int column) {
        this.column = column;
    }

    public boolean isVisited() {
        return visited;
    }

    public void setVisited(boolean visited) {
        this.visited = visited;
    }
    
    public int distance(Cell c){
        return Math.max(Math.abs(row-c.getRow()),Math.abs(column-c.getColumn()));
    }
    
    public boolean isOdd(){
        return (this.getRow()+this.getColumn()) % 2 != 0;
    }
    
    public boolean isEven(){
        return (this.getRow()+this.getColumn()) % 2 == 0;
    }

    @Override
    public String toString() {
        return "(" + row + "," + column + ")";
    }

    @Override
    public int hashCode() {
        int hash = 7;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Cell other = (Cell) obj;
        if (this.row != other.row) {
            return false;
        }
        if (this.column != other.column) {
            return false;
        }
        return true;
    }
    
    
    
}

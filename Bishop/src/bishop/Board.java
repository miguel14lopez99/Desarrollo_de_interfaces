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
public class Board implements Data {
    
    private Cell[][] chessboard;
    
    public Board() {
        chessboard = new Cell[N][M];
        startChess();
    }
    
    public void startChess(){
        for (int i = 0; i < chessboard.length; i++) {
            for (int j = 0; j < chessboard[0].length; j++) {
            
                chessboard[i][j] = new Cell(i,j);
                
            }
        }
    }
    
    public boolean isVisited(Cell c){
        return (chessboard[c.getRow()][c.getColumn()].isVisited()); 
        // return c.isVisited(); no cumple la encapsulación
    }
    
    public void setVisited(Cell c){
        chessboard[c.getRow()][c.getColumn()].setVisited(true);
    }
    
    public void resetVisited(Cell c){
        chessboard[c.getRow()][c.getColumn()].setVisited(false);
    }
    
    public boolean isInside(Cell c){    
        return (c.getRow()>=0 && c.getRow()<N && c.getColumn()>=0 && c.getColumn()<M);
    }
    
    public boolean isMovementOK(int i, int j){
        return (i!=0 && j!=0);
    }
    
    public boolean isPathOK(Cell source, Cell target){
        return (source.isEven() && target.isEven()) || (source.isOdd() && target.isOdd());
    }

}

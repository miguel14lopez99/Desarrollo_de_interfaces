/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bishop;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author b15-04m
 */
public class Bishop {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Cell source = new Cell(2,3);
        Cell target = new Cell(6,3);
        Board b = new Board();
        List<Cell> list = new ArrayList();
        list.add(source);
        b.isVisited(source);
        
        if(b.isPathOK(source, target)){
            paths(source, target, b, list);
        } else {
            System.out.println("There is no posible path");
        }
            
    }
    
    public static void paths(Cell source, Cell target, Board board, List<Cell> list){
        
        Cell aux = null;
        
        if (source.equals(target)){
            
            System.out.println(list);
            
        }else{
            
            for (int i=-1; i<=1; i++){
                for(int j=-1; j<=1; j++){
                    
                    aux = new Cell(source.getRow()+i, source.getColumn()+j);
                    
                    if(board.isInside(aux)){
                        if(board.isMovementOK(i, j)){
                            if(!board.isVisited(aux)){
                                if(aux.distance(target) < source.distance(target)){
                                    board.setVisited(aux);
                                    list.add(aux);                                   
                                    paths(aux, target, board, list);
                                    board.resetVisited(aux);
                                    list.remove(aux);
                                }
                            }
                        }       
                    }
                    
                }
            }
            
        }
        
    }
    
}

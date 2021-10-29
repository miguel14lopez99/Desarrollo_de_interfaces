
package investment;

import java.util.ArrayList;
import java.util.List;

public class Investment {

    public static void main(String[] args) {
        List<Entity> list=new ArrayList();
        list.add(new Entity(3,4,300));
        list.add(new Entity(10,12,330));
        list.add(new Entity(2,5,340));
        list.add(new Entity(1,4,310));
        list.add(new Entity(5,9,320));
        list.add(new Entity(4,10,350));
        list.add(new Entity(6,8,260));
        list.add(new Entity(8,11,360));
        list.add(new Entity(2,12,310));
        list.add(new Entity(1,7,340));
        list.add(new Entity(7,12,325));
        
        int [] sol=new int [list.size()];
        int [] solOpt=new int [list.size()];
        
        bEntity(0,sol,solOpt,list);
        for (int i=0;i<solOpt.length;i++)
            System.out.print(solOpt[i] + " ");
    }
    
    public static void bEntity(int stage, int sol[],int solOpt[],List<Entity> list) {
        if (stage==sol.length) {
            if (isBetter(sol, solOpt,list)) 
                    System.arraycopy(sol,0,solOpt,0,sol.length);
        }
        else {
            for (int i =0;i<=1;i++) {
                if (isPossible(sol,i,stage,list)) {
                    sol[stage]=i;
                    bEntity(stage+1,sol,solOpt,list);
                }
            }
        }
    }
    
    public static boolean isPossible(int sol[],int i,int stage, List<Entity> list) {
        boolean possible =true;
        if (i!=0) {
            for (int k=0;k<stage && possible;k++) {
                if (sol[k]==1 && list.get(k).isOverlap(list.get(stage)))
                    possible=false;
            }            
        }
        return possible;
    }
    
    public static boolean isBetter(int sol[],int solOpt[],List<Entity> list){
        int addsol=0,addsolOpt =0;
        for (int k=0;k<sol.length;k++) {
            addsol+=sol[k]*list.get(k).totalProfit();
            addsolOpt+=solOpt[k]*list.get(k).totalProfit();
        }
        return addsol>addsolOpt;
    } 
}

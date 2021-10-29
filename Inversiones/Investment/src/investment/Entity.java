
package investment;

public class Entity {
    public static int cont=0;
    private int id;
    private int start;
    private int end;
    private int profit;

    public Entity(int start, int end, int profit) {
        this.id=++cont;
        this.start = start;
        this.end = end;
        this.profit = profit;
    }

    public int getStart() {
        return start;
    }

    public int getEnd() {
        return end;
    }

    public int getProfit() {
        return profit;
    }
    
    public double totalProfit () {
        return (getEnd()-getStart()+1)*getProfit();
    }

    @Override
    public int hashCode() {
        int hash = 7;
        return hash;
    }

    public boolean isOverlap(Entity entity) {
        boolean res=true;
        if (getStart()<entity.getStart() && getEnd()<entity.getStart()
            || entity.getStart()<getStart() && entity.getEnd()<getStart())
            res=false;
        return res;
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
        final Entity other = (Entity) obj;
        if (this.start != other.start) {
            return false;
        }
        if (this.end != other.end) {
            return false;
        }
        if (this.profit != other.profit) {
            return false;
        }
        return true;
    }    
}

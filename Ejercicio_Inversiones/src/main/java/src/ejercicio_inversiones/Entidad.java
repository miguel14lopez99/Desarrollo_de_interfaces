package src.ejercicio_inversiones;

public class Entidad {

    //ATRIBUTOS
    private static int cont = 0;

    private int id;
    private int start;
    private int end;
    private double profit;

    public Entidad(int start, int end, double profit) {

            this.id = ++cont;
            this.start = start;
            this.end = end;
            this.profit = profit;

    }

    public int getId() {
            return id;
    }

    public int getStart() {
            return start;
    }

    public int getEnd() {
            return end;
    }

    public double getProfit() {
            return profit;
    }

    public double totalProfit(int start, int end, double profit) {

            return (end-start+1)*profit;

    }

    public boolean isOverlap (Entidad e) {

            boolean solapa = false;

            if(start <= e.getStart() && end >= e.getStart())
                    solapa = true;
            if (start >= e.getStart() && start <= e.getEnd())
                    solapa = true;

            return solapa;

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
        final Entidad other = (Entidad) obj;
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

    @Override
    public String toString() {
        return "Entidad{" + "id=" + id + ", start=" + start + ", end=" + end + ", profit=" + profit + '}';
    }
	
}

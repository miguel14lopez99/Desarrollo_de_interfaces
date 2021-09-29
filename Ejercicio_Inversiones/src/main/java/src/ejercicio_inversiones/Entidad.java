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
        
        
	
}

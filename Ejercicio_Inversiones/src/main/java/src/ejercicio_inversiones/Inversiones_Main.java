package src.ejercicio_inversiones;

public class Inversiones_Main {

	public static void main(String[] args) {
		
		Entidad e1 = new Entidad(6,8,300);
		Entidad e2 = new Entidad(1,5,150);
		
		System.out.println(e1.isOverlap(e2)); 

	}

}

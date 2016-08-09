using System;
using System.Collections.Generic;
					
public class CircunferenciaApp
{
    public static void Main()
    {
        Console.WriteLine("Comprobando si dos circunferencias se interceptan...");

        var ca = new Circunferencia("A", new Punto(8, 10), 18);
        var cb = new Circunferencia("B", new Punto(10, 10), 18);
		
		Console.WriteLine(ca);
		Console.WriteLine(cb);
		
		if(ca.Intercepta(cb))
		{
			Console.WriteLine("Si se interceptan...");
			
			var puntos = ca.ObtenerPuntosDeIntercepcionCon(cb);
			
			if (puntos.Count > 0)
            {
                Console.WriteLine("Tiene solucion real en:");
				
				for(int i = 0 ; i < puntos.Count; i++)
				{
					Console.WriteLine("Punto {0}: {1}", i + 1, puntos[i]);
				}
            }
            else
            {
                Console.WriteLine("No tiene solucion real");
            }
		}
		else
        {
            Console.WriteLine("No se interceptan.");
        }		
	}
}

public struct Circunferencia
{
    private readonly string nombre;
	private readonly Punto centro;
    private readonly double radio;

    public Circunferencia(string nombre, Punto centro, double radio)
    {
        this.nombre = nombre;
		this.centro = centro;
		this.radio = radio;    
    }
    
	public string Nombre { get { return nombre; } }
	
	public Punto Centro { get { return centro; } }
	
    public double Radio { get { return radio; } }

    public bool Intercepta(Circunferencia otra)
    {
        double d = this.DistanciaEntreCentrosCon(otra);

        return d >= Math.Abs(this.Radio - otra.Radio) && d <= this.Radio + otra.Radio;
    }

    public double DistanciaEntreCentrosCon(Circunferencia otra)
    {
        return Math.Pow(Math.Pow(this.Centro.X - otra.Centro.X, 2) + Math.Pow(this.Centro.Y - otra.Centro.Y, 2), 0.5);
    }

    public IList<Punto> ObtenerPuntosDeIntercepcionCon(Circunferencia otra)
    {
        if (!this.Intercepta(otra))
            throw new Exception("Las circunferencias no se interceptan.");

        var puntos = new List<Punto>();

        //Temporarias para el cálculo de los puntos y los coeficientes
        double t1 = -(otra.Centro.Y - otra.Centro.X) / (otra.Centro.X - this.Centro.X);
        double t2 = (otra.Centro.X * otra.Centro.X - this.Centro.X * this.Centro.X + otra.Centro.Y * otra.Centro.Y -
                     this.Centro.Y * this.Centro.Y + this.Radio * this.Radio - otra.Radio * otra.Radio) /
                    (2 * (otra.Centro.X - this.Centro.X));

        //Coeficientes de la ecuación cuadratica
        double a = t2 * t2 + 1;
        double b = 2 * (t1 * (t2 - this.Centro.X) - this.Centro.Y);
        double c = t2 * t2 - 2 * t2 * this.Centro.X + this.Centro.X * this.Centro.X + this.Centro.Y * this.Centro.Y -
                   this.Radio * this.Radio;

        double discriminante = b * b - 4 * a * c;

        if (discriminante > 0)
        {
            //Cálculo de los puntos solucion en base a las dos variantes de la formula cúadratica
            for (int i = 1; i >= -1; i = i - 2)
            {
                double y = (b + i * Math.Pow(discriminante, 0.5)) / (2 * a);
                double x = y * t1 + t2;

                puntos.Add(new Punto(x, y));
            }
        }
        return puntos.ToArray();
    }
	
	public override string ToString()
    {
		return string.Format("Circunferencia {0}: Centro: {1} Radio: {2:G3}", Nombre, Centro, Radio);
    }

}

public struct Punto
{
    private readonly double x;
    private readonly double y;

    public Punto(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X { get { return x; } }

    public double Y { get { return y; } }

    public override string ToString()
    {
        return string.Format("({0:G3},{1:G3})", X, Y);
    }

}
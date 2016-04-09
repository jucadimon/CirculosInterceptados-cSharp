using System;
using System.Math;

namespace ingCivil
{
    public class circunferencias
    {
        // ruta del compilador:
        // PATH C:\Windows\Microsoft.NET\Framework\v4.0.30319;%PATH%
        // ruta de ubicacion del archivo a compilar:
        // cd C:\Users\usuario\Documents\vs code codigo fuente
        // Compilar con emsamvblado externo:
        // csc /out:TestCode.exe /reference:MathLibrary.DLL TestCode.cs
        
        static void Main()
        {
            bool bandera = false;
            Console.WriteLine("Comprobar si dos circunferencias se cruzan");
            
            //definimos nuestras circunferencias:
            Circunferencia Circunferencia1 = new Circunferencia(10,11,8);
            Circunferencia Circunferencia2 = new Circunferencia(15,18,8);
            
            double d;// distancia entre los centros de las dos circunferencias
            d = Math.Pow(( Math.Pow(CircunferenciaA.x - CircunferenciaB.x,2) + Math.Pow(CircunferenciaA.y - CircunferenciaB.y,2) ),0.5);
            if (d >= Math.Abs( CircunferenciaA.radio - CircunferenciaB.radio )  && d <= ( CircunferenciaA.radio + CircunferenciaB.radio ))
            {
                bandera = true;
            } 
            else 
            {
                bandera = false;
            }
            
            if (bandera)
            {
                Console.WriteLine("Si se Cruzan.");
                //HallarIntersecciones();
                double _x1=0, _y1=0; //primer punto de interseccion
                double _x2=0, _y2=0; //segundo punto de interseccion
                double x1=0, y1=0, x2=0, y2=0; //coordenadas de los centros de los dos circulos
                double r1=0, r2=0; //radios de lso dos circulos
                double x=0, y=0, D=0, a=0, b=0, c=0; //comodines
                double t1=0, t2=0; // reducciones
                x1 = CircunferenciaA.x;
        y1 = CircunferenciaA.y;
        r1 = CircunferenciaA.radio;
        
        x2 = CircunferenciaB.x;
        y2 = CircunferenciaB.y;
        r2 = CircunferenciaB.radio;
        
        t1 = - (y2 - y1) / (x2 - x1);
        t2 = (x2*x2 - x1*x1 + y2*y2 - y1*y1 + r1*r1 - r2*r2) / (2 * (x2 - x1));
        
        a = t2*t2 + 1;
        b = 2 * (t1 * (t2 - x1) - y1);
        c = t2*t2 - 2 * t2 * x1 + x1*x1 + y1*y1 - r1*r1;
        
        D = b*b - 4 * a * c;
        
                if (D > 0)
        {
            _y1 = (b + Math.Pow(D,0.5)) / (2 * a);
            _x1 = _y1 * t1 + t2;
            _y2 = (b - Math.Pow(D,0.5)) / (2 * a);
            _x2 = _y2 * t1 + t2;
            Console.WriteLine("Tiene solucion real");
            Console.WriteLine("Tiene solucion 1: P1=("+_x1+","+_y1+")");
            Console.WriteLine("Tiene solucion 2: P2=("+_x2+","+_y2+")");
        }
        else if(D < 0)
        {
            Console.WriteLine("No tiene solucion real");
        }
                
            }
            else
            {
                Console.WriteLine("Las circunferencias NO se Cruzan.");
            }
            
            Console.ReadLine();
            Console.ReadKey();
            
        }
    }
    public struct Circunferencia
    {
        double x;//coordenada x de la ubicacion de circulo
        double y;//coordenada y de la ubicacion de circulo
        double radio;
        public Circunferencia(double cx, double cy, double vradio)
        {
            x = cx;
            y = cy;
            radio = vradio;
        }
    }
    public void Comprobar()
    {
        
        bool bandera = false;
        Circunferencia CircunferenciaA = new Circunferencia(10,11,8);
        //CircunferenciaA = Circunferencia1;
        Circunferencia CircunferenciaB = new Circunferencia(15,18,8);
        //CircunferenciaB = Circunferencia2;
        
        double d;// distancia entre los centros de las dos circunferencias
        d = Math.Pow(( Math.Pow(CircunferenciaA.x - CircunferenciaB.x,2) + Math.Pow(CircunferenciaA.y - CircunferenciaB.y,2) ),0.5);
        if (d >= Math.Abs( CircunferenciaA.radio - CircunferenciaB.radio )  && d <= ( CircunferenciaA.radio + CircunferenciaB.radio ))
        {
            bandera = true;
            return bandera;
        } 
        else 
        {
            bandera = false;
            return bandera;
        }
    }
    static void HallarIntersecciones()
    {
        double _x1=0, _y1=0; //primer punto de interseccion
        double _x2=0, _y2=0; //segundo punto de interseccion
        double x1=0, y1=0, x2=0, y2=0; //coordenadas de los centros de los dos circulos
        double r1=0, r2=0; //radios de lso dos circulos
        double x=0, y=0, D=0, a=0, b=0, c=0; //comodines
        double t1=0, t2=0; // reducciones
       
        Circunferencia CircunferenciaA = new Circunferencia(10,11,8);
        //CircunferenciaA = Circunferencia1;
        Circunferencia CircunferenciaB = new Circunferencia(15,18,8);
        //CircunferenciaB = Circunferencia2;
        
        x1 = CircunferenciaA.x;
        y1 = CircunferenciaA.y;
        r1 = CircunferenciaA.radio;
        
        x2 = CircunferenciaB.x;
        y2 = CircunferenciaB.y;
        r2 = CircunferenciaB.radio;
        
        t1 = - (y2 - y1) / (x2 - x1);
        t2 = (x2*x2 - x1*x1 + y2*y2 - y1*y1 + r1*r1 - r2*r2) / (2 * (x2 - x1));
        
        a = t2*t2 + 1;
        b = 2 * (t1 * (t2 - x1) - y1);
        c = t2*t2 - 2 * t2 * x1 + x1*x1 + y1*y1 - r1*r1;
        
        D = b*b - 4 * a * c;
        if (D > 0)
        {
            _y1 = (b + Math.Pow(D,0.5)) / (2 * a);
            _x1 = _y1 * t1 + t2;
            _y2 = (b - Math.Pow(D,0.5)) / (2 * a);
            _x2 = _y2 * t1 + t2;
            Console.WriteLine("Tiene solucion real");
            Console.WriteLine("Tiene solucion 1: P1=("+_x1+","+_y1+")");
            Console.WriteLine("Tiene solucion 2: P2=("+_x2+","+_y2+")");
        }
        else if(D < 0)
        {
            Console.WriteLine("No tiene solucion real");
        }
        
    }
}

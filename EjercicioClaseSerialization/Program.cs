using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjercicioClaseSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> listaP = new List<Persona>();
            bool loop = true;
            IFormatter formatter = new BinaryFormatter();
            while (loop)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.- Crear Persona\n2.- Ver Personas\n3.- Cargar Personas\n4.- Guardar Personas\n5.- Salir");
                int result = int.Parse(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        Console.Write("Escriba el nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Escriba el apellido: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Escriba la edad: ");
                        int edad = int.Parse(Console.ReadLine());
                        Persona persona = new Persona(nombre, apellido, edad);
                        listaP.Add(persona);
                        Console.WriteLine("Persona Creada!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case 2:
                        for (int i = 0; i < listaP.Count(); i++)
                            Console.WriteLine("Persona " + (i + 1) + ": " + listaP[i]);
                        break;
                    case 3:
                        Persona obj;
                        Stream read = new FileStream("ArchivoPersonas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                        for (int i = 0; i < listaP.Count(); i++)
                        {
                            obj = (Persona)formatter.Deserialize(read);
                            Console.WriteLine("nombre: {0}\nApellido: {1}\nEdad: {2}", obj.Name, obj.Surname, obj.Age);
                        }
                        read.Close();
                        Console.WriteLine("Se han guardado las personas!");
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 4:
                        Stream stream = new FileStream("ArchivoPersonas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                        for (int i = 0; i < listaP.Count(); i++)
                            formatter.Serialize(stream, listaP[i]);
                        stream.Close();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case 5:
                        loop = false;
                        Console.WriteLine("Se ha Finalizado el programa!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}

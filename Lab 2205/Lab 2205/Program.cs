using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data;
using System.Reflection;
using ClassLibrary1;

namespace Lab_2205
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> Personas = new List<Person>();
            List<Address> Direcciones = new List<Address>();
            List<Car> Autos = new List<Car>();

            Address Eden = new Address("Paraiso", 0, "Eden", "Tierra", null, 0, 0, 0, true, false);
            Person Adan = new Person("Adan", "Primero", Convert.ToDateTime("00/00/0000"), Eden, "0", null, null);
            Person Eva = new Person("Eva", "Primero", Convert.ToDateTime("00/00/0000"), Eden, "1", null, null);
            Personas.Add(Adan);
            Personas.Add(Eva);
            Direcciones.Add(Eden);

            while (true)
            {

                Console.WriteLine("\t¡Bienvenido al registro civil!");
                Console.WriteLine("\nIngrese la opcion deseada: ");

                Console.WriteLine("\nPara comenzar necesitamos que ingrese su direccion");
                Console.WriteLine("Ingrese la calle (en minusculas): "); string Calle = Console.ReadLine();
                Console.WriteLine("Ingrese numero: "); string Numero = Console.ReadLine();
                Console.WriteLine("Ingrese Comuna (en minusculas): "); string Comuna = Console.ReadLine();

                int NumeroCalle = Convert.ToInt32(Numero);

                foreach (Address direccion in Direcciones)
                {
                    if (direccion.Street == Calle && direccion.Number == NumeroCalle && direccion.Commune == Comuna)
                    {
                        Console.WriteLine("\tSu direccion se encuentra registrada, continuaremos con el siguiente paso\n\nPorfavor ingresa tus datos a continuacion.");
                        Console.WriteLine("\nPrimer Nombre: "); string nombre = Console.ReadLine();
                        Console.WriteLine("Segundo Nombre: "); string nombre2 = Console.ReadLine();
                        Console.WriteLine("Fecha Nacimiento (dd/mm/aaaa): "); string FechaNacimiento = Console.ReadLine();
                        Console.WriteLine("Rut (Sin puntos ni guion): "); string Rut = Console.ReadLine();
                        Console.WriteLine("Rut Madre (Si no posee ingrese null): "); string RutMadre = Console.ReadLine();
                        Console.WriteLine("Rut Padre (Si no posee ingrese null): "); string RutPadre = Console.ReadLine();

                        Person RutMa;
                        Person RutPa;
                        DateTime FN = Convert.ToDateTime(FechaNacimiento);
                        if (RutMadre == "null")
                        {
                            RutMa = null;
                            if (RutPadre == "null")
                            {
                                RutPa = null;
                                Person Nuevapersona = new Person(nombre, nombre2, FN, direccion, Rut, RutMa, RutPa);
                                Personas.Add(Nuevapersona);
                            }
                            else
                            {
                                foreach (Person persona in Personas)
                                {
                                    if (persona.Rut == RutPadre)
                                    {
                                        RutPa = persona;
                                        Person Nuevapersona = new Person(nombre, nombre2, FN, direccion, Rut, RutMa, RutPa);
                                        Personas.Add(Nuevapersona);
                                        break;
                                    }

                                }

                                Console.WriteLine("Tu padre no se encuentra registrado, luego deberas registrarlo");
                            }
                        }
                        if (RutMadre != "null")
                        {
                            foreach (Person persona in Personas)
                            {
                                if (persona.Rut == RutMadre)
                                {
                                    RutPa = null;
                                    RutMa = persona;
                                    Person Nuevapersona = new Person(nombre, nombre2, FN, direccion, Rut, RutMa, RutPa);
                                    Personas.Add(Nuevapersona);
                                    break;
                                }
                            }

                        }
                        else
                        {
                            RutMa = null;
                            RutPa = null;
                            Person Nuevapersona = new Person(nombre, nombre2, FN, direccion, Rut, RutMa, RutPa);
                            Personas.Add(Nuevapersona);



                        }

                    }

                    Console.WriteLine("Tu direccion no se encuentra, tendremos que registrarla"); 
                    Console.WriteLine("Ingrese la cuidad: "); string Ciudad = Console.ReadLine();
                    Console.WriteLine("Ingrese el ano de construccion: "); int Ano = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el numero de baños: "); int Banos = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el numero de habitaciones: "); int habitaciones = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese si posee patio: \n1-Si \n2-No "); string Patio = Console.ReadLine();
                    Console.WriteLine("Ingrese si posee piscina: \n1-Si \n2-No "); string Piscina = Console.ReadLine();

                    bool patio;
                    bool piscina;

                    if (Patio=="1")
                    {
                        patio = true;
                        if (Piscina == "1")
                        {
                            piscina = true;
                            Address address = new Address(Calle, NumeroCalle, Comuna,Ciudad, null, Ano, habitaciones, Banos, patio, piscina);
                            Direcciones.Add(address);
                        }
                        else
                        {
                            piscina = false;
                            Address address = new Address(Calle, NumeroCalle, Comuna, Ciudad, null, Ano, habitaciones, Banos, patio, piscina);
                            Direcciones.Add(address);
                        }
                    }
                    else
                    {
                        patio = false;
                        patio = true;
                        if (Piscina == "1")
                        {
                            piscina = true;
                            Address address = new Address(Calle, NumeroCalle, Comuna,Ciudad, null, Ano, habitaciones, Banos, patio, piscina);
                            Direcciones.Add(address);
                        }
                        else
                        {
                            piscina = false;
                            Address address = new Address(Calle, NumeroCalle, Comuna,Ciudad, null, Ano, habitaciones, Banos, patio, piscina);
                            Direcciones.Add(address);
                        }

                    }
                    

                }

            }

        }
    }
}

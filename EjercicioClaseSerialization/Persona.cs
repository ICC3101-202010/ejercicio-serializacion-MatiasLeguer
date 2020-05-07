using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClaseSerialization
{
    [Serializable]
    public class Persona
    {
        private string name;
        private string surname;
        private int age;

        public string Name { get => name; }
        public string Surname { get => surname; }
        public int Age { get => age; }

        public Persona(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
    }
}

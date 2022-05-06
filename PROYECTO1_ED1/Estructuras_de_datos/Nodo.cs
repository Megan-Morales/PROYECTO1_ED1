using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03_ED_2022.Estructuras_de_datos
{
    public class Nodo<T>
    {
        public T value;
        public int totalConsultas = 1; //preguntar
        public Nodo<T> left;
        public Nodo<T> right;
        public int height;
    
        //Constructor de mi clase AVLnode
        public Nodo(T value)
        {
            this.value = value;
        }
    }
}

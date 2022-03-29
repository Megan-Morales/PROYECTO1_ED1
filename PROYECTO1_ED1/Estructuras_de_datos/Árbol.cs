using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab03_ED_2022.Comparison;
using Lab03_ED_2022.Estructura_de_Datos;

namespace Lab03_ED_2022.Estructuras_de_datos
{
    public class Árbol<T> : IEnumerable<T>, IEnumerable  // interfaz
    {
        public Compare<T> comparar { get; set; }
        public int ContadorRotaciones = 0;
        public int ComparacionesBusqueda = 0;
        public static Stopwatch tiempoOrdenamientoAvl = new Stopwatch();
        public double x = 0;
        //Varible
        Nodo<T> root;

        //Contructor de mi clase
        public Árbol()
        {
            this.root = null;
        }

        //----------------------- Métodos ----------------------------
        /*Metodo de insertar un nuevo nodo (inserción).
         * Cuando no existe raíz en el árbol
         */
        public void insert(T value)
        {

            Nodo<T> newNode = new Nodo<T>(value);

            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                tiempoOrdenamientoAvl.Start();
                this.root = this.insertNode(this.root, newNode);
                tiempoOrdenamientoAvl.Stop();
                x += tiempoOrdenamientoAvl.Elapsed.TotalMilliseconds;
            }

        }

        public Nodo<T> insertNode(Nodo<T> actualroot, Nodo<T> newNode) //Metodo para insertar un nodo sino 
        {
            if (actualroot != null)//recorrer las hojas o hijos
            {
                if (comparar(newNode.value, actualroot.value) < 0)//Cuando es menor
                {
                    actualroot.left = this.insertNode(actualroot.left, newNode);//se manda a la nodo izquierdo
                    //Factor de balanceo
                    if (this.node_Height(actualroot.right) - this.node_Height(actualroot.left) == -2)
                    {
                        //Entra a rotacion simple derecha
                        if (comparar(newNode.value, actualroot.left.value) < 0)
                        {
                            //Si L-L Rotación simple derecha
                            actualroot = this.right_Rotation(actualroot);
                        }
                        else //rotacion left-right
                        {
                            actualroot = this.left_Right_Rotation(actualroot);
                        }
                    }
                }
                else if (comparar(newNode.value, actualroot.value) > 0) //cuando es mayor
                {
                    actualroot.right = this.insertNode(actualroot.right, newNode);//se manda a la nodo derecho
                    if (this.node_Height(actualroot.right) - this.node_Height(actualroot.left) == 2) //validaciones de balanceo
                    {
                        //Entra a rotacion izquierda
                        if (comparar(newNode.value, actualroot.right.value) > 0)
                        {
                            //Entra a rotacion izquerda 
                            actualroot = this.left_Rotation(actualroot);
                        }
                        else //rotacion right - left
                        {
                            actualroot = this.right_Left_Rotation(actualroot);
                        }
                    }
                }
                else { }
                actualroot.height = this.max_Height(this.node_Height(actualroot.right), this.node_Height(actualroot.left)) + 1;
                return actualroot;
            }
            else
            {
                actualroot = newNode;
                return actualroot;
            }

        }

        //Para retornar la altura de los nodos
        public int node_Height(Nodo<T> node)
        {
            if (node != null)
            {
                return node.height;
            }
            else
            {
                return -1;
            }
        }
        //Para comparar dos alturas y retorna la mayor
        public int max_Height(int height1, int height2)
        {
            if (height2 >= height1)
            {
                return height2;
            }
            else
            {
                return height1;
            }
        }

        //Rotaciones
        public Nodo<T> right_Rotation(Nodo<T> node) //rotacion simple izquierda
        {
            Nodo<T> aux_Node = node.left;
            node.left = aux_Node.right;
            aux_Node.right = node;
            node.height = this.max_Height(this.node_Height(node.right), this.node_Height(node.left)) + 1;
            aux_Node.height = this.max_Height(node.height, this.node_Height(node.left)) + 1;
            ContadorRotaciones++;
            return aux_Node;
        }
        public Nodo<T> left_Rotation(Nodo<T> node) //rotacion simple derecha
        {
            Nodo<T> aux_Node = node.right;
            node.right = aux_Node.left;
            aux_Node.left = node;
            node.height = this.max_Height(this.node_Height(node.left), this.node_Height(node.right)) + 1;
            aux_Node.height = this.max_Height(node.height, this.node_Height(node.right)) + 1;
            ContadorRotaciones++;
            return aux_Node;
        }
        public Nodo<T> left_Right_Rotation(Nodo<T> node) //rotacion izquierda - derecha
        {
            node.left = this.left_Rotation(node.left);
            Nodo<T> aux_Node = this.right_Rotation(node);
            return aux_Node;
        }
        public Nodo<T> right_Left_Rotation(Nodo<T> node) //rotacion derecha - izquierda
        {
            node.right = this.right_Rotation(node.right);
            Nodo<T> aux_Node = this.left_Rotation(node);
            return aux_Node;
        }

        public T Buscar(T valor)
        {
            return Buscar(valor, root);
        }

        private T Buscar(T elemento, Nodo<T> raiz)
        {
            Nodo<T> aux_Node = raiz;

            if (aux_Node == null)
            {
                ComparacionesBusqueda++;
                return default(T);
            }
            else if (comparar(elemento, aux_Node.value) == 0)
            {
                ComparacionesBusqueda++;
                return aux_Node.value;
            }
            else if (comparar(elemento, aux_Node.value) < 0)
            {
                ComparacionesBusqueda++;
                return Buscar(elemento, aux_Node.left);
            }
            else
            {
                ComparacionesBusqueda++;
                return Buscar(elemento, aux_Node.right);
            }
        }

        private void InOrder(Nodo<T> padre, ref ColaRecorrido<T> queue)
        {

            if (padre != null)
            {
                InOrder(padre.left, ref queue);
                queue.Encolar(padre.value);
                InOrder(padre.right, ref queue);
            }
            return;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new ColaRecorrido<T>();
            InOrder(root, ref queue);

            while (!queue.ColaVacia())
            {
                yield return queue.DesEncolar();
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Rotaciones()
        {
            return ContadorRotaciones;
        }

        public int Profundidad()
        {
            return this.root.height;
        }

        public int Comparaciones()
        {
            return ComparacionesBusqueda;
        }

        public double TiempoDeOrdenamientoAvl()
        {

            return x;
        }
    }
}

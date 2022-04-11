using Lab03_ED_2022.Comparison;
using Lab03_ED_2022.Estructura_de_Datos;
using System.Collections;
using System.Collections.Generic;

namespace Lab03_ED_2022.Estructuras_de_datos
{
    public class Árbol<T> : IEnumerable<T>, IEnumerable  // interfaz
    {
        public Compare<T> Comparar { get; set; }
        public VerificarFecha<T> VerFecha { get; set; }

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
        public void Insert(T value)
        {

            Nodo<T> newNode = new Nodo<T>(value);

            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                this.root = this.InsertNode(this.root, newNode);
            }

        }

        public Nodo<T> InsertNode(Nodo<T> actualroot, Nodo<T> newNode) //Metodo para insertar un nodo sino 
        {
            if (actualroot != null)//recorrer las hojas o hijos
            {
                if (Comparar(newNode.value, actualroot.value) < 0)//Cuando es menor
                {
                    actualroot.left = this.InsertNode(actualroot.left, newNode);//se manda a la nodo izquierdo
                    //Factor de balanceo
                    if (this.Node_Height(actualroot.right) - this.Node_Height(actualroot.left) == -2)
                    {
                        //Entra a rotacion simple derecha
                        if (Comparar(newNode.value, actualroot.left.value) < 0)
                        {
                            //Si L-L Rotación simple derecha
                            actualroot = this.Right_Rotation(actualroot);
                        }
                        else //rotacion left-right
                        {
                            actualroot = this.Left_Right_Rotation(actualroot);
                        }
                    }
                }
                else if (Comparar(newNode.value, actualroot.value) > 0) //cuando es mayor
                {
                    actualroot.right = this.InsertNode(actualroot.right, newNode);//se manda a la nodo derecho
                    if (this.Node_Height(actualroot.right) - this.Node_Height(actualroot.left) == 2) //validaciones de balanceo
                    {
                        //Entra a rotacion izquierda
                        if (Comparar(newNode.value, actualroot.right.value) > 0)
                        {
                            //Entra a rotacion izquerda 
                            actualroot = this.Left_Rotation(actualroot);
                        }
                        else //rotacion right - left
                        {
                            actualroot = this.Right_Left_Rotation(actualroot);
                        }
                    }
                }
                else { }
                actualroot.height = this.Max_Height(this.Node_Height(actualroot.right), this.Node_Height(actualroot.left)) + 1;
                return actualroot;
            }
            else
            {
                actualroot = newNode;
                return actualroot;
            }

        }

        //Para retornar la altura de los nodos
        public int Node_Height(Nodo<T> node)
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
        public int Max_Height(int height1, int height2)
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
        public Nodo<T> Right_Rotation(Nodo<T> node) //rotacion simple izquierda
        {
            Nodo<T> aux_Node = node.left;
            node.left = aux_Node.right;
            aux_Node.right = node;
            node.height = this.Max_Height(this.Node_Height(node.right), this.Node_Height(node.left)) + 1;
            aux_Node.height = this.Max_Height(node.height, this.Node_Height(node.left)) + 1;
            return aux_Node;
        }
        public Nodo<T> Left_Rotation(Nodo<T> node) //rotacion simple derecha
        {
            Nodo<T> aux_Node = node.right;
            node.right = aux_Node.left;
            aux_Node.left = node;
            node.height = this.Max_Height(this.Node_Height(node.left), this.Node_Height(node.right)) + 1;
            aux_Node.height = this.Max_Height(node.height, this.Node_Height(node.right)) + 1;
            return aux_Node;
        }
        public Nodo<T> Left_Right_Rotation(Nodo<T> node) //rotacion izquierda - derecha
        {
            node.left = this.Left_Rotation(node.left);
            Nodo<T> aux_Node = this.Right_Rotation(node);
            return aux_Node;
        }
        public Nodo<T> Right_Left_Rotation(Nodo<T> node) //rotacion derecha - izquierda
        {
            node.right = this.Right_Rotation(node.right);
            Nodo<T> aux_Node = this.Left_Rotation(node);
            return aux_Node;
        }
        private T Buscar(T elemento, Nodo<T> raiz)
        {
            Nodo<T> aux_Node = raiz;

            if (aux_Node == null)
            {

                return default(T);
            }
            else if (Comparar(elemento, aux_Node.value) == 0)
            {

                return aux_Node.value;
            }
            else if (Comparar(elemento, aux_Node.value) < 0)
            {

                return Buscar(elemento, aux_Node.left);
            }
            else
            {
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

    }
}
//fin 

using Lab03_ED_2022.Delegados;
using Lab03_ED_2022.Estructura_de_Datos;
using System.Collections;
using System.Collections.Generic;

namespace Lab03_ED_2022.Estructuras_de_datos
{
    public class Árbol<T> : IEnumerable<T>, IEnumerable  // interfaz
    {
        public Compare<T> Comparar { get; set; }
        public Compare<T> CompararNombres { get; set; }
        public Compare<T> CompararId { get; set; }

        public Compare<T> CompararFechaBuscar { get; set; }
        public VerificarFecha<T> CompararFecha { get; set; }
        public VerificarFecha<T> VerFecha { get; set; }

        //Varible
        Nodo<T> root;


        public bool VerificarProxFecha(T valor)
        {
            if (CompararFecha(valor) == 1)
            {
                return false;

            }

            return true;
        }

        //Contructor de mi clase
        public Árbol()
        {
            this.root = null;
        }

        //----------------------- Métodos ----------------------------
        /*Metodo de insertar un nuevo nodo (inserción).
         * Cuando no existe raíz en el árbol
         */
        public bool Insert(T value)
        {

            Nodo<T> newNode = new Nodo<T>(value);

            if (this.root == null)
            {
                this.root = newNode;
                return true;
            }
            else
            {
                //verificar la fecha de la raíz para ver que no hallan más de 8 
                if (Comparar(root.value, newNode.value) == 0)
                {
                    if (root.totalConsultas < 8)
                    {
                        root.totalConsultas++;
                        return true;
                    }
                    else
                    {
                        //si hay más de 8 citas agendadas en la raiz entonces pedir cambio 
                        return false;
                    }
                }
               
                
                if ((this.root = this.InsertNode(this.root, newNode)) == default)
                {
                    return false;
                }

                return true;
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
                else //cuando son iguales las fechas, sumar 1 al contador si es mayor a 8 error  
                {
                    if (actualroot.totalConsultas <= 8)
                    {
                        actualroot.totalConsultas++;
                        return actualroot;
                    }
                    else
                    {
                        return default;
                    }

                }
                actualroot.height = this.Max_Height(this.Node_Height(actualroot.right), this.Node_Height(actualroot.left)) + 1;
                return actualroot;
            }
            else
            {
                actualroot = newNode;
                return actualroot;
            }
        }

        public bool ReturnFalse()
        {
            return false;
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
        public T Buscar(T valor)
        {
            return Buscar(valor, root);
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

        public T BuscarNombre(T elemento)
        {
            return BuscarNombre(elemento, this.root);
        }

        private T BuscarNombre(T elemento, Nodo<T> padre)
        {
            Nodo<T> auxiliar = padre;
            if (padre != null)
            {
                T hijoIzq = BuscarNombre(elemento, auxiliar.left);
                
                if (hijoIzq != null)
                {
                    return hijoIzq;
                }
                
                if (CompararNombres(elemento, auxiliar.value)==0)
                {
                    return auxiliar.value;
                }
                T hijoDer = BuscarNombre(elemento, auxiliar.right);
                
                if (hijoDer != null)
                {
                    return hijoDer;
                }
            }
            return default(T);
        }
        public T BuscarDpi(T elemento)
        {
            return BuscarDpi(elemento, this.root);
        }

        private T BuscarDpi(T elemento, Nodo<T> padre)
        {
            Nodo<T> auxiliar = padre;
            if (padre != null)
            {
                T hijoIzq = BuscarDpi(elemento, auxiliar.left);

                if (hijoIzq != null)
                {
                    return hijoIzq;
                }

                if (CompararId(elemento, auxiliar.value) == 0)
                {
                    return auxiliar.value;
                }
                T hijoDer = BuscarDpi(elemento, auxiliar.right);

                if (hijoDer != null)
                {
                    return hijoDer;
                }
            }
            return default(T);
        }

        public Nodo<T> BuscarFecha(T valor)
        {
            return BuscarFecha(valor, root);
        }
        private Nodo<T> BuscarFecha(T elemento, Nodo<T> padre)
        {
            Nodo<T> auxiliar = padre;
            if (padre != null)
            {
                Nodo<T> hijoIzq = BuscarFecha(elemento, auxiliar.left);

                if (hijoIzq != null)
                {
                    return hijoIzq;
                }

                if (CompararFechaBuscar(elemento, auxiliar.value) == 0)
                {
                    return auxiliar;
                }
                Nodo<T> hijoDer = BuscarFecha(elemento, auxiliar.right);

                if (hijoDer != null)
                {
                    return hijoDer;
                }
            }
            return default(Nodo<T> );
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria
{
    public class ArbolMascotas
    {
        private Nodo raiz;

        // Constructor
        public ArbolMascotas()
        {
            raiz = null;
        }

        // Método para insertar una mascota en el árbol
        public void Insertar(Mascota mascota)
        {
            raiz = InsertarRec(raiz, mascota);
        }

        private Nodo InsertarRec(Nodo nodo, Mascota mascota)
        {
            if (nodo == null)
            {
                return new Nodo(mascota);
            }

            if (mascota.CodigoMascota < nodo.Dato.CodigoMascota)
            {
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, mascota);
            }
            else if (mascota.CodigoMascota > nodo.Dato.CodigoMascota)
            {
                nodo.Derecho = InsertarRec(nodo.Derecho, mascota);
            }

            return nodo;
        }

        // Método para buscar una mascota por código
        public Mascota Buscar(int codigoMascota)
        {
            Nodo nodo = BuscarRec(raiz, codigoMascota);
            return nodo?.Dato;
        }

        private Nodo BuscarRec(Nodo nodo, int codigoMascota)
        {
            if (nodo == null || nodo.Dato.CodigoMascota == codigoMascota)
            {
                return nodo;
            }

            if (codigoMascota < nodo.Dato.CodigoMascota)
            {
                return BuscarRec(nodo.Izquierdo, codigoMascota);
            }

            return BuscarRec(nodo.Derecho, codigoMascota);
        }

        // Método para eliminar una mascota
        public void Eliminar(int codigoMascota)
        {
            raiz = EliminarRec(raiz, codigoMascota);
        }

        private Nodo EliminarRec(Nodo nodo, int codigoMascota)
        {
            if (nodo == null)
            {
                return null;
            }

            if (codigoMascota < nodo.Dato.CodigoMascota)
            {
                nodo.Izquierdo = EliminarRec(nodo.Izquierdo, codigoMascota);
            }
            else if (codigoMascota > nodo.Dato.CodigoMascota)
            {
                nodo.Derecho = EliminarRec(nodo.Derecho, codigoMascota);
            }
            else
            {
                // Nodo con un solo hijo o sin hijos
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                // Nodo con dos hijos
                nodo.Dato = MinValor(nodo.Derecho);
                nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Dato.CodigoMascota);
            }

            return nodo;
        }

        private Mascota MinValor(Nodo nodo)
        {
            Mascota minv = nodo.Dato;
            while (nodo.Izquierdo != null)
            {
                minv = nodo.Izquierdo.Dato;
                nodo = nodo.Izquierdo;
            }
            return minv;
        }

        // Recorrido InOrder
        public void InOrder()
        {
            InOrderRec(raiz);
        }

        private void InOrderRec(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrderRec(nodo.Izquierdo);
                Console.WriteLine(nodo.Dato);
                InOrderRec(nodo.Derecho);
            }
        }

        // Obtener altura del árbol
        public int ObtenerAltura()
        {
            return AlturaRec(raiz);
        }

        private int AlturaRec(Nodo nodo)
        {
            if (nodo == null)
            {
                return 0;
            }

            int alturaIzq = AlturaRec(nodo.Izquierdo);
            int alturaDer = AlturaRec(nodo.Derecho);

            return Math.Max(alturaIzq, alturaDer) + 1;
        }

        // Estadísticas de mascotas
        public (int machos, int hembras) ContarPorSexo()
        {
            int machos = 0, hembras = 0;
            ContarPorSexoRec(raiz, ref machos, ref hembras);
            return (machos, hembras);
        }

        private void ContarPorSexoRec(Nodo nodo, ref int machos, ref int hembras)
        {
            if (nodo != null)
            {
                if (nodo.Dato.Sexo.ToUpper() == "MACHO")
                    machos++;
                else
                    hembras++;

                ContarPorSexoRec(nodo.Izquierdo, ref machos, ref hembras);
                ContarPorSexoRec(nodo.Derecho, ref machos, ref hembras);
            }
        }

        // Contar mascotas entre 5 y 10 años
        public int ContarMascotasEnRangoEdad()
        {
            return ContarMascotasEnRangoEdadRec(raiz);
        }

        private int ContarMascotasEnRangoEdadRec(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            int count = 0;
            if (nodo.Dato.Edad >= 5 && nodo.Dato.Edad <= 10)
                count = 1;

            return count + ContarMascotasEnRangoEdadRec(nodo.Izquierdo) +
                          ContarMascotasEnRangoEdadRec(nodo.Derecho);
        }

        // Mostrar mascotas de raza Cooker
        public void MostrarMascotasCooker()
        {
            Console.WriteLine("\nMascotas de raza COOKER:");
            MostrarMascotasCookerRec(raiz);
        }

        private void MostrarMascotasCookerRec(Nodo nodo)
        {
            if (nodo != null)
            {
                MostrarMascotasCookerRec(nodo.Izquierdo);
                if (nodo.Dato.Raza.ToUpper() == "COOKER")
                {
                    Console.WriteLine(nodo.Dato);
                }
                MostrarMascotasCookerRec(nodo.Derecho);
            }
        }
    }
}

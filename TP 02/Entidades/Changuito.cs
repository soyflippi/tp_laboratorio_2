﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region "Atributos"
        List<Producto> _productos;
        int _espacioDisponible;

        /// <summary>
        /// Enumeración de tipos de productos, incluido un tipo que engloba a TODOS
        /// </summary>
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor sin parámetros, inicializa la lista de productos
        /// </summary>
        public Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor con seteo de espacio máximo disponible
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible) :this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="tipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Dulce:
                        if (v.GetType() == typeof(Dulce))
                            sb.AppendLine(v.Mostrar());
                        break;

                    case ETipo.Leche:
                        if (v.GetType() == typeof(Leche))
                            sb.AppendLine(v.Mostrar());
                        break;
                   
                    case ETipo.Snacks:
                        if(v.GetType() == typeof(Snacks))
                            sb.AppendLine(v.Mostrar());
                        break;

                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "SobreCarga de Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                    return c;
            }

            if (c._espacioDisponible > c._productos.Count())
                c._productos.Add(p);

            return c;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    c._productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
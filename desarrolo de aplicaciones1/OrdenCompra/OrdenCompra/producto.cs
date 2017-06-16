using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrdenCompra
{
    class producto
         
    {
        public string servidorSQL { set; get; }
        public string BD { set; get; }


        public void insertar_producto(ref string mensaje, int claveProducto, string nombreP, double precioP)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            try
            {
                carretera.Open();
                carrito.CommandText = "insert into producto(idProducto,descripcion,precio) values('" + claveProducto + "','" + nombreP + "','" + precioP + "' )";
                carrito.Connection = carretera;
                carrito.ExecuteNonQuery();
                MessageBox.Show("producto Dado de alta");
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                mensaje="ERROR"+m.Message;

            }

        }



        public void consultaProducto(ref string mensaje, ListBox listBox2Producto)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            SqlDataReader contenedor;

            try
            {
                carretera.Open();
                carrito.CommandText = "Select * from producto";
                carrito.Connection = carretera;
                contenedor = carrito.ExecuteReader();
                while (contenedor.Read())
                {
                    listBox2Producto.Items.Add(contenedor[0].ToString() + " , " + contenedor[1].ToString() + "," + contenedor[2].ToString() + ",");
                }
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                mensaje ="ERROR"+ m.Message;

            }
        }


       
        

    }
}

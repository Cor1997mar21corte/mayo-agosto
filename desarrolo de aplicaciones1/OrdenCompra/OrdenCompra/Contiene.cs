using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrdenCompra
{
    class Contiene
    {
        public string servidorSQL { set; get; }
        public string BD { set; get; }


        public void insertarContiene(ref string mensaje, int varidOrden, int varidProducto, int varcantidad, float vartotal)
        {


            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            try
            {
                carretera.Open();
                carrito.CommandText = carrito.CommandText = "insert into contiene(idOrden,idProducto,cantidad,total) values('" + varidOrden + "','" + varidProducto + "','" + varcantidad + "','" + vartotal + "'))";
                carrito.Connection = carretera;
                carrito.ExecuteNonQuery();
                MessageBox.Show("Orden dada de alta");
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                MessageBox.Show("ERROR"+m.Message );

            }

        }


        public void consultaContiene(ref string mensaje, ListBox listBox3Orden)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            SqlDataReader contenedor;

            try
            {
                carretera.Open();
                carrito.CommandText = "Select * from contiene";
                carrito.Connection = carretera;
                contenedor = carrito.ExecuteReader();
                while (contenedor.Read())
                {
                    listBox3Orden.Items.Add(contenedor[0].ToString() + " , " + contenedor[1].ToString() + "," + contenedor[2].ToString() + "," + contenedor[3].ToString() + ",");
                }
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                MessageBox.Show("ERROR");

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrdenCompra
{
    class Orden
    {
        public string servidorSQL { set; get; }
        public string BD { set; get; }




        public void altaOrden(ref string mensaje,string fechaEmision, string fechaEntrega, int idcliente)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            try
            {
                carretera.Open();
                carrito.CommandText = "insert into ordenCompra2(fechaEmision, fechaEntrega,idCliente) values('" + fechaEmision + "','" + fechaEntrega +"' '"+idcliente+"')";
                carrito.Connection = carretera;
                carrito.ExecuteNonQuery();
                MessageBox.Show("Orden de compra dada de alta");
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                mensaje="ERROR"+m.Message;

            }
        }



        public void consultaOrden(ref string mensaje, ListBox listBox3Orden)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            SqlDataReader contenedor;

            try
            {
                carretera.Open();
                carrito.CommandText = "Select * from ordenCompra2";
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
                mensaje="ERROR"+m.Message;

            }
        }

        public void agregarComboboxidCliente(ref string mensaje, ComboBox comboBox1Orden)
        {
            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            SqlDataReader contenedor;

            try
            {
                carretera.Open();
                carrito.CommandText = "select idCliente from Cliente ";
                carrito.Connection = carretera;
                contenedor = carrito.ExecuteReader();
                while (contenedor.Read())
                {
                    comboBox1Orden.Items.Add(contenedor[0].ToString());
                }
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                mensaje="ERROR"+m.Message;

            }
        }



        public void precio()
        {



        }




    }

}

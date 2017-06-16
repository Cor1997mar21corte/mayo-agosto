using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrdenCompra
{
    class productos
    {

     
        public string servidorSQL { set; get; }
        public string BD { set; get; }



        public void AltaCLiente(ref string mensaje, string nombre, string direccion, string cp)
        {


            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            try
            {
                carretera.Open();
                carrito.CommandText="insert into Cliente(nombre,direccion,cp)values('"+ nombre +"','"+ direccion +"','" + cp +"' )";
                carrito.Connection = carretera;
                carrito.ExecuteNonQuery();
                MessageBox.Show("cliente Dado de alta");
                carretera.Close();
            }

            catch (Exception m)
            {
                carretera = null;
                MessageBox.Show("ERROR");

            }


        }



        public void consulta_cliente(ref string mensaje, ListBox lista1)
        {


            SqlConnection carretera = new SqlConnection();
            carretera.ConnectionString = "data source=" + servidorSQL + ";Initial Catalog=" + BD + ";Integrated Security=true";
            SqlCommand carrito = new SqlCommand();
            SqlDataReader contenedor;

            try
            {
                carretera.Open();
                carrito.CommandText = "Select * from Cliente";
                carrito.Connection = carretera;
                contenedor = carrito.ExecuteReader();
                while (contenedor.Read())
                {
                    lista1.Items.Add(contenedor[0].ToString() + " , " + contenedor[1].ToString() + "," + contenedor[2].ToString() + "," + contenedor[3].ToString() + ",");
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
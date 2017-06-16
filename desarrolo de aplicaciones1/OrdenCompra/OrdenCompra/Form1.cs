using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenCompra
{
    public partial class Form1 : Form
    {
        productos x = new productos();
        Orden m = new Orden();
        producto pr = new producto();
        Contiene l = new Contiene();
        string mensaje = " ";
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            m.consultaOrden(ref mensaje, listBox3Orden);
            txtmensaje.Text=mensaje;
        }

        private void btnalt_Click(object sender, EventArgs e)
        {
           
           
            x.AltaCLiente(ref mensaje, txtNom.Text, txtDir.Text, txtCp.Text);
            txtmensaje.Text = mensaje;
            m.agregarComboboxidCliente(ref mensaje, comboBox1orden);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void altasOrden_Click(object sender, EventArgs e)
        {

            if (txtfechEmi.Text == " " && textBoxEntre.Text == " " && comboBox1orden.Text == "")
            {
                mensaje = "Controles vacios";
            }
            else
                m.altaOrden(ref mensaje, txtfechEmi.Text, textBoxEntre.Text, Convert.ToInt32(comboBox1orden.Text));


            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x.BD = "OrdenCompra";
            x.servidorSQL = @"PC20\MSSQLSERVER2016";
            m.BD = "OrdenCompra";
            m.servidorSQL=@"PC20\MSSQLSERVER2016";
            pr.BD = "OrdenCompra";
            pr.servidorSQL =  @"PC20\MSSQLSERVER2016";
            l.BD = "OrdenCompra";
            l.servidorSQL = @"PC20\MSSQLSERVER2016";




           
            
        }

        private void btnConsG_Click(object sender, EventArgs e)
        {
           
            x.consulta_cliente(ref mensaje, lista1);
            txtmensaje.Text = mensaje;
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConPro_Click(object sender, EventArgs e)
        {
          
            pr.consultaProducto(ref mensaje,listBox2Producto);
            txtmensaje.Text=mensaje;
        }

        private void btnAltasProd_Click(object sender, EventArgs e)
        {
           
            pr.insertar_producto(ref mensaje, Convert.ToInt32(textBox5idPro.Text), textBox6nPro.Text, Convert.ToDouble(textBox7nPre.Text));
            txtmensaje.Text = mensaje;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnconsultaContiene_Click(object sender, EventArgs e)
        {
            
            l.consultaContiene(ref mensaje, listBox3Orden);
            txtmensaje.Text = mensaje;
        }

        private void btnInsertarcontiene_Click(object sender, EventArgs e)
        {

            if (comboBox2ClaveProducto.Text == " " && comboBox2ClaveProducto.Text == " " && textBoxCantidad.Text == " " && textBox8total.Text=="")
          {
              mensaje = "Controles vacios";

          }

            else
            {
               
                l.insertarContiene(ref mensaje, Convert.ToInt32(comboBox2ClaveProducto.Text), Convert.ToInt32(comboBox2ClaveProducto.Text), Convert.ToInt32(textBoxCantidad.Text), Convert.ToSingle(textBox8total.Text));

            }
        }

        private void comBoxCla_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1orden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

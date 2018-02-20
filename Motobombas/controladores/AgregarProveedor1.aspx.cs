using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_AgregarProveedor1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void B_agregar_Click(object sender, EventArgs e)
    {

        E_proveedor nuevo = new E_proveedor();
        Dao_proveedor proveedor  = new Dao_proveedor();
        ClientScriptManager cm = this.ClientScript;
      
            if (Double.Parse(TB_telefono.Text) <= 99999999999)
            {
        nuevo.Nombre = TB_nombre.Text;
        nuevo.Telefono = Double.Parse(TB_telefono.Text);
        nuevo.Correo = TB_correo.Text;
        
        proveedor.insertarproveedor(nuevo);

        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Agregado correctamente');window.location=\"AgregarProveedor1.aspx\"</script>");

            }else {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Telefono muy extenso');</script>");
                

        }
            
        }

        
        
        
    
    protected void B_ver_proveedores_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModificarProveedor.aspx");
    }
}
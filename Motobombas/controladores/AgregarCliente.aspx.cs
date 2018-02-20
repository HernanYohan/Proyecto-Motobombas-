using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void TB_nombrecliente_TextChanged(object sender, EventArgs e)
    {

    }
    protected void B_agregarcliente_Click(object sender, EventArgs e)
    {
        E_Cliente nuevo = new E_Cliente();
        Dao_Cliente cliente = new Dao_Cliente();
        ClientScriptManager cm = this.ClientScript;
      
        if (Double.Parse(TB_telefonocliente.Text) <= 99999999999)
        {
            nuevo.Nombre = TB_nombrecliente.Text;
            nuevo.Apellido = TB_apellidocliente.Text;
            nuevo.Telefono = Double.Parse(TB_telefonocliente.Text);
            nuevo.Direccion = TB_direccioncliente.Text;
            nuevo.Correo = TB_correocliente.Text;
            nuevo.Usuario = TB_usuario.Text;
            nuevo.Clave = TB_clave.Text;
            nuevo.Id_rol = Int32.Parse(DDL_rol.SelectedValue);
            cliente.insertarCliente(nuevo);

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Agregado correctamente');window.location=\"AgregarCliente.aspx\"</script>");

        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Telefono muy extenso');</script>");
                
        }
    }
    protected void TB_telefonocliente_TextChanged(object sender, EventArgs e)
    {

    }
    protected void B_ver_cliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModificarCliente.aspx");
    }
    protected void DDL_rol_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
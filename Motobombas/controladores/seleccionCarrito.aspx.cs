using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_seleccionCarrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void GV_Verproducto_SelectedIndexChanged(object sender, EventArgs e)
    {

    
    }
    protected void B_continuar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Catalogo_Cliente.aspx");
    }
    protected void TB_cantidad_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Verproducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "B_agregarp")
        {

            int index;

            index = int.Parse(e.CommandArgument.ToString());
            ClientScriptManager cm = this.ClientScript;
            if (Int32.Parse(TB_cantidad.Text) <= index)
            {

                E_venta nuevo = new E_venta();
                Dao_carrito agregar = new Dao_carrito();
                
                nuevo.Cantidad = Int32.Parse(TB_cantidad.Text);
                nuevo.Id_estado = 2;
                nuevo.Id_cliente = Int32.Parse(Session["id_usuaro"].ToString());
                nuevo.Id_producto = Int32.Parse(Session["id_producto"].ToString());
                agregar.agregarCarrito(nuevo);

                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Producto agregado corectamente');window.location=\"seleccionCarrito.aspx\"</script>");
            }
            else
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No contamos con la cantidad solicitada. ');window.location=\"Catalogo_Cliente.aspx\"</script>");
            }
        }
    }
    protected void B_agregarp_Click(object sender, EventArgs e)
    {

    }
}
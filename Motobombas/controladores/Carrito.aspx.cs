using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_Carrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void GV_venta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "B_eliminar")
        {

            int index;
            Dao_carrito nuevo = new Dao_carrito();

            index = int.Parse(e.CommandArgument.ToString());
            Session["id_venta"] = index;
            nuevo.eliminarPedido(index);


            Response.Redirect("Carrito.aspx");

        }
    }
    protected void B_comprar_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("Rortes_Total.aspx");
    }
    protected void B_eliminar_Click(object sender, EventArgs e)
    {

    }
}
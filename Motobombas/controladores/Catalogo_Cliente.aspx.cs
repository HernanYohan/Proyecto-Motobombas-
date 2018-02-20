using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_Catalogo_Cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void DDL_filtro_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void GV_Catalogo_Cliente_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "IB_producto")
        {

            int index;
            

            index = int.Parse(e.CommandArgument.ToString());
            Session["id_producto"] = index;
            Response.Redirect("seleccionCarrito.aspx");

        }
    }
    protected void GV_Catalogo_Cliente_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
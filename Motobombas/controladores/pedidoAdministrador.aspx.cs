using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_pedidoAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id_categoria"] != null && !IsPostBack)
        {
            DDL_producto.SelectedValue = Session["id_categoria"].ToString();
        }

        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");
      
       
        Response.Cache.SetNoStore();
    }
   

    protected void B_historial_Click(object sender, EventArgs e)
    {
        Response.Redirect("HistorialPedidoAdministrador.aspx");
        
    }
    protected void DDL_proveedor_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void B_buscar_Click(object sender, EventArgs e)
    {
        

        Session["referencia"] = DDL_referencia.SelectedValue;
        L_cantidad.Visible = true;
        TB_cantidad.Visible = true;
        


        
      
    }
    protected void GV_selec_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void seleccion_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void DDL_producto_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["id_categoria"] = Int32.Parse(DDL_producto.SelectedValue);
    }
    protected void B_pedido_Click(object sender, EventArgs e)
    {

    }

    protected void GV_selec_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "B_pedido")
        {

            int index;

            index = int.Parse(e.CommandArgument.ToString());
            ClientScriptManager cm = this.ClientScript;
            

                E_pedido nuevo = new E_pedido();
                Dao_pedido agregar = new Dao_pedido();

                nuevo.Producto = Int32.Parse(Session["id_categoria"].ToString());
                nuevo.Referencia = Session["referencia"].ToString();
                nuevo.Proveedor = index;
                nuevo.Cantidad = Int32.Parse(TB_cantidad.Text);
                agregar.insertarPedido(nuevo);

                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Pedido Realizado');window.location=\"pedidoAdministrador.aspx.aspx\"</script>");
            
        }
    }
    protected void referencia_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cliente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["estados"] != null && !IsPostBack)
        {
          DDL_catalogo.SelectedValue = Session["estados"].ToString();
        }

        if (Session["perfil"] != null && !IsPostBack)
        {
            DDL_perfilC.SelectedValue = Session["perfil"].ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Catalogo_Cliente.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int n = 0;

        do
        {

            Session["perfil"] = DDL_perfilC.SelectedValue;

            switch (int.Parse(DDL_perfilC.SelectedValue))
            {
                case 1:
                    Response.Redirect("editar_perfil.aspx");
                    break;
              
                case 2:
                    Session["user_id"] = null;
                    Session["nombre"] = null;

                   Dao_Usuario user = new Dao_Usuario();
                   E_Usuario datos = new E_Usuario();
                   datos.Session = Session.SessionID ;
                   user.cerrarSession(datos);

        
                    Response.Redirect("productos.aspx");
                    break;


            }

        } while (n < 0);
    }
    protected void B_productos_Click(object sender, EventArgs e)
    {

    }
    protected void DDL_catalogo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int n = 0;

        do
        {

            Session["estados"] = DDL_catalogo.SelectedValue;

            switch (int.Parse(DDL_catalogo.SelectedValue))
            {
                case 1:
                    Response.Redirect("Catalogo_Cliente.aspx");
                    break;
                case 2:

                    Response.Redirect("Bombas_Cliente.aspx");
                    break;
                case 3:
                    Response.Redirect("Tanques_Cliente.aspx");
                    break;
                case 4:
                    Response.Redirect("Accesorios_Cliente.aspx");
                    break;



            }

        } while (n < 0);
    }
    protected void B_ver_pedido_Click(object sender, EventArgs e)
    {

    }
    


    public ClientScriptManager ClientScript { get; set; }

    protected void B_pqr_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PQR_cliente.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Carrito.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HistorialCliente.aspx");
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_RecuperarContraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            Dao_Usuario user = new  Dao_Usuario();
            DataTable info = user.obtenerUsusarioToken(Request.QueryString[0]);

            if (int.Parse(info.Rows[0][0].ToString()) == -1)
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"login.aspx\"</script>");
            else if (int.Parse(info.Rows[0][0].ToString()) == -1)
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"login.aspx\"</script>");
            else
                Session["user_id"] = int.Parse(info.Rows[0][0].ToString());
        }

        else
            Response.Redirect("login.aspx");
    }
    protected void B_Cambiar_Click(object sender, EventArgs e)
    {
        Dao_Usuario user = new Dao_Usuario();
        E_Usuario eUser = new E_Usuario();

        eUser.User_id = int.Parse(Session["user_id"].ToString());
        eUser.Clave = Tb_Contraseña.Text;

        user.actualziarContrasena(eUser);
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Su Contraseña ha sido actualizada.');window.location=\"login.aspx\"</script>");
    }
}
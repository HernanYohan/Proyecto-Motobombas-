using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vista_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void B_iniciar_Click(object sender, EventArgs e)
    {



        Dao_Usuario guardarUsuario = new Dao_Usuario();
        DataTable data = guardarUsuario.loggin(TB_usuario.Text.ToString(), TB_clave.Text.ToString());
        ClientScriptManager cm = this.ClientScript;
        if (int.Parse(data.Rows[0]["id_cliente"].ToString()) > 0)
        {
            Session["id_usuaro"] = data.Rows[0]["id_cliente"].ToString();
            Session["id_rol"] = data.Rows[0]["id_rol"].ToString();
            Int32 rol = Int32.Parse(data.Rows[0]["id_rol"].ToString());
             E_Usuario datosUsuario = new E_Usuario();
            
            String ipAdress;
            String mac;

            ipAdress = HttpContext.Current.Request.UserHostAddress;
            mac = Utilidades.Mac.GetMAC(ref ipAdress);

            datosUsuario.Username = data.Rows[0]["id_cliente"].ToString();
            datosUsuario.Ip = ipAdress;
            datosUsuario.Mac =  mac;
            datosUsuario.Session = Session.SessionID;

            guardarUsuario.guardadoSession(datosUsuario);

            if (rol == 1)
            {
                Response.Redirect("ModificarProducto.aspx");
            }
            else
            {
                if (rol == 2)
                {
                    Response.Redirect("Catalogo_Cliente.aspx");
                }
                
                    
                
            }

        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Datos incorrectos');</script>");
            //Response.Redirect("loggin.aspx");
        }
    }
    protected void B_registrarse_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerarToken.aspx");
    }
}

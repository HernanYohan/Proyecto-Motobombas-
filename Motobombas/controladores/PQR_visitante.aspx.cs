using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_PQR_visitante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void B_pqr_visitante_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        E_PQR nuevo = new E_PQR();
        Dao_PQR pqr = new Dao_PQR();



        nuevo.Correo = TB_correo.Text;
        nuevo.Queja = TB_queja.Text;
        pqr.insertarpqr(nuevo);


      

        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('PQR recibido,en breve responderemos tu Pqr al correo ');window.location=\"PQR_visitante.aspx\"</script>");
    }
}
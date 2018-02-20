using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }


    protected void B_agregarproducto_Click(object sender, EventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;

        DataTable fotos;

        if (Session["fotos"] == null)
        {
            fotos = new DataTable();
            fotos.Columns.Add("ruta");
            fotos.Columns.Add("descripcion");
            Session["fotos"] = fotos;
        }

        fotos = (DataTable)Session["fotos"];

        string nombreArchivo = System.IO.Path.GetFileName(FU_imagen.PostedFile.FileName);
        string extencion = System.IO.Path.GetExtension(FU_imagen.PostedFile.FileName);
        

        String saveLocation = Server.MapPath("~\\imagenes") + "\\" + nombreArchivo;

        if (!(extencion.Equals(".jpg") || extencion.Equals(".gif") || extencion.Equals(".jpge") || extencion.Equals(".png")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
            return;
        }
        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
            return;
        }
        
        try
        {
            FU_imagen.PostedFile.SaveAs(saveLocation);

            E_Producto nuevo = new E_Producto();
            Dao_Motobombas producto = new Dao_Motobombas();

            nuevo.Url_imagen = ("~\\imagenes") + "\\" + nombreArchivo;
            nuevo.Marca = TB_marcaprod.Text;
            nuevo.Referencia = TB_potenciaprod.Text;
            nuevo.Valor = Int32.Parse(TB_valorprod.Text);
            nuevo.Cantidad = Int32.Parse(TB_cantidadprod.Text);
            nuevo.Id_categoria = Int32.Parse(DDL_categoria.SelectedValue);
            nuevo.Proveedor_producto = Int32.Parse(DDL_proveedor.SelectedValue);
            producto.insertarProducto(nuevo);

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Agregado correctamente');window.location=\"AgregarProducto.aspx\"</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error:Algunos datos incorrectos ');</script>");
            return;
        }


        


        
        
    }
    protected void B_ver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModificarProducto.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vistas_Rortes_Total : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");


        CRS_Total.ReportDocument.SetDataSource(llenarFactura());
        CRV_Total.ReportSource = CRS_Total;

        Response.Cache.SetNoStore();

    }

    protected Factura_total llenarFactura()
    {
        Factura_total factura = new Factura_total();
        Dao_carrito datos = new Dao_carrito();
        Int32 id = Int32.Parse(Session["id_usuaro"].ToString());

        DataTable datosFactura = datos.verEncabezado(id);
        DataTable datosFinal = factura.Factura;
        DataRow fila;


        for (int i = 0; i < datosFactura.Rows.Count; i++)
        {
            fila = datosFinal.NewRow();

           
            fila["Nombre"] = datosFactura.Rows[i]["Nombre"].ToString();
            fila["Apellido"] = datosFactura.Rows[i]["Apellido"].ToString();
            fila["Direccion"] = datosFactura.Rows[i]["Direccion"].ToString();
            fila["Fecha"] = datosFactura.Rows[i]["Fecha_pedido"].ToString();
            fila["Cantidad"] = int.Parse(datosFactura.Rows[i]["Cantidad"].ToString());
            fila["Valor"] = int.Parse(datosFactura.Rows[i]["Valor_c"].ToString());
            fila["Subtotal"] = int.Parse(datosFactura.Rows[i]["Subtotal"].ToString());
            fila["Iva"] = double.Parse(datosFactura.Rows[i]["Iva"].ToString());
            fila["Total"] = double.Parse(datosFactura.Rows[i]["Total"].ToString());
           





            datosFinal.Rows.Add(fila);
        }

        DataTable datosFac = datos.verFactura(id);
        DataTable datosFin = factura.Factura1;
        DataRow fil;

        for (int i = 0; i < datosFac.Rows.Count; i++)
        {
            fil = datosFin.NewRow();


            fil["Marca"] = datosFac.Rows[i]["Marca"].ToString();
            fil["Referencia"] = datosFac.Rows[i]["Referencia"].ToString();
            fil["Cantidad"] = int.Parse(datosFac.Rows[i]["Cantidad"].ToString());
            fil["Valor"] = int.Parse(datosFac.Rows[i]["Valor_c"].ToString());
            fil["Subtotal"] = int.Parse(datosFac.Rows[i]["Cantidad"].ToString());
            fil["Iva"] = double.Parse(datosFac.Rows[i]["Iva"].ToString());
            fil["Total"] = double.Parse(datosFac.Rows[i]["Total"].ToString());
          





            datosFin.Rows.Add(fil);
        }

        return factura;
    }
}
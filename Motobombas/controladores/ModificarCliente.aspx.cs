﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_usuaro"] == null)
            Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
    protected void GV_listaclientes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DDL_rol_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GV_listaclientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index = e.RowIndex;
        ClientScriptManager cm = this.ClientScript;

        DropDownList rol = GV_listaclientes.Rows[index].FindControl("DDL_rol") as DropDownList;

        if (rol.SupportsDisabledAttribute)
        {

            rol.Equals(rol.SelectedIndex);
            e.NewValues.Add("id_rol", (rol.SelectedIndex));
        }

    }
}
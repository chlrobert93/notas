private string sql;
    public CatCuen()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public void agregarCuenta()
    {

        sql = "insert into eC_Cuentas(ano,CUENTA,NOMBRE_DE_LA_CUENTA,NIVEL_DE_LA_CTA,TIPO_DE_CUENTA,NATURALEZA_DE_LA_CTA,CENTRO_DE_COSTOS,SALDO_INICIAL,RUBRO,ESTATUS,CLASIFICACION_DE_CUENTA,VALIDA_SUCURSAL,VALIDA_RFC,RFC,VALIDA_UUID,VALIDA_CTA_BANCA)values((select CAST(ano AS varchar)   from eC_Periodo where Ano_activo = 1 ),'" + cuenta + "','" + nombre_de_la_cuenta + "','" + Nivel + "','" + tipo_de_cuenta + "','" + naturaleza_de_la_cta + "','" + Centro_Costos + "','" + Saldo_Inicial + "','"+ClasificacionSAT+"','" + Estatus + "','" + Clasificacion + "','" + ValidaSucursal + "','" + RepetirRFC + "','" + RFC + "','" + ValidaUUID + "','" + ValidaCuentaBancaria + "')";
        
        retorno = ejecuta.insertUpdateDelete(sql);
    }
    
    
        CatCuen ins = new CatCuen();
        ins.ano = Convert.ToInt32(RadGrid1.SelectedValues["ano"]);
        cuentaActu = Convert.ToString(RadGrid1.SelectedValues["CUENTA"]);
        ins.nombreEdt = Convert.ToString(RadGrid1.SelectedValues["Nombre_de_la_cuenta"]);
      protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.VarChar).Value = tbedad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbdate.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");

        }
                readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
     protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");


        }

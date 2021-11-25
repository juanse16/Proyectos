using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Web.Clases;

namespace Web
{
    public partial class formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                mostrarClientes();
                cargarItemLista();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                clsClientes objClientes = new clsClientes();
                DataSet dsConsulta = objClientes.stconsultarClientes(Convert.ToInt64(txtID.Text));

                if (dsConsulta.Tables[0].Rows.Count == 0)
                {
                    datos.DataSource = null;
                }
                else
                {
                    datos.DataSource = dsConsulta;
                }
                datos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                clsClientes objClientes = new clsClientes();
                lblMensaje.Text = objClientes.stInsertarClientes(txtNombre.Text, txtApellido.Text);
                mostrarClientes();
                cargarItemLista();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                clsClientes objClientes = new clsClientes();
                lblMensaje.Text = objClientes.stModificarClientes(Convert.ToInt64(txtID.Text), txtNombre.Text, txtApellido.Text);
                mostrarClientes();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                clsClientes objClientes = new clsClientes();
                lblMensaje.Text = objClientes.stEliminarClientes(Convert.ToInt64(txtID.Text));
                mostrarClientes();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        public void cargarItemLista()
        {

            try
            {
                clsClientes objClientes = new clsClientes();
                DataSet dsConsulta = objClientes.mostrarClientes();

                if (dsConsulta.Tables[0].Rows.Count == 0)
                {
                    datos.DataSource = null;
                }
                else
                {
                    dlistap.DataSource = dsConsulta;
                    dlistap.DataTextField = "nombre";
                    dlistap.DataValueField = "id";
                    dlistap.DataBind();
                    dlistap.Items.Insert(0, new ListItem("--Seleccionar--"));

                }
                datos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        public void mostrarClientes()
        {
            try
            {
                clsClientes objClientes = new clsClientes();
                DataSet dsConsulta = objClientes.mostrarClientes();

                if (dsConsulta.Tables[0].Rows.Count == 0)
                {
                    datos.DataSource = null;
                }
                else
                {
                    datos.DataSource = dsConsulta;
                }
                datos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            mostrarClientes();
        }

        protected void datos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void datos_RowEditing(object sender, GridViewEditEventArgs e)
        {

            datos.EditIndex = e.NewEditIndex;
            mostrarClientes();

        }

        protected void datos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            datos.EditIndex = -1;
            mostrarClientes();

        }

        protected void datos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id =  datos.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                clsClientes objClientes = new clsClientes();
                lblMensaje.Text = objClientes.stEliminarClientes(Convert.ToInt64(id));
                mostrarClientes();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
            mostrarClientes();
        }

        protected void datos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = datos.DataKeys[e.RowIndex].Value.ToString();
            string nombre = (datos.Rows[e.RowIndex].FindControl("txtNombre") as TextBox).Text.Trim();
            string apellido = (datos.Rows[e.RowIndex].FindControl("txtApellido") as TextBox).Text.Trim();

            try
            {
                clsClientes objClientes = new clsClientes();
                lblMensaje.Text = objClientes.stModificarClientes(Convert.ToInt64(id), nombre, apellido);
                mostrarClientes();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
            datos.EditIndex = -1;
            mostrarClientes();

        }
    }
}
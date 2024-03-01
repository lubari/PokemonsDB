using dominio;
using negocio;
using System;
using System.Windows.Forms;


namespace Pokemons
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon newPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();  
            try
            {
                newPokemon.Numero = int.Parse(txtNumero.Text);
                newPokemon.Nombre = txtNombre.Text;
                newPokemon.Descripcion = txtDescripcion.Text;
                newPokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                newPokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                negocio.agregar(newPokemon);
                MessageBox.Show("Agregado existosamente");
                Close();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboDebilidad.DataSource = elementoNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}

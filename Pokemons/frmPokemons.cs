using System;
using System.Collections.Generic;
using System.Windows.Forms;
using negocio;
using dominio;

namespace Pokemons
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> pokemons;
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, System.EventArgs e)
        {   
            PokemonNegocio negocio = new PokemonNegocio();
            pokemons = negocio.Listar();
            dgvPokemons.DataSource = pokemons;
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            cargarImagen(pokemons[0].UrlImagen);
        }

        private void dgvPokemons_SelectionChanged(object sender, System.EventArgs e)
        {
            Pokemon pokemon = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

            cargarImagen(pokemon.UrlImagen);
        }

        public void cargarImagen(string imagen)
        {
            try{
                pbPokemon.Load(imagen);
            }
            catch (Exception e)
            {
                pbPokemon.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
        }
    }
}

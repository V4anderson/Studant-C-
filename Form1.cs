using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CrudSystem
{
    public partial class Form1 : Form
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=base;Uid=root;Pwd=;");

                strSQL = "INSERT INTO cad_clientes (nome, numero) values (@nome, @numero)";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@nome", tbNome.Text);

                comando.Parameters.AddWithValue("@numero", tbNumero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com Sucesso!");



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;

                comando = null;


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=base;Uid=root;Pwd=;");

                strSQL = "UPDATE cad_clientes set nome = @nome, numero = @numero where id = @id";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", tbID.Text);

                comando.Parameters.AddWithValue("@nome", tbNome.Text);

                comando.Parameters.AddWithValue("@numero", tbNumero.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Atualização realizada com Sucesso!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;

                comando = null;


            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=base;Uid=root;Pwd=;");

                strSQL = "DELETE from cad_clientes where id = @id";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", tbID.Text);

                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Apagado com Sucesso!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;

                comando = null;


            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=base;Uid=root;Pwd=;");

                strSQL = "SELECT * FROM cad_clientes where id = @id";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", tbID.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while(dr.Read())
                {
                    tbNome.Text = Convert.ToString(dr["nome"]);
                    tbNumero.Text = Convert.ToString(dr["numero"]);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;

                comando = null;


            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=base;Uid=root;Pwd=;");

                strSQL = "SELECT * FROM cad_clientes";

                da = new MySqlDataAdapter(strSQL, conexao);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();

                conexao = null;

                comando = null;


            }
        }
    }
}

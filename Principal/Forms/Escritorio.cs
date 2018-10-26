﻿using DevExpress.XtraEditors;
using Principal.Domain.Repositories;
using Principal.WinApp;
using Principal.Domain;
using Unity;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Principal.Forms
{

    public partial class Escritorio : XtraForm
    {
        private IEscritorioRepositorio _repositorioEscritorio;
        private IPessoaRepositorio _repositorioPessoa;
        private Domain.Entities.Escritorio _escritorio;
        private int pessoaId;
        private string pessoaNome;
        Validacoes validador = new Validacoes();

        public Escritorio()
        {
            InitializeComponent();
            _repositorioEscritorio = AppCore.Container.Resolve<IEscritorioRepositorio>();
            _repositorioPessoa = AppCore.Container.Resolve<IPessoaRepositorio>();
            this.Text = "Cadastro de Escritório";
            
            popularTela();
        }

        private void popularTela()
        {
            _escritorio = _repositorioEscritorio.ObterEscritorio();
            inputNome.Text = _escritorio.Nome;
            inputCNPJ.Text = _escritorio.CNPJ;
            inputCEP.Text = _escritorio.CEP;
            inputRua.Text = _escritorio.Rua;
            inputNumero.Text = _escritorio.Numero;
            inputBairro.Text = _escritorio.Bairro;
            inputCidade.Text = _escritorio.Cidade;
            inputUFEndereco.Text = _escritorio.UF;
            inputComplemento.Text = _escritorio.Complemento;
            inputLCP.Text = _escritorio.LCPNome;
        }

        private void botaoPesquisarCEP_Click(object sender, EventArgs e)
        {
            //consulta ws dos correios e preenche campos de endereco
            using (var ws = new br.com.correios.apps.AtendeClienteService())
            {
                try
                {
                    var resultado = ws.consultaCEP(inputCEP.Text);
                    this.inputRua.Text = resultado.end;
                    this.inputCidade.Text = resultado.cidade;
                    this.inputBairro.Text = resultado.bairro;
                    this.inputUFEndereco.Text = resultado.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção!",
                    MessageBoxButtons.OK);
                }
            }
        }

        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            int flag = 0;
            flag = validarEscritorio(flag);

            if(flag == 0)
            {
                try
                {
                    _escritorio.Nome = inputNome.Text;
                    _escritorio.CNPJ = inputCNPJ.Text;
                    _escritorio.CEP = inputCEP.Text;
                    _escritorio.Rua = inputRua.Text;
                    _escritorio.Numero = inputNumero.Text;
                    _escritorio.Bairro = inputBairro.Text;
                    _escritorio.Cidade = inputCidade.Text;
                    _escritorio.UF = inputUFEndereco.Text;
                    _escritorio.UFCompleto = obterUFCompleto(inputUFEndereco.Text);
                    _escritorio.Complemento = inputComplemento.Text;

                    //indica que houve alteracao de LCP
                    if (pessoaId > 0 && pessoaNome != null)
                    {
                        _escritorio.LCP = pessoaId;
                        _escritorio.LCPNome = inputLCP.Text;
                    }

                    _repositorioEscritorio.Atualizar(_escritorio);

                    MessageBox.Show("Registro gravado!\n", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao registrar escritório\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string obterUFCompleto(string text)
        {
            string UFCompleto = "";

            switch (text)
            {
                case "AC":
                    UFCompleto = "Acre";
                    break;
                case "AL":
                    UFCompleto = "Alagoas";
                    break;
                case "AP":
                    UFCompleto = "Amapá";
                    break;
                case "AM":
                    UFCompleto = "Amazonas";
                    break;
                case "BA":
                    UFCompleto = "Bahia";
                    break;
                case "CE":
                    UFCompleto = "Ceará";
                    break;
                case "DF":
                    UFCompleto = "Distrito Federal";
                    break;
                case "ES":
                    UFCompleto = "Espírito Santo";
                    break;
                case "GO":
                    UFCompleto = "Goiás";
                    break;
                case "MA":
                    UFCompleto = "Maranhão";
                    break;
                case "MT":
                    UFCompleto = "Mato Grosso";
                    break;
                case "MS":
                    UFCompleto = "Mato Grosso do Sul";
                    break;
                case "MG":
                    UFCompleto = "Minas Gerais";
                    break;
                case "PA":
                    UFCompleto = "Pará";
                    break;
                case "PB":
                    UFCompleto = "Paraíba";
                    break;
                case "PR":
                    UFCompleto = "Paraná";
                    break;
                case "PE":
                    UFCompleto = "Pernambuco";
                    break;
                case "PI":
                    UFCompleto = "Piauí";
                    break;
                case "RJ":
                    UFCompleto = "Rio de Janeiro";
                    break;
                case "RN":
                    UFCompleto = "Rio Grande do Norte";
                    break;
                case "RS":
                    UFCompleto = "Rio Grande do Sul";
                    break;
                case "RO":
                    UFCompleto = "Rondônia";
                    break;
                case "RR":
                    UFCompleto = "Roraima";
                    break;
                case "SC":
                    UFCompleto = "Santa Catarina";
                    break;
                case "SP":
                    UFCompleto = "São Paulo";
                    break;
                case "SE":
                    UFCompleto = "Sergipe";
                    break;
                case "TO":
                    UFCompleto = "Tocantins";
                    break;

            }
            return UFCompleto;
        }

        private int validarEscritorio(int flag)
        {
            if (inputNome.Text == "")
            {
                MessageBox.Show("Informe o nome do CL!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else 
            if(inputLCP.Text == "")
            {
                MessageBox.Show("Informe o nome do(a) LCP!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputCNPJ.Text == "")
            {
                MessageBox.Show("Informe o CNPJ!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (removerMascara(inputCNPJ.Text) == "")
            {
                MessageBox.Show("Informe o CNPJ!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
                if (validador.validarCNPJ(inputCNPJ.Text) == false)
            {
                MessageBox.Show("CNPJ Inválido!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (removerMascara(inputCEP.Text) == "")
            {
                MessageBox.Show("Informe o CEP!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputRua.Text == "")
            {
                MessageBox.Show("Informe a Rua!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputNumero.Text == "")
            {
                MessageBox.Show("Informe o Número!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputBairro.Text == "")
            {
                MessageBox.Show("Informe o Bairro!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputUFEndereco.Text == "")
            {
                MessageBox.Show("Informe a UF!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }
            else
            if (inputCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade!", "Cadastro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = 1;
            }

            return flag;
        }

        public string removerMascara(string campoMascara)
        {
            string campoNovo = campoMascara.Replace(".", "").Replace("-", "").Replace("_", "").Replace(" ", "");
            return campoNovo;
        }

        private void inputLCP_EditValueChanged(object sender, EventArgs e)
        {
            var LCP = sender as DevExpress.XtraEditors.ButtonEdit;
            var pessoas = _repositorioPessoa.ListarTodasPessoas();
            var form = new SelecionarPessoa(pessoas);
            form.ShowDialog(MdiParent);
            pessoaId = form.SelectedItem.Id;
            pessoaNome = form.SelectedItem.Nome;
            inputLCP.Text = form.SelectedItem.Nome + " " + form.SelectedItem.Sobrenome;
        }
    }
}

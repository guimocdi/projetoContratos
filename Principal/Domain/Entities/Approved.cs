﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Principal.Domain.Entities
{
    [Table("Approved")]
    public class Approved
    {
        [Key]
        public int Id { get; set; }
        public int IdEP { get; set; }
        public string NomeEP { get; set; }
        public int IdResponsavel { get; set; }
        public string NomeResponsavel { get; set; }
        public string EPID { get; set; }
        public int IdPresidente { get; set; }
        public int TipoProdutoId { get; set; }
        public string TipoProdutoDescricao { get; set; }
        public string TNID { get; set; }
        public string PaisDestino { get; set; }
        public string CidadeDestino { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int CargaHorariaNumeral { get; set; }
        public string CargaHorariaExtenso { get; set; }
        public string TrabalhoSabado { get; set; }
        public string TaxaDestino { get; set; }
        public string BolsaAuxilio { get; set; }
        public string AcomodacaoProvida { get; set; }
        public string AcomodacaoCoberta { get; set; }
        public string AlimentacaoDiaTrabalho { get; set; }
        public string AlimentacaoFimSemana { get; set; }
        public string Computador { get; set; }
        public DateTime DataApproved { get; set; }
        public decimal ValorContratoNumerico { get; set; }
        public string ValorContratoExtenso { get; set; }
        public DateTime DataPagamento { get; set; }
        public int TipoPagamento { get; set; }
        public int QtdParcelas { get; set; }
        public decimal ValorParcialNumerico { get; set; }
        public string ValorParcialExtenso { get; set; }
        public DateTime Parcela1 { get; set; }
        public DateTime Parcela2 { get; set; }
        public DateTime Parcela3 { get; set; }
        public DateTime Parcela4 { get; set; }
        public DateTime Parcela5 { get; set; }
        public DateTime Parcela6 { get; set; }
        public DateTime Parcela7 { get; set; }
        public DateTime Parcela8 { get; set; }
        public DateTime Parcela9 { get; set; }
        public DateTime Parcela10 { get; set; }
        public DateTime Parcela11 { get; set; }
        public DateTime Parcela12 { get; set; }
        public bool ModoBoleto { get; set; }
        public bool ModoCartaoCredito { get; set; }
        public bool ModoCartaoDebito { get; set; }
        public bool ModoCheque { get; set; }
        public bool ModoDeposito { get; set; }
        public bool ModoDinheiro { get; set; }
        public bool ModoPagSeguro { get; set; }
        public bool ModoTransferencia { get; set; }
        public int IdTestemunha1 { get; set; }
        public string NomeTestemunha1 { get; set; }
        public int IdTestemunha2 { get; set; }
        public string NomeTestemunha2 { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CVDentalSteticSystem.Models
{
    public class Citas
    {
        [Key]
        public int CitaId { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "0:dd/MM/yyyy hh:mm tt")]
        [Required(ErrorMessage = "Debe seleccionar una fecha para la cita")]
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string Observacion { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un paciente!")]
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un tipo de cita!")]
        public int TipoCitaId { get; set; }
    }
}

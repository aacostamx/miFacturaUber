using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace miFacturaUber.Models
{
    public enum DiasLaborales
    {
        Día = 1,
        Semana = 6,
        Quincena = 12,
        Mes = 24,
        Año = 305
    }

    public class FacturaUber
    {
        public static double porcentajeComision = 0.20d;

        [Display(Name = "FacturaID")]
        public int FacturaUberID { get; set; }
        [Display(Name = "Total Facturado")]
        [DataType(DataType.Currency)]
        public double TotalFactura { get; set; }
        [Display(Name = "Comisión Uber")]
        [DataType(DataType.Currency)]
        public double ComisionUber
        {
            get
            {
                return TotalFactura * porcentajeComision;
            }
        }
        [DataType(DataType.Currency)]
        [Display(Name = "Sueldo del Chofer")]
        public double SueldoChofer { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Gasolina")]
        public double Gasolina { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Plan mensual celular")]
        public double PlanCelular { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Otros gastos")]
        public double OtrosGastos { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Total Neto")]
        public double TotalNeto
        {
            get
            {
                return ((TotalFactura - ((TotalFactura * porcentajeComision))) - SueldoChofer - Gasolina - PlanCelular - OtrosGastos);
            }
        }
        [Display(Name = "Factura por rango")]
        public DiasLaborales? Rango { get; set; }

        public FacturaUber()
        {

        }
    }
}
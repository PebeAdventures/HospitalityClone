using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitality.Common.DTO.Temperature
{
    public class PatientTemperaturesViewDTO
    {

        public string PatientId { get; set; }
        public decimal Temperature { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}

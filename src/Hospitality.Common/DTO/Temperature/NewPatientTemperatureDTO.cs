using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitality.Common.DTO.Temperature
{
    public class NewPatientTemperatureDTO
    {
        public int PatientId { get; set; }
        public decimal Temperature { get; set; }
    }
}

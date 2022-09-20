using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitality.Common.DTO.Examination
{
    public class ExaminationExecutionDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public int ExaminationTypeId { get; set; }
        public int Status { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

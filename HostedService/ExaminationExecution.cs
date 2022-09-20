using Newtonsoft.Json;
using Hospitality.Common.DTO.Examination;
using System.Diagnostics;

namespace HostedService
{
    public interface IExaminationExecution
    {
        ExaminationExecutionDto executeExamination(string jsonData);
    }

    public class ExaminationExecution : IExaminationExecution
    {
        public ExaminationExecutionDto executeExamination(string jsonData)
        {
            ExaminationExecutionDto examinationExecutionDto = JsonConvert.DeserializeObject<ExaminationExecutionDto>(jsonData);
            examinationExecutionDto.Status = 1;
            Thread.Sleep(examinationExecutionDto.Duration);
            Debug.WriteLine(" Thread.Sleep is finished.");
           // string modifiedJSON = JsonConvert.SerializeObject(examinationExecutionDto);
            return examinationExecutionDto;
        }
    }
}

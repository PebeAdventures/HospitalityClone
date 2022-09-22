using Newtonsoft.Json;
using Hospitality.Common.DTO.Examination;
using System.Diagnostics;
using Hospitality.Common.FakeExamination;

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
            int examinationType = examinationExecutionDto.ExaminationTypeId;
            if (examinationType == 1 || examinationType == 2)
            {
                examinationExecutionDto.Description = getFakeExaminationResult(examinationType);
            } else
            {
                examinationExecutionDto.Description = ""; 
            }
           // string modifiedJSON = JsonConvert.SerializeObject(examinationExecutionDto);
            return examinationExecutionDto;
        }

        private string getFakeExaminationResult(int examinationType)
        {
            switch (examinationType)
            {
                case 1: return setBiohemiaResult();
                case 2: return setCardiacUltrasound();
            }

            return "Not examination result";

        }

        private string setBiohemiaResult()
        {
            Biohemia newResult = new Biohemia();
            return ($"Leukocyty: {newResult.Leukocyty},\nErytrocyty: {newResult.Erytrocyty}\nHemoglobina: {newResult.Hemoglobina}," +
                $"\nHematokryt: {newResult.Hematokryt},\nMCV: {newResult.MCV},\nMCHC:{newResult.MCHC},\nPDW:{newResult.PDW},\n" +
                $"MPV: {newResult.MPV},\nNEU%: {newResult.NEU},\nLYMPH%:{newResult.LYMPH},\nMON%: {newResult.MON}");
        }

        private string setCardiacUltrasound()
        {
            CardiacUltrasound newResult = new CardiacUltrasound();
            return ($"\nLewa komora: {newResult.LewaKomora},\nPrawa komora: {newResult.PrawaKomora}\nPrzegroda miedzykomorkowa: {newResult.PrzegrodaMiedzykomorkowa}," +
                $"\nLewy przedsionek: {newResult.LewyPrzedsionek},\nPrawy przedsionek: {newResult.PrawyPrzedsionek},\nVSD:{newResult.VSD},\nTOF:{newResult.TOF}\nTGA:{newResult.TGA}\n");
        }
    }
}

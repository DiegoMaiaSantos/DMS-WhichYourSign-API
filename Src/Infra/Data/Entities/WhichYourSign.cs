namespace DMS_WhichYourSign_API.Src.Infra.Data.Entities
{
    public class WhichYourSign
    {
        public byte SignId { get; set; }
        public string SignName { get; set; }
        public DateTime InicialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}

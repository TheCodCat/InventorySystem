namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class RESTDto//класс запроса
    {
        public int Id;//ид предмета
        public string Data_submitted;//евент

        public RESTDto(int id, string submitted)//конструктор
        {
            Id = id;
            Data_submitted = submitted;
        }
    }
}

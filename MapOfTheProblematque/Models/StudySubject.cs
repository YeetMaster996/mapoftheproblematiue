namespace MapOfTheProblematique.Models
{
    public class StudySubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudyClassId { get; set; }
        public StudyClass? StudyClass { get; set; }
        public List<StudyTopic> StudyTopics { get; set; }
    }
}

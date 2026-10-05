namespace MapOfTheProblematique.Models
{
    public class StudyTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudySubjectId { get; set; }
        public StudySubject? StudySubject { get; set; }
    }
}
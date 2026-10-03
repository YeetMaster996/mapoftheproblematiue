using System.Runtime.CompilerServices;

namespace MapOfTheProblematique.Models
{
    public class StudyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudySubject> StudySubjects { get; set; }
    }
    public class StudySubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudyClassId { get; set; }
        public StudyClass? StudyClass { get; set; }
        public List<StudyTopic> StudyTopics { get; set; }
    }
    public class StudyTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudySubjectId { get; set; }
        public StudySubject? StudySubject { get; set; }
    }

}

using System.Runtime.CompilerServices;

namespace MapOfTheProblematique.Models
{
    public class StudyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudySubject> StudySubjects { get; set; }
    }
    
    

}

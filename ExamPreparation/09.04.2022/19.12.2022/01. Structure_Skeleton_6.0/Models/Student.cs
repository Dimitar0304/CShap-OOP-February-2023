using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
       // private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;
        private IUniversity university;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
        }

        public int Id { get; set; }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                firstName = value;
            }
        }


        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams { get => coveredExams; }

        public IUniversity University { get => university; set { value = university; } }

        public void CoverExam(ISubject subject)
        {
            var id = subject.Id;
            coveredExams.Add(id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}

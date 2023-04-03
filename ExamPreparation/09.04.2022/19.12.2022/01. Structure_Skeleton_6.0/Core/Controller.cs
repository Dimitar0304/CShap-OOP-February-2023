using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects = new SubjectRepository();
        private StudentRepository students = new StudentRepository();
        private UniversityRepository universities = new UniversityRepository();
        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = new Student(students.Models.Count+1, firstName, lastName);
            if (students.FindByName($"{student.FirstName} {student.LastName}")!=null)
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }
            students.AddModel(student);
            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = null;
            if (subjectType== "EconomicalSubject")
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType== "HumanitySubject")
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
            }
            else if (subjectType== "TechnicalSubject")
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }
            else if(subjectType!= "Economical"&&subjectType!= "Humanity"&&subjectType!= "Technical")
            {
                return "Subject type {subjectType} is not available in the application!";
            }

            if (subjects.FindByName(subject.Name)==subject)
            {
                return $"{subjectName} is already added in the repository.";
            }
            else
            {
                subjects.AddModel(subject);
                return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
            }
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName)!=null)
            {
                return $"{universityName} is already added in the repository.";

            }
            List<int> result = new List<int>();
            foreach (var item in requiredSubjects)
            {
                var currentId = subjects.FindByName(item);
                result.Add(currentId.Id);
            }
            IUniversity university = new University(universities.Models.Count+1,universityName
                ,category, capacity,result);
            universities.AddModel(university);
            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] nameInfo = studentName.Split(" ");
            var student = students.FindByName(studentName);
            var uni = universities.FindByName(universityName);

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            list1 = student.CoveredExams.Except(uni.RequiredSubjects).ToList();
            list2 = uni.RequiredSubjects.Except(student.CoveredExams).ToList();


            if (student==null)
            {
                return $"{nameInfo[0]} {nameInfo[1]} is not registered in the application!";
            }
            if (uni==null)
            {
                return $"{universityName} is not registered in the application!";
            }
            if (!Enumerable.SequenceEqual(list1, list2))
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }
            if (student.University==uni)
            {
                return $"{nameInfo[0]} {nameInfo[1]} has already joined {uni.Name}.";
            }
            student.JoinUniversity(uni);
            return $"{nameInfo[0]} {nameInfo[1]} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = students.FindById(studentId);
            var subject = subjects.FindById(subjectId);

            if (student==null)
            {
                return "Invalid student ID!";


            }
            if (subject ==null)
            {
                return "Invalid subject ID!";

            }
            if (student.CoveredExams.Contains(subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";

            }
            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            var uni = universities.FindById(universityId);
            var sb = new StringBuilder();
            int countOfStudents = 0;

            foreach (var item in students.Models)
            {
                if (item.University!=null)
                {
                    if (item.University.Name==uni.Name)
                    {
                        countOfStudents++;
                    }
                }
            }

            sb.AppendLine($"*** {uni.Name} ***");
            sb.AppendLine($"Profile: {uni.Category}");
            
            sb.AppendLine($"Students admitted: {countOfStudents}");
            sb.AppendLine($"University vacancy: {uni.Capacity-countOfStudents}");

            return sb.ToString().Trim();
        }
    }
}

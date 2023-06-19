

using Strategy;
using Strategy.Models;

SortedList students = new SortedList();

students.Add("Mitko");
students.Add("Nikki");
students.Add("Velina");
students.Add("George");

students.SetSortedStrategy(new QuickSort());
students.Sort();

students.SetSortedStrategy(new MergeSort());    
students.Sort();

students.SetSortedStrategy(new ShellSort());
students.Sort();
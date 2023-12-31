﻿using StudentExam.DB;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для AddStudentForExam.xaml
    /// </summary>
    public partial class AddStudentForExam : Page
    {
        Employee nameTeacher = new Employee();
        Exam examToSend = new Exam();
        Exam emptyExam = new Exam();

        public static List<Exam> examList { get; set; }
        public AddStudentForExam(Employee currentUser, Exam exam)
        {
            InitializeComponent();

            nameTeacher = currentUser;
            examToSend = exam;

            InfoTextBox.Text = $"Информация об экзамене: {exam.Discipline.Name}, дата: {exam.ExamDate.ToString().Split(' ')[0]}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudent(nameTeacher, examToSend));
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            string regIdStudent = IDStudentTextBox.Text.Trim();
            string markStudent = MarkTextBox.Text.Trim();
            try
            {
                if (regIdStudent != null && markStudent != null && int.Parse(markStudent) <= 5)
                {
                    emptyExam.ExamID = examToSend.ExamID;
                    emptyExam.ExamDate = examToSend.ExamDate;
                    emptyExam.DisciplineID = examToSend.DisciplineID;
                    emptyExam.RegID = int.Parse(regIdStudent);
                    emptyExam.Auditorium = examToSend.Auditorium;
                    emptyExam.Mark = int.Parse(markStudent);

                    Connection.UchebnayaPracticeEntities.Exam.Add(emptyExam);
                    Connection.UchebnayaPracticeEntities.SaveChanges();

                    AddStudentBtn.Background = Brushes.Green;
                }
                else
                    AddStudentBtn.Background = Brushes.Red;
            }
            catch
            {
                AddStudentBtn.Background = Brushes.Red;
            }
        }
    }
}

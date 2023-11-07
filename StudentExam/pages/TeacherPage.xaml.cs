﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentExam.DB;

namespace StudentExam.pages
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public static List<Exam> exams { get; set; }
        Employee nameTeacher = new Employee();
        
        public TeacherPage(Employee currentUser)
        {
            InitializeComponent();
            exams = new List<Exam>(Connection.UchebnayaPracticeEntities.Exam.ToList());
            nameTeacher = currentUser;
            TeacherNameTB.Text += $" {nameTeacher.Surname}";
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void DisciplineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = DisciplineListView.SelectedItem as Exam;
            if (item != null)
            {
                NavigationService.Navigate(new AddStudent(nameTeacher, item));
            }
        }
    }
}

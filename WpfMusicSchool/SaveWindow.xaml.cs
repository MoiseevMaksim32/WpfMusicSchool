using System;
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
using System.Windows.Shapes;
using WpfMusicSchool.Models;

namespace WpfMusicSchool
{
    /// <summary>
    /// Логика взаимодействия для SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
      
        public SaveWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tan = (Button)sender;
                switch (tan.Name) {
                    case "Button_Student":
                        ((MainWindow)Application.Current.MainWindow).studentSave.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).studentSave.GroupMusicID = int.Parse(this.TextBoxStudentGroupMusicID.Text);
                        ((MainWindow)Application.Current.MainWindow).studentSave.SpecilityID = int.Parse(this.TextBoxStudentSpecilityID.Text);
                        ((MainWindow)Application.Current.MainWindow).studentSave.Fio = this.TextBoxStudentFio.Text;
                        ((MainWindow)Application.Current.MainWindow).studentSave.Telephone = this.TextBoxStudentTelephone.Text;
                        ((MainWindow)Application.Current.MainWindow).studentSave.Gender = bool.Parse(this.TextBoxStudentGender.Text);
                        ((MainWindow)Application.Current.MainWindow).studentSave.Email = this.TextBoxStudentEmail.Text;
                        this.DialogResult = true;
                        break;
                    case "Button_Employee":
                        ((MainWindow)Application.Current.MainWindow).employeeSave.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.PositionID = int.Parse(this.TextBoxEmployeePositionID.Text); ;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Fio = this.TextBoxEmployeeFio.Text;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Telephone = this.TextBoxEmployeeTelephone.Text;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Gender = bool.Parse(this.TextBoxEmployeeGender.Text);
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Experience = int.Parse(this.TextBoxEmployeeExperience.Text);
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Email = this.TextBoxEmployeeEmail.Text;
                        this.DialogResult = true;
                        break;
                    case "Button_Concert":
                        ((MainWindow)Application.Current.MainWindow).concertSave.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).concertSave.GenreID = int.Parse(this.TextBoxConcertGenreID.Text);
                        ((MainWindow)Application.Current.MainWindow).concertSave.GroupMusicID = int.Parse(this.TextBoxConcertGroupMusicID.Text);
                        ((MainWindow)Application.Current.MainWindow).concertSave.ConcertDate = DateTime.Parse(this.TextBoxConcertConcertDate.Text);
                        this.DialogResult = true;
                        break;
                    case "Button_GroupMusic":
                        ((MainWindow)Application.Current.MainWindow).groupMusic.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).groupMusic.GroupMusicName = this.TextBoxGroupMusicGroupMusicName.Text;
                        ((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeTeacherID = int.Parse(this.TextBoxGroupMusicEmployeeTeacherID.Text);
                        ((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeAccompanistID = int.Parse(this.TextBoxGroupMusicEmployeeAccompanistID.Text);
                        break;

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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

namespace WpfMusicSchool
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();

            if (((MainWindow)Application.Current.MainWindow).studentSave != null)
            {
                this.TextStudentGroupMusicID.Text = (((MainWindow)Application.Current.MainWindow).studentSave.GroupMusicID).ToString();
                this.TextStudentSpecilityID.Text = (((MainWindow)Application.Current.MainWindow).studentSave.SpecilityID).ToString();
                this.TextStudentFio.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Fio).ToString();
                this.TextStudentTelephone.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Telephone).ToString();
                this.TextStudentGender.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Gender).ToString();
                this.TextStudentEmail.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Email).ToString();

                this.NewTextBoxStudentGroupMusicID.Text = (((MainWindow)Application.Current.MainWindow).studentSave.GroupMusicID).ToString();
                this.NewTextBoxStudentSpecilityID.Text = (((MainWindow)Application.Current.MainWindow).studentSave.SpecilityID).ToString();
                this.NewTextBoxStudentFio.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Fio).ToString();
                this.NewTextBoxStudentTelephone.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Telephone).ToString();
                this.NewTextBoxStudentGender.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Gender).ToString();
                this.NewTextBoxStudentEmail.Text = (((MainWindow)Application.Current.MainWindow).studentSave.Email).ToString();
            }else if (((MainWindow)Application.Current.MainWindow).employeeSave != null)
            {
                //---------------------------------------это работник----------------------------------
                this.TextEmployeePositionID.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.PositionID).ToString();
                this.TextEmployeeFio.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Fio).ToString();
                this.TextEmployeeTelephone.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Telephone).ToString();
                this.TextEmployeeGender.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Gender).ToString();
                this.TextEmployeeExperience.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Experience).ToString();
                this.TextEmployeeEmail.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Email).ToString();

                this.NewTextBoxEmployeePositionID.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.PositionID).ToString();
                this.NewTextBoxEmployeeFio.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Fio).ToString();
                this.NewTextBoxEmployeeTelephone.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Telephone).ToString();
                this.NewTextBoxEmployeeGender.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Gender).ToString();
                this.NewTextBoxEmployeeExperience.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Experience).ToString();
                this.NewTextBoxEmployeeEmail.Text = (((MainWindow)Application.Current.MainWindow).employeeSave.Email).ToString();
            }
            else if (((MainWindow)Application.Current.MainWindow).concertSave != null)
            {
                //-------------------------------------это концерт--------------------------------------------
                this.TextConcertGroupMusicID.Text = (((MainWindow)Application.Current.MainWindow).concertSave.GroupMusicID).ToString();
                this.TextConcertGenreID.Text = (((MainWindow)Application.Current.MainWindow).concertSave.GenreID).ToString();
                this.TextConcertConcertDate.Text = (((MainWindow)Application.Current.MainWindow).concertSave.ConcertDate).ToString();

                this.NewTextBoxConcertGroupMusicID.Text = (((MainWindow)Application.Current.MainWindow).concertSave.GroupMusicID).ToString();
                this.NewTextBoxConcertGenreID.Text = (((MainWindow)Application.Current.MainWindow).concertSave.GenreID).ToString();
                this.NewTextBoxConcertConcertDate.Text = (((MainWindow)Application.Current.MainWindow).concertSave.ConcertDate).ToString();
            }
            else if (((MainWindow)Application.Current.MainWindow).groupMusic != null)
            {
                //-------------------------------это музыкальная группа----------------------------------------
                this.TextGroupMusicGroupMusicName.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.GroupMusicName).ToString();
                this.TextGroupMusicEmployeeTeacherID.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeTeacherID).ToString();
                this.TextGroupMusicEmployeeAccompanistID.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeAccompanistID).ToString();

                this.NewTextBoxGroupMusicGroupMusicName.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.GroupMusicName).ToString();
                this.NewTextBoxGroupMusicEmployeeTeacherID.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeTeacherID).ToString();
                this.NewTextBoxGroupMusicEmployeeAccompanistID.Text = (((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeAccompanistID).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tag = (Button)sender;
                switch (tag.Name)
                {
                    case "Button_Student":
                ((MainWindow)Application.Current.MainWindow).studentSave.GroupMusicID = int.Parse(this.NewTextBoxStudentGroupMusicID.Text);
                ((MainWindow)Application.Current.MainWindow).studentSave.SpecilityID = int.Parse(this.NewTextBoxStudentSpecilityID.Text);
                ((MainWindow)Application.Current.MainWindow).studentSave.Fio = this.NewTextBoxStudentFio.Text;
                ((MainWindow)Application.Current.MainWindow).studentSave.Telephone = this.NewTextBoxStudentTelephone.Text;
                ((MainWindow)Application.Current.MainWindow).studentSave.Gender = bool.Parse(this.NewTextBoxStudentGender.Text);
                ((MainWindow)Application.Current.MainWindow).studentSave.Email = this.NewTextBoxStudentEmail.Text;
                this.DialogResult = true;
                        break;
                    case "Button_Employee":
                        ((MainWindow)Application.Current.MainWindow).employeeSave.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.PositionID = int.Parse(this.NewTextBoxEmployeePositionID.Text); ;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Fio = this.NewTextBoxEmployeeFio.Text;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Telephone = this.NewTextBoxEmployeeTelephone.Text;
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Gender = bool.Parse(this.NewTextBoxEmployeeGender.Text);
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Experience = int.Parse(this.NewTextBoxEmployeeExperience.Text);
                        ((MainWindow)Application.Current.MainWindow).employeeSave.Email = this.NewTextBoxEmployeeEmail.Text;
                        this.DialogResult = true;
                        break;
                    case "Button_Concert":
                        ((MainWindow)Application.Current.MainWindow).concertSave.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).concertSave.GenreID = int.Parse(this.NewTextBoxConcertGenreID.Text);
                        ((MainWindow)Application.Current.MainWindow).concertSave.GroupMusicID = int.Parse(this.NewTextBoxConcertGroupMusicID.Text);
                        ((MainWindow)Application.Current.MainWindow).concertSave.ConcertDate = DateTime.Parse(this.NewTextBoxConcertConcertDate.Text);
                        this.DialogResult = true;
                        break;
                    case "Button_GroupMusic":
                        ((MainWindow)Application.Current.MainWindow).groupMusic.ID = 0;
                        ((MainWindow)Application.Current.MainWindow).groupMusic.GroupMusicName = this.NewTextBoxGroupMusicGroupMusicName.Text;
                        ((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeTeacherID = int.Parse(this.NewTextBoxGroupMusicEmployeeTeacherID.Text);
                        ((MainWindow)Application.Current.MainWindow).groupMusic.EmployeeAccompanistID = int.Parse(this.NewTextBoxGroupMusicEmployeeTeacherID.Text);
                        this.DialogResult = true;
                        break;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

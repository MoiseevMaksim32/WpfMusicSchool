using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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
using WpfMusicSchool.Models;

namespace WpfMusicSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public Student studentSave {  get; set; }
        public Employee employeeSave { get; set; }
        public Concert concertSave { get; set; }
        public GroupMusic groupMusic { get; set; }

        public MainWindow()
        {
           
            client.BaseAddress = new Uri("http://localhost:5164/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        InitializeComponent();
        }

        private async void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            var tag = (Button) sender;
            switch (tag.Name)
            {
                case "ButtonViewStudent":
                    await GetList<Student>("student",dgStudent);
                    break;
                case "ButtonViewEmployee":
                    await GetList<Employee>("employee", dgEmployee);
                    break;
                case "ButtonViewConcert":
                    await GetList<Concert>("concert", dgConcert);
                    break;
                case "ButtonViewGroupMusic":
                    await GetList<GroupMusic>("group_music", dgGroupMusic);
                    break;
            }
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var tag = (Button)sender;
            switch (tag.Name)
            {
                case "ButtonDeleteStudent":
                    try
                    {
                        Student student = dgStudent.SelectedValue as Student;
                        await DeleteModele<Student>("student", student.ID);
                        await GetList<Student>("student", dgStudent);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Вы не выбрали элемент их списка");
                    }
                    break;
                case "ButtonDeleteEmployee":
                    try
                    {
                        Employee employee = dgEmployee.SelectedValue as Employee;
                        await DeleteModele<Employee>("employee", employee.ID);
                        await GetList<Student>("employee", dgEmployee);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Вы не выбрали элемент их списка");
                    }
                    break;
                case "ButtonDeleteConcert":
                    try
                    {
                        Concert concert = dgConcert.SelectedValue as Concert;
                        await DeleteModele<Concert>("concert", concert.ID);
                        await GetList<Student>("concert", dgConcert);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Вы не выбрали элемент их списка");
                    }
                    break;
            }
        }

        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tag = (Button)sender;
                switch (tag.Name)
                {
                    case "ButtonUpdateStudent":
                        studentSave = new Student();
                        studentSave = dgStudent.SelectedValue as Student;
                        UpdateWindow updateWindow = new UpdateWindow();
                        updateWindow.UpdateTabControl.SelectedItem = updateWindow.UpdateStudentTabItem;
                        if(updateWindow.ShowDialog() == true)
                        {
                            await UpdateModele<Student>("student", studentSave);
                            await GetList<Student>("student", dgStudent);
                           // UpdateModele<Student>("student", studentSave);
                            //this.ButtonViewConcert.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                           // await GetList<Student>("student", dgStudent);

                        }
                        studentSave = null;
                        break;
                    case "ButtonUpdateEmployee":
                        employeeSave = new Employee();
                        employeeSave = dgEmployee.SelectedValue as Employee;
                        UpdateWindow updateWindow1 = new UpdateWindow();
                        updateWindow1.UpdateTabControl.SelectedItem = updateWindow1.UpdateEmployeeTabItem;
                        if (updateWindow1.ShowDialog() == true)
                        {
                            await UpdateModele<Employee>("employee", employeeSave);
                            await GetList<Student>("employee", dgEmployee);
                        }
                        employeeSave = null;
                        break;
                    case "ButtonUpdateConcert":
                        concertSave = new Concert();
                        concertSave = dgConcert.SelectedValue as Concert;
                        UpdateWindow updateWindow2 = new UpdateWindow();
                        updateWindow2.UpdateTabControl.SelectedItem = updateWindow2.UpdateConcertTabItem;
                        if (updateWindow2.ShowDialog() == true)
                        {
                            await UpdateModele<Concert>("concert", concertSave);
                            await GetList<Concert>("concert", dgConcert);
                        }
                        concertSave=null;
                        break;
                    case "ButtonUpdateGroupMusic":
                        groupMusic = new GroupMusic();
                        groupMusic = dgGroupMusic.SelectedValue as GroupMusic;
                        UpdateWindow updateWindow3 = new UpdateWindow();
                        updateWindow3.UpdateTabControl.SelectedItem = updateWindow3.UpdateGroupMusicTabItem;
                        if(updateWindow3.ShowDialog() == true)
                        {
                            await UpdateModele<GroupMusic>("group_music", groupMusic);
                            await GetList<GroupMusic>("group_music", dgGroupMusic);
                        }
                        groupMusic=null;
                        break;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       /* private async Task CallBack(Func<string,DataGrid,Task> callback)
        {
           // UpdateModele<Student>("student", studentSave);
            await callback("student", dgStudent);
        }
*/
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tag = (Button)sender;
                SaveWindow saveWindow = new SaveWindow();
                switch (tag.Name)
                {
                    case "ButtonSaveStudent":
                        saveWindow.SaveTabControl.SelectedItem = saveWindow.StudentTabItems;
                        studentSave = new Student();
                        if (saveWindow.ShowDialog() == true)
                        {
                            MessageBox.Show(studentSave.ToString());
                            await SaveModele<Student>("student",studentSave);
                            await GetList<Student>("student", dgStudent);
                        }
                        studentSave = null;
                        break;
                    case "ButtonSaveEmployee":
                        saveWindow.SaveTabControl.SelectedItem = saveWindow.EmployeeTabItems;
                        employeeSave = new Employee();
                        if(saveWindow.ShowDialog() == true)
                        {
                            await SaveModele<Employee>("employee", employeeSave);
                            await GetList<Employee>("employee", dgEmployee);
                        }
                        employeeSave = null;
                        break;
                    case "ButtonSaveConcert":
                        saveWindow.SaveTabControl.SelectedItem = saveWindow.ConcertTabItems;
                        concertSave = new Concert();    
                        if (saveWindow.ShowDialog() == true)
                        {
                            await SaveModele<Concert>("concert", concertSave);
                            await GetList<Concert>("concert", dgConcert);
                        }
                        concertSave = null;
                        break;
                    case "ButtonSaveGroupMusic":
                        saveWindow.SaveTabControl.SelectedItem = saveWindow.GroupMusicTabItems;
                        groupMusic = new GroupMusic();
                        if(saveWindow.ShowDialog() == true)
                        {
                            await SaveModele<GroupMusic>("group_music", groupMusic);
                            await GetList<GroupMusic>("group_music", dgGroupMusic);
                        }
                        groupMusic = null;
                        break;
                }

            }catch(Exception ex)
            {
                MessageBox.Show($"Ошибка - {ex.Message}");
            }
        }

       /* private async void GetListStudent()
        {
            try
            {
                var reponse = await client.GetStringAsync("student");
                var models = JsonConvert.DeserializeObject<List<Student>>(reponse);
                foreach (var item in models)
                {
                    Student student = (Student)item.Clone();
                    students.Add(student);
                }
                dgStudent.DataContext = models;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/
        // Решение хорошое, но я не могу заполнить поле 'student'  с типом list<Student> 
         // т.к не могу передать его по ссылке
         // Уже использую его т.к. изменение через внесение изменения в DataGrid не увенчалось успехом
         // Проблема была в том что при нажатии на любую ячейку WPF выбрасывало исключение "Ссылка на не существующих объект"
         // пробелма была локализована и заключалось в том что я переопределил метод Equale и где-то видимо происходило сравнение
         // объектом "которого нет". Большая часть кода прошлого решения была удалена
                private async Task GetList<T>(string path, DataGrid dataGrid)
                {
                    try
                    {
                        var reponse = await client.GetStringAsync(path);
                        var models = JsonConvert.DeserializeObject<List<T>>(reponse);
                        dataGrid.DataContext = models;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
        private async Task SaveModele<T>(string path,T module)
        {
            try
            {
                await client.PostAsJsonAsync(path, module);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task UpdateModele<T>(string path,T model)
            where T: Modele
        {
            try
            {
                await client.PutAsJsonAsync(path+"/"+model.ID,model);
                //MessageBox.Show(a.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
}

        private async Task DeleteModele<T>(string path,int id)
        {
            try
            {
                await client.DeleteAsync(path+"/"+id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMusicSchool.Models
{

    public interface Modele
    {
         int ID { get; set; }
    }
    public class Speciality: Modele
    {
        public int ID { get; set; }
        public string SpecialityName { get; set; }
    }

    public class Genres : Modele
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
    }

    public class Position : Modele
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
    }

    public class Employee : Modele
    {
        public int ID { get; set; }
        public int PositionID { get; set; }
        public string Fio { get; set; }
        public string Telephone { get; set; }
        public bool Gender { get; set; }
        public int Experience { get; set; }
        public string Email { set; get; }
    }

    public class GroupMusic : Modele
    {
        public int ID { get; set; }
        public string GroupMusicName { get; set; }
        public int EmployeeTeacherID { get; set; }
        public int EmployeeAccompanistID { get; set; }
    }

    public class Student : Modele
    {
     
        public int ID { get; set; }
        public int GroupMusicID { get; set; }
        public int SpecilityID { get; set; }
        public string Fio { get; set; }
        public string Telephone { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Student: {ID}, {GroupMusicID}, {SpecilityID}, {Fio}, {Telephone}, {Gender}, {Email} ";
        }
        public object Clone()
        {
            return MemberwiseClone() ;
        }
    }

    public class Concert : Modele
    {
        public int ID { get; set; }
        public int GroupMusicID { get; set; }
        public int GenreID { get; set; }
        public DateTime ConcertDate { get; set; }
    }
}

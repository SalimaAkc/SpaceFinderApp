using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpacefinderApp.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserType Type { get; set; } 
    }

    public enum UserType
    {
        Student,
        Teacher
    }

    public class Student : User
    {
        public string RNumber { get; set; } 
        public Student()
        {
            Type = UserType.Student;
        }
    }

    public class Teacher : User
    {
        public string UNumber { get; set; } 
        public Teacher()
        {
            Type = UserType.Teacher;
        }
    }
}

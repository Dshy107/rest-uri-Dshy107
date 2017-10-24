using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Education;

namespace WcfRESTserviceStudent
{
    public class SchoolService : ISchoolService
    {
        /// <summary>
        /// An example for a method returning data about the school classes
        /// GET method
        /// </summary>
        /// <returns>a list of all school classes</returns>
        public List<SchoolClass> GetSchoolClassData()
        {     
            return SchoolData.SchoolClasses;
        }

        public List<Teacher> GetAllTeachers(string nameFragment = null, string sort = null)
        {
            List<Teacher> data = SchoolData.Teachers;
            if (nameFragment != null)
                data = data.FindAll(teacher => teacher.Name.Contains(nameFragment));
            if (sort == null) return data;
            sort = sort.ToLower();
            switch (sort)
            {
                case "name":
                    data.Sort((teacher, teacher1) => teacher.Name.CompareTo(teacher1.Name));
                    return data;
                case "id":
                    data.Sort((teacher, teacher1) => teacher.Id - teacher1.Id);
                    return data;
                case "mobileno":
                    data.Sort((teacher, teacher1) => teacher.MobileNo - teacher1.MobileNo);
                    return data;
                default: return data;
            }
        }

        public IEnumerable<string> GetAllTeachersName()
        {
            return SchoolData.Teachers.Select(teacher => teacher.Name);
        }

        public Teacher GetTeacherById(string id)
        {
            int idInt = int.Parse(id);
            return SchoolData.Teachers.FirstOrDefault(teacher => teacher.Id == idInt);
        }

        public IEnumerable<Teacher> GetTeachersByName(string nameFragment)
        {
            nameFragment = nameFragment.ToLower();
            return SchoolData.Teachers.FindAll(teacher => teacher.Name.ToLower().Contains(nameFragment));
        }

        public IEnumerable<SchoolClass> GetSchoolClassesByTeacherId(string id)
        {
            int idInt = int.Parse(id);
            var result = from cl in SchoolData.SchoolClasses
                         join tc in SchoolData.TeacherClasses on cl.SchoolClassId equals tc.SchoolClassId
                         where tc.TeacherId == idInt
                         select cl;
            return result;
        }

        public IEnumerable<Teacher> GetTeachersByStudentId(string id)
        {
            int idInt = int.Parse(id);
            var result = from st in SchoolData.Students
                             //join cl in SchoolData.SchoolClasses on st.SchoolClassId equals cl.SchoolClassId
                         join stte in SchoolData.TeacherClasses on st.SchoolClassId equals stte.SchoolClassId
                         join te in SchoolData.Teachers on stte.TeacherId equals te.Id
                         where st.Id == idInt
                         select te;
            return result;

        }

        public IEnumerable<Student> GetStudentsByTeacherId(string id)
        {
            int idInt = int.Parse(id);
            var result = from stte in SchoolData.TeacherClasses
                         join cl in SchoolData.SchoolClasses on stte.SchoolClassId equals cl.SchoolClassId
                         join st in SchoolData.Students on cl.SchoolClassId equals st.SchoolClassId
                         where stte.TeacherId == idInt
                         select st;
            return result;
        }

        public Teacher DeleteTeacher(string id)
        {
            int idint = int.Parse(id);
            Teacher teacher = SchoolData.Teachers.Find(te => te.Id == idint);
            if (teacher == null) return null;
            SchoolData.Teachers.Remove(teacher);
            return teacher;
        }

        public Teacher AddTeacher(Teacher teacher)
        {
            // ID??
            SchoolData.Teachers.Add(teacher);
            return teacher;
        }

        public Teacher UpdateTeacher(string id, Teacher teacher)
        {
            int idInt = int.Parse(id);
            Teacher existingTeacher = SchoolData.Teachers.FirstOrDefault(te => te.Id == idInt);
            if (existingTeacher == null) return null;
            if (teacher.Name != null) existingTeacher.Name = teacher.Name;
            if (teacher.MobileNo != 0) existingTeacher.MobileNo = teacher.MobileNo;
            if (teacher.Salary != null) existingTeacher.Salary = teacher.Salary;
            return existingTeacher;
        }

        public List<Student> GetAllStudents(string nameFragment = null, string sort = null)
        {
            List<Student> data = SchoolData.Students;
            if (nameFragment != null)
            {
                data = data.FindAll(student => student.Name.Contains(nameFragment));

            }
            if (sort == null) return data;
            sort = sort.ToLower();
            switch (sort)
            {
                case "name":
                    data.Sort((student, studnet1) => student.Name.CompareTo(studnet1.Name));
                    return data;
                case "id":
                    data.Sort((student, student1) => student.Id - student1.Id);
                    return data;
                case "mobileno":
                    data.Sort((student, student1) => student.MobileNo - student1.MobileNo);
                    return data;
                case "schoolclassid":
                    data.Sort((student, student1) => student.SchoolClassId.CompareTo(student1.SchoolClassId));
                    return data;
                default: return data;
                

            }
        }

        public Student GetStudentByid(string id)
        {
            int idInt = int.Parse(id);
            return SchoolData.Students.FirstOrDefault(student => student.Id == idInt);
        }

        public Student GetStudentNameById(string id)
        {
            throw new NotImplementedException();
        }

        public Student AddStudent(Student student)
        {
            SchoolData.Students.Add(student);
            return student;
        }

        public Student UpdateStudent(string id, Student student)
        {
            int idInt = int.Parse(id);
            Student existingStudent = SchoolData.Students.FirstOrDefault(st => st.Id == idInt);
            if (existingStudent == null) return null;
            if (student.Name != null) existingStudent.Name = student.Name;
            if (student.MobileNo != 0) existingStudent.MobileNo = student.MobileNo;
            if (student.SchoolClassId != null) existingStudent.SchoolClassId = student.SchoolClassId;
            return existingStudent;
        }

        public Student DeleteStudent(string id)
        {
            throw new NotImplementedException();
        }

        public Student GetTeacherIdByStudents(string id)
        {
            throw new NotImplementedException();
        }
    }
}

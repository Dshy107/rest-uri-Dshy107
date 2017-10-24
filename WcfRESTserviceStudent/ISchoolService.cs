using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Education;

namespace WcfRESTserviceStudent
{
    [ServiceContract]
    public interface ISchoolService
    {
        /// <summary>
        /// An example for a method returning data about the school classes
        /// </summary>
        /// <returns>a list of all school classes</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "classes")]
        List<SchoolClass> GetSchoolClassData();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers?name={namefragment}&sort={sort}")]
        // https://stackoverflow.com/questions/21623432/how-to-pass-multiple-parameter-in-wcf-restful-service
        List<Teacher> GetAllTeachers(string nameFragment = null, string sort = null);



        // Not legal: endpoints are consideres equal when they only differ by ?name=val
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "teachers?name={nameFragment}")]
        //IEnumerable<Teacher> GetTeachersByName(string nameFragment);

        // Alternative to teachers?name={namefragment}&sort={sort}
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers/name")]
        IEnumerable<string> GetAllTeachersName();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "teachers/{id}")]
        Teacher GetTeacherById(string id);

        /// <summary>
        /// Alternative to teachers?name={namefragment}&amp;sort={sort}
        /// </summary>
        /// <param name="nameFragment"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers/name/{namefragment}")]
        IEnumerable<Teacher> GetTeachersByName(string nameFragment);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers/{id}/classes")]
        IEnumerable<SchoolClass> GetSchoolClassesByTeacherId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "students/{id}/teachers")]
        IEnumerable<Teacher> GetTeachersByStudentId(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers/{id}/students")]
        IEnumerable<Student> GetStudentsByTeacherId(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "teachers/{id}")]
        Teacher DeleteTeacher(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "teachers/")]
        Teacher AddTeacher(Teacher teacher);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "teachers/{id}")]
        Teacher UpdateTeacher(string id, Teacher teacher);

        //Students
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "students?name={namefragment}&sort={sort}")]
        List<Student> GetAllStudents(string nameFragment = null, string sort = null);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "students/{id}")]
        Student GetStudentByid(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "students/{id}/name")]
        Student GetStudentNameById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "students/{id}")]
        Student AddStudent(Student student);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "students/{id}")]
        Student UpdateStudent(string id, Student student);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "students/{id}")]
        Student DeleteStudent(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "teatchers/{id}/students")]
        Student GetTeacherIdByStudents(string id);
    }
}

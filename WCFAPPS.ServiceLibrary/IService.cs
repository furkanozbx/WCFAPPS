using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAPPS.Entities;

namespace WCFAPPS.ServiceLibrary
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<Course> GetCourses();
        [OperationContract]
        Course GetCourseById(int id);
        [OperationContract]
        void InsertCourse(Course entity);
        [OperationContract]
        void UpdateCourse(Course entity);
        [OperationContract]
        void DeleteCourse(int id);
    }
}

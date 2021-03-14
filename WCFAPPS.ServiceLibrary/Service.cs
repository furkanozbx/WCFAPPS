using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAPPS.Domain;
using WCFAPPS.Entities;

namespace WCFAPPS.ServiceLibrary
{
    public class Service : IService
    {
        CourseObject course = new CourseObject();

        public void DeleteCourse(int id)
        {
            course.Delete(id);
        }

        public Course GetCourseById(int id)
        {
            return course.GetDataById(id);
        }

        public List<Course> GetCourses()
        {
            return course.GetAllData();
        }

        public void InsertCourse(Course entity)
        {
            course.Create(entity);
        }

        public void UpdateCourse(Course entity)
        {
            course.Update(entity);
        }
    }
}

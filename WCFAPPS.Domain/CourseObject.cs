using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFAPPS.Entities;

namespace WCFAPPS.Domain
{
    public class CourseObject : IDatabaseObject<Course>
    {
        public void Create(Course data)
        {
            using (SqlCommand _command = new SqlCommand("SP_Insert", DatabaseConnection.OpenSqlConnection()))
            {
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CourseName", data.CourseName);
                _command.Parameters.AddWithValue("@CourseHourPerWeek", data.CourseHourPerWeek);
                _command.ExecuteNonQuery();

                DatabaseConnection.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand _command = new SqlCommand("SP_Delete", DatabaseConnection.OpenSqlConnection()))
            {
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CourseId", id);
                _command.ExecuteNonQuery();

                DatabaseConnection.CloseConnection();
            }
        }

        public void Delete(Course data)
        {
            using (SqlCommand _command = new SqlCommand("SP_Delete", DatabaseConnection.OpenSqlConnection()))
            {
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CourseId", data.CourseId);
                _command.ExecuteNonQuery();

                DatabaseConnection.CloseConnection();
            }
        }

        public List<Course> GetAllData()
        {
            using (SqlCommand _command = new SqlCommand("SP_GetAllData", DatabaseConnection.OpenSqlConnection()))
            {
                var _reader = _command.ExecuteReader();
                var _list = new List<Course>();
                while (_reader.Read())
                {
                    _list.Add(new Course
                    {
                        CourseId = Convert.ToInt32(_reader[0].ToString()),
                        CourseName = _reader[1].ToString(),
                        CourseHourPerWeek = Convert.ToInt16(_reader[2].ToString())
                    });
                }
                DatabaseConnection.CloseConnection();
                return _list;
            }
        }

        public Course GetDataById(int id)
        {
            var _adap = new SqlDataAdapter("SP_GetDataById", DatabaseConnection.OpenSqlConnection());
            _adap.SelectCommand.Parameters.AddWithValue("@CourseId", id);
            _adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            var _data = new DataTable();
            _adap.Fill(_data);
            var retVal = new Course
            {
                CourseId = Convert.ToInt32(_data.Rows[0][0].ToString()),
                CourseName = _data.Rows[0][1].ToString(),
                CourseHourPerWeek = Convert.ToInt16(_data.Rows[0][2].ToString())
            };
            DatabaseConnection.CloseConnection();
            return retVal;

        }

        public void Update(Course data)
        {
            using (SqlCommand _command = new SqlCommand("SP_Update", DatabaseConnection.OpenSqlConnection()))
            {
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CourseId", data.CourseId);
                _command.Parameters.AddWithValue("@CourseName", data.CourseName);
                _command.Parameters.AddWithValue("@CourseHourPerWeek", data.CourseHourPerWeek);
                _command.ExecuteNonQuery();
                DatabaseConnection.CloseConnection();
            }
        }
    }
}

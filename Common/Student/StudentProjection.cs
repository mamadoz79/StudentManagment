using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;

namespace SystemGroup.Retail.StudentManagement.Common
{
    public class StudentProjection : EntityProjection<Student>
    {
        #region Methods 

        public override IQueryable Project(IQueryable<Student> students)
        {
            
            return students;
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            
            
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.FirstName)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.LastName)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.Code)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.BirthDate)));
            columns.Add(new EntityColumnInfo<Student>(nameof(Student.Gender)));

        }

        #endregion
    }

    public class StudentNameProjection : EntityProjection<Student>
    {
        public override IQueryable Project(IQueryable<Student> students)
        {
            return from student in students
                   select new
                   {
                       student.ID,
                       Name = student.FirstName + " " + student.LastName,
                       
                   };
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            columns.Add(new TextColumnInfo("Name", "نام کامل"));           
        }
    }
}

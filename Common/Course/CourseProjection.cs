using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Service;
using SystemGroup.General.IPartyManagement.Common;

namespace SystemGroup.Retail.StudentManagement.Common
{
    public class CourseProjection : EntityProjection<Course>
    {
        #region Methods

        public override IQueryable Project(IQueryable<Course> courses)
        {
            return from course in courses
                   select course;
                   
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            columns.Add(new TextColumnInfo("Name", "عنوان درس"));
        }

        #endregion
    }
}

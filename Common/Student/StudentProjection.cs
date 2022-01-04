﻿using System;
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

        public override IQueryable Project(IQueryable<Student> inputs)
        {
            return from input in inputs
                   select input;

        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Field1", "Student_Field1"));
        }

        #endregion
    }
}

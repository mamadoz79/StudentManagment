using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;

namespace SystemGroup.Retail.StudentManagement.Common
{
    [Serializable]
    [DetailOf(typeof(Term), "TermRef")]
    [AssociatedWith(typeof(Course), nameof(CourseRef), AssociationType.ManyToOne)]
    partial class TermCourse : Entity
    {
        public string CourseTitle { get; set; }
        public string TeacherTitle { get; set; }

        #region Methods

        public override string GetEntityName()
        {
            return "TermCourse_EntityName"; //TODO
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            //columns.Add(new TextColumnInfo("Number", "TermCourse_Number"));
        }

        #endregion
    }
}

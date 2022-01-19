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
    [DetailOf(typeof(Course), "CourseRef")]
    [AssociatedWith(typeof(Student), nameof(StudentRef), AssociationType.ManyToOne)]

    partial class CourseStudent : Entity
    {
        
        #region Methods

        public override string GetEntityName()
        {
            return "دانشجویان درس"; //TODO
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            columns.Add(new ReferenceColumnInfo(nameof(CourseRef), "درس"));            
            columns.Add(new ReferenceColumnInfo(nameof(StudentRef), "دانشجو"));
        }
        #endregion
    }
}

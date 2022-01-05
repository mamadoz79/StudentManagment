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
    [Master(typeof(IStudentBusiness))]
    [DataNature(DataNature.MasterData)]
    [SearchFields("Code", "LastName")]
    partial class Student : Entity
    {
        #region Methods

        public override string GetEntityName()
        {
            return "Student_EntityName"; //TODO
        }
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            columns.Add(new TextColumnInfo(nameof(Code), "SystemGroup.Retail.StudentManagement:Student_Code"));
            columns.Add(new TextColumnInfo(nameof(FirstName), "Student_FirstName"));
            columns.Add(new TextColumnInfo(nameof(LastName), "Student_LastName"));
            columns.Add(new DateTimeColumnInfo(nameof(BirthDate), "Student_BirthDate"));
            columns.Add(new LookupColumnInfo(nameof(Gender), "Student_Gender", nameof(StudentGender)));
        }

        #endregion
    }
}

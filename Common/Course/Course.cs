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
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement;
using SystemGroup.General.PartyManagement.Common;

namespace SystemGroup.Retail.StudentManagement.Common
{
    [Serializable]
    [Master(typeof(ICourseBusiness))]
    [SearchFields("Name")]
    [DataNature(DataNature.MasterData)]
    [AssociatedWith(typeof(IUserInfo), nameof(Creator), AssociationType.ManyToOne)]
    [AssociatedWith(typeof(IUserInfo), nameof(LastModifier), AssociationType.ManyToOne)]
    partial class Course : Entity, ITrackedEntity
    {
        #region Methods

        public override string GetEntityName() => "Course_Course";
        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new TextColumnInfo(nameof(Name), "عنوان درس"));
            columns.Add(new ReferenceColumnInfo(nameof(TeacherRef), "مدرس"));
            columns.Add(new ReferenceColumnInfo("Creator", "ایجاد کننده"));
            columns.Add(new DateTimeColumnInfo("CreationDate", "تاریخ ایجاد"));
            columns.Add(new ReferenceColumnInfo("LastModifier", "اخرین ویرایشگر"));
            columns.Add(new DateTimeColumnInfo("LastModificationDate", "تاریخ اخرین ویرایش"));

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.MetaData;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Security;
using SystemGroup.General.PartyManagement.Common;

namespace SystemGroup.Retail.StudentManagement.Common
{
    [Serializable]
    [Master(typeof(ITermBusiness))]
    [SearchFields("ID")]
    [DataNature(DataNature.MasterData)]
    [AssociatedWith(typeof(IUserInfo), nameof(Creator), AssociationType.OneToOne)]
    [AssociatedWith(typeof(IUserInfo), nameof(LastModifier), AssociationType.OneToOne)]
    partial class Term : Entity, ITrackedEntity
    {
        #region Methods

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);

            columns.Add(new ReferenceColumnInfo("ID", "کد ترم"));
            columns.Add(new DateTimeColumnInfo("StartDate", "تاریخ شروع"));
        }

        public override void SetDefaultValues()
        {
            base.SetDefaultValues();
            StartDate = DateTime.Today;
        }

        #endregion
    }
}

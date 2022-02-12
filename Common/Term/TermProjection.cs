using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Framework.Common;

namespace SystemGroup.Retail.StudentManagement.Common
{
    class TermProjection : EntityProjection<Term>
    {
        public override IQueryable Project(IQueryable<Term> terms)
        {
            return from term in terms
                   select new
                   {
                       term.ID,
                       term.StartDate
                   };
        }

        public override void GetColumns(List<ColumnInfo> columns)
        {
            base.GetColumns(columns);
            columns.Add(new EntityColumnInfo<Term>("StartDate"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;

namespace SystemGroup.Retail.StudentManagement.Common
{
    [ServiceInterface]
    public interface IStudentBusiness : IBusinessBase<Student>
    {
        [EntityView("AllStudents", "همه دانشجوها", typeof(StudentProjection), "Code", IsDefaultView = true)]
        [EntityView("AllStudentNames", "نام همه دانشجوها", typeof(StudentNameProjection), "Name", IsDefaultView = true)]
        new IQueryable<Student> FetchAll();
    }
}

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
    public interface ICourseBusiness : IBusinessBase<Course>
    {
        [EntityView("AllCourse", "درسها", typeof(CourseProjection), "Name", IsDefaultView = true)]
        new IQueryable<Course> FetchAll();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Service.Attributes;
using SystemGroup.Retail.StudentManagement.Common;


namespace SystemGroup.Retail.StudentManagement.Business
{
    [Service]
    public class CourseBusiness : BusinessBase<Course>, ICourseBusiness
    {
    }
}

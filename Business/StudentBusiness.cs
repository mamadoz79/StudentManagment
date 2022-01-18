using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Host;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Service.Attributes;
using SystemGroup.Retail.StudentManagement.Common;


namespace SystemGroup.Retail.StudentManagement.Business
{
    [Service]
    public class StudentBusiness : BusinessBase<Student>, IStudentBusiness
    {

        [SubscribeTo(typeof(IHostService), nameof(IHostService.HostStarted))]
        private void OnHostStarted(object sender, EventArgs e)
        {
            //Framework.Logging.SgLogger.LogDebug(" ** Student Busindess is loaded!");
            //var s = new Student
            //{
            //    ID = -1,
            //    Code = "0987654321",
            //    FirstName = "Salam",
            //    LastName = "L",
            //    BirthDate = DateTime.Now.AddYears(-25),
            //    Gender = StudentGender.Female
            //};

            //Save(ref s);

            //Framework.Logging.SgLogger.LogDebug($"*** Student with id {s.ID} has been saved!");
        }
    }
}

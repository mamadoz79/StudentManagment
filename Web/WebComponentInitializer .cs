using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Service;

using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Retail.StudentManagement.Web.CoursePages;
using SystemGroup.Web;
using SystemGroup.Web.ApplicationServices;
using SystemGroup.Web.UI.Shell;
using static System.WebComponentInitializerHelper;


namespace SystemGroup.Retail.StudentManagement.Web
{
    public class WebComponentInitializer : WebComponentInitializerBase
    {

        #region Student Entity Actions

        [AddNewEntityAction(typeof(Student))]
        public void AddNewStudent()
        {
            SgShell.Show<StudentPages.Edit>();
        }

        [ViewDetailEntityAction(typeof(Student))]
        public void ViewDetailsOfStudent(long[] ids)
        {
            foreach (var id in ids)
                SgShell.Show<StudentPages.Edit>($"id={id}");
        }

        [DeleteEntityAction(typeof(Student))]
        public void DeleteStudent(long[] ids)
        {
            ServiceFactory.Create<IStudentBusiness>().Delete(ids);
        }

        #endregion

        #region Course Entity Actions

        [AddNewEntityAction(typeof(Course))]
        public void AddNewCourse()
        {
            SgShell.Show<CourseEdit>();
        }

        [ViewDetailEntityAction(typeof(Course))]
        public void ViewDetailsOfCourse(long[] ids)
        {
            foreach (var id in ids)
                SgShell.Show<CourseEdit>($"id={id}");
        }

        [DeleteEntityAction(typeof(Course))]
        public void DeleteCourse(long[] ids)
        {
            ServiceFactory.Create<ICourseBusiness>().Delete(ids);
        }

        #endregion

        public override List<ComponentLink> RegisterLinks()
        {
            return new List<ComponentLink>
            {
                new ComponentLink("UniversityManagement", "Labels_UniversityManagement", null, null, 5, new ComponentLink[] {
                    new ComponentLink("StudentManagement", "Labels_StudentManagement", null, null, 1, new ComponentLink[] {
                        new ComponentLink( "Lists", "Labels_Lists", null, null, 1, new ComponentLink[]
                        {
                            ListLink<Student>(null, null, 1),
                            ListLink<Course>(null, null, 1),
                        }),
                        PageLink<StudentPages.Edit>(null, null, 1),
                        PageLink<CourseEdit>(null, null, 2)
                    })
                })
            };
        }
    }
}
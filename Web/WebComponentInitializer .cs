﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Service;
using SystemGroup.Retail.Structure.Web;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web;
using SystemGroup.Web.ApplicationServices;
using SystemGroup.Web.UI.Shell;

namespace SystemGroup.Retail.StudentManagement.Web
{
    public class WebComponentInitializer : WebComponentInitializerBase
    {

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



        public override List<ComponentLink> RegisterLinks()
        {
            return new List<ComponentLink>
            {
                new ComponentLink("UnversityManagement", new ComponentLink[] {
                    new ComponentLink("StudentManagement", new ComponentLink[] {
                        new ComponentLink( "Lists", new ComponentLink[]
                        {
                            WebComponentInitializerHelper.ListLink<Student>(null, null, 1),
                        }),
                        WebComponentInitializerHelper.PageLink<StudentPages.Edit>(null, null, 1)

                    })
                })
            };
        }
    }
}
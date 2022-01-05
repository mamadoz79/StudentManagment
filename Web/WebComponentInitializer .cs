using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Retail.Structure.Web;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web;
using SystemGroup.Web.UI.Shell;

namespace SystemGroup.Retail.StudentManagement.Web
{
    public class WebComponentInitializer : WebComponentInitializerBase
    {
        public override List<ComponentLink> RegisterLinks()
        {
            return new List<ComponentLink>
            {
                new ComponentLink("StudentManagement", new ComponentLink[] {
                    new ComponentLink("StudentManagement", new ComponentLink[] {
                        new ComponentLink( "Lists", new ComponentLink[]
                        {
                            WebComponentInitializerHelper.ListLink<Student>(null, null, 1),
                        }),
                    })
                })
            };
        }
    }
}
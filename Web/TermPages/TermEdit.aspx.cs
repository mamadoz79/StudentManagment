using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.General.PartyManagement.Common;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;

namespace SystemGroup.Retail.StudentManagement.Web.TermPages
{
    public partial class TermEdit : SgEditorPage<Term>
    {
        #region Properties

        public override SgFormView FormView
        {
            get { return null; }
        }

        public override SgUpdatePanel UpdatePanel
        {
            get { return updMain; }
        }

        public override bool HasFormView
        {
            get
            {
                return false;
            }
        }

        public override Control MainContentContainer
        {
            get
            {
                return dvMain;
            }
        }

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return ".TermCourses";
            }
        }
        public override DetailLoadOptions EntityLoadOptions => LoadOptions.With<Term>(i => i.TermCourses);

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);
            var teacherRefs = CurrentEntity.TermCourses.Select(i => i.TeacherRef).ToList();
            var courseRefs = CurrentEntity.TermCourses.Select(i => i.CourseRef).ToList();

            var courseNames = ServiceFactory.Create<ICourseBusiness>().FetchAll()
                .Where(i => courseRefs.Contains(i.ID))
                .Select(i => new { i.ID, i.Name })
                .ToDictionary(i => i.ID, v => v.Name);

            var names = ServiceFactory.Create<IPartyManagementExtendedService>().FetchAllPartiesFullInfo()
                .Where(i => teacherRefs.Contains(i.ID))
                .Select(i => new { i.ID, i.FullName })
                .ToDictionary(i => i.ID, v => v.FullName);

            foreach (var courseName in CurrentEntity.TermCourses)
            {
                courseName.CourseTitle = courseNames[courseName.CourseRef];
            }

            foreach (var courseStudent in CurrentEntity.TermCourses)
            {
                courseStudent.TeacherTitle = names[courseStudent.TeacherRef];
            }
        }

        #endregion

        #region Methods

        protected override void OnEditorBinding(EditorBindingEventArgs<Term> e)
        {
            base.OnEditorBinding(e);

            e.Context.BindValueTypeProperty(t => t.StartDate).To(dpStartDate);
        }

        #endregion
    }
}
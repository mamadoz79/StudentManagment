using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Party;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Pages.EditorPage;
using SystemGroup.Web.UI.Views;
using SystemGroup.Web.UI.Views.Pages;

namespace SystemGroup.Retail.StudentManagement.Web.CoursePages
{
    public class CourseEdit : SgEditorView<Course>
    {

        private SgTextBox txtName;
        private SgSelector sltTeachers;
        private SgGrid grdStudents;
        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Course> context)
        {
            context.BindProperty(c => c.Name).To(txtName);
            context.BindValueTypeProperty(c => c.TeacherRef).To(sltTeachers);
        }
        // protected override IEnumerable<string> ClientSideDetailDataSources => new string[] { ".CourseStudents" };
        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return "." + nameof(Course.CourseStudents);
            }
        }

        public override DetailLoadOptions EntityLoadOptions => LoadOptions.With<Course>(i => i.CourseStudents);

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);
            var n = CurrentEntity.CourseStudents.Count;
            System.Diagnostics.Debug.WriteLine($"{CurrentEntity.Name} has {n} students");
        }

        protected override void OnCreateViews()
        {
            ViewPlaceHolder page = GetMainPlaceHolder();

            var fs = page.Add<FieldSetView>().Width(500);
          
            DynamicFieldLayoutView header = fs.Add<DynamicFieldLayoutView>()                                                
                .NumberOfColumns(1)
                .Width(200)
                .LabelCellWidth(50)
                .InputCellWidth(100)
                .ValidationCellWidth(20);

            var rowName = header.AddRow();
            rowName.SetLabel("نام");
            rowName.SetInput<TextBoxView>().ID("txtName").RealizedIn(() => txtName).Width(90);
            rowName.SetRequiredValidator();

            var rowTeacher = header.AddRow();
            rowTeacher.SetLabel("مدرس");
            rowTeacher.SetInput<SelectorView>().ID("sltTeacher")
                .RealizedIn(() => sltTeachers).Width(90)
                .EntityView<IParty>("AllPartiesOfTypePersonSimple");
            rowTeacher.SetRequiredValidator();

            var details = page.Add<TabView>();
            var studentsTab = details.AddTab().TabText("دانشجویان درس");
            var grid = studentsTab.Add<GridView<CourseStudent>>().ID("grdStudents")
                .RealizedIn(() => grdStudents).DataSourceID(".CourseStudents").AllowScroll(true)
                .AllowEdit(true).AllowDelete(true).AllowInsert(true).GridType(SgGridType.ClientSide).Width(789);

            grid.Columns.AddSelector().UniqueName("students").Width(120).HeaderText("دانشجو")
                .Property(i => i.StudentName)
                .Closure(clm => 
                {
                    var selector = clm.EditItemTemplate.Add<SelectorView>()
                      .ID("sltStudents")
                      .EntityView<Student>("AllStudentNames")
                      .CbSelectedID(grid.CreateCB(s => s.StudentRef).TwoWay())
                      .CbSelectedText(grid.CreateCB(s => s.StudentName));                    
                });

        }
    }
}
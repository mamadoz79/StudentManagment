using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Party;
using SystemGroup.Framework.Service;
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
        private SgGrid grdStudents;
        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Course> context)
        {
            context.BindProperty(c => c.Name).To(txtName);
        }
        // protected override IEnumerable<string> ClientSideDetailDataSources => new string[] { ".CourseStudents" };
        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {
                yield return "." + nameof(Course.CourseStudents);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ScriptManager.Scripts.Add(new System.Web.UI.ScriptReference("CourseEdit.js"));
        }

        public override DetailLoadOptions EntityLoadOptions => LoadOptions.With<Course>(i => i.CourseStudents);

        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);

            var studentRefs = CurrentEntity.CourseStudents.Select(i => i.StudentRef).ToList();
            
            Dictionary<long, string> names = ServiceFactory.Create<IStudentBusiness>().FetchAll()
                .Where(i => studentRefs.Contains(i.ID))
                .Select(i => new { i.ID, Name = i.FirstName + "  " + i.LastName })
                .ToDictionary(i => i.ID, v => v.Name);
            
            foreach (var courseStudent in CurrentEntity.CourseStudents)
            {                
                courseStudent.StudentName = names[courseStudent.StudentRef];
            }

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

            var details = page.Add<TabView>();
            var studentsTab = details.AddTab().TabText("دانشجویان درس");
            
            var grid = studentsTab.Add<GridView<CourseStudent>>()
                .ID("grdStudents")
                .RealizedIn(() => grdStudents)
                .DataSourceID(".CourseStudents")
                .AllowScroll(true)
                .AllowEdit(true).AllowDelete(true).AllowInsert(true)
                .GridType(SgGridType.ClientSide)
                .Width(789);

            grid.Columns.AddSelector().UniqueName("students").Width(120).HeaderText("دانشجو")
                .Property(i => i.StudentName)
                .Closure(clm => 
                {
                    var selector = clm.EditItemTemplate.Add<SelectorView>()
                      .ID("sltStudents")
                      .EntityView<Student>("AllStudentNames")
                      .CbSelectedID(grid.CreateCB(s => s.StudentRef).TwoWay())
                      .CbSelectedText(grid.CreateCB(s => s.StudentName))
                      .OnClientItemsRequesting("sltStudent_OnClientItemsRequesting")
                      .OnItemsRequested((s, e) => {
                          var slt = (SgSelector)s;
                          var ignoredIDs = ((IEnumerable)e.Context["IgnoredIDs"]).
                              Cast<object>().
                              Select(o => Convert.ToInt64(o)).
                              ToList();
                          slt.FilterExpression = o => !ignoredIDs.Contains(((Entity)o).ID);

                      });
                });
        }
    }
}
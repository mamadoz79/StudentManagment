using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemGroup.Framework.Party;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Pages.EditorPage;
using SystemGroup.Web.UI.Views;
using SystemGroup.Web.UI.Views.Pages;

namespace SystemGroup.Retail.StudentManagement.Web.CoursePages
{
    public class Edit : SgEditorView<Course>
    {

        private SgTextBox txtName;
        private SgSelector sltTeachers;

        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Course> context)
        {
            context.BindProperty(c => c.Name).To(txtName);
            context.BindValueTypeProperty(c => c.TeacherRef).To(sltTeachers);
        }

        protected override void OnCreateViews()
        {
            ViewPlaceHolder page = GetMainPlaceHolder();

            var fs = page.Add<FieldSetView>().Width(800);
          
            DynamicFieldLayoutView header = fs.Add<DynamicFieldLayoutView>()                                
                .Add<DynamicFieldLayoutView>()
                .NumberOfColumns(2)
                .Width(786)
                .LabelCellWidth(80)
                .InputCellWidth(280)
                .ValidationCellWidth(20);

            var rowName = header.AddRow();
            rowName.SetLabel("نام");
            rowName.SetInput<TextBoxView>().ID("txtName").RealizedIn(() => txtName).Width(260);


            var rowTeacher = header.AddRow();
            rowTeacher.SetLabel("مدرس");
            rowTeacher.SetInput<SelectorView>().ID("sltTeacher")
                .RealizedIn(() => sltTeachers)
                .EntityView<IParty>("AllPartiesOfTypePersonSimple");

        }
    }
}
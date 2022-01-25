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
    public class CourseEdit : SgEditorView<Course>
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

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
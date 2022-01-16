﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGroup.Retail.StudentManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;

namespace SystemGroup.Retail.StudentManagement.Web.StudentPages
{
    public partial class Edit : SgEditorPage<Student>
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);           
        }

        protected override void OnEditorBinding(EditorBindingEventArgs<Student> e)
        {
            base.OnEditorBinding(e);

            e.Context.BindProperty(i => i.Code).To(txtCode);
            e.Context.BindProperty(i => i.FirstName).To(txtFisrtName);
            e.Context.BindProperty(i => i.LastName).To(txtLastName);
            e.Context.BindValueTypeProperty(i => i.BirthDate).To(dtpBirthDate);
        }
        

        #endregion
    }
}
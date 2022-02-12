<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermEdit.aspx.cs" Inherits="SystemGroup.Retail.StudentManagement.Web.TermPages.TermEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" ID="scriptManager"></sg:SgScriptManager>
        <sg:SgUpdatePanel runat="server" ID="updMain">
            <ContentTemplate>
                <div runat="server" id="dvMain">
                    <sg:SgFieldSet runat="server">
                        <sg:SgFieldLayout runat="server" ValidationCellWidth="20px" InputCellWidth="250px" LabelCellWidth="100px">
                            <sg:SgTableRow runat="server">
                                <sg:SgTableCell runat="server">
                                    <sg:SgFieldLabel runat="server" Text="تاریخ شروع" Required="true" />
		                        </sg:SgTableCell>
                                <sg:SgTableCell runat="server">
                                    <sg:SgDatePicker runat="server" ID="dpStartDate" />
		                        </sg:SgTableCell>
                                <sg:SgTableCell runat="server">
                                    <sg:SgRequiredFieldValidator runat="server" ControlToValidate="dpStartDate" ErrorMessage="تاریخ را وارد کنید" />
		                        </sg:SgTableCell>
                            </sg:SgTableRow>
                        </sg:SgFieldLayout>
                    </sg:SgFieldSet>
                </div>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>

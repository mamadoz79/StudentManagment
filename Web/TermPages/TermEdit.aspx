<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TermEdit.aspx.cs" Inherits="SystemGroup.Retail.StudentManagement.Web.TermPages.TermEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <sg:SgScriptManager runat="server" ID="scriptManager">
            <Scripts>
            <asp:ScriptReference Path="TermEdit.js" />
        </Scripts>
        </sg:SgScriptManager>
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
                    <sg:SgFieldSet runat="server" Legend="واحد ها">
                        <sg:SgGrid ID="grdTermCourse" runat="server" Width="780px" ContentWidth="1280px" Height="120px"
                            DataSourceID=".TermCourses" GridType="ClientSide" ValidationGroup="grdCourses" AllowScroll="true">
                            <Columns>
                                <sg:SgSelectorGridColumn PropertyName="CourseTitle" HeaderText="درس">
                                    <EditItemTemplate>
                                        <sg:SgSelector runat="server" ComponentName="SystemGroup.Retail.StudentManagement"
                                            EntityName="Course" ViewName="AllCourse" CbSelectedID="{binding CourseRef}"
                                            ID="sltCourse"
                                            CbSelectedText="{binding CourseTitle}" OnClientSelectedIndexChanged="sltCourse_selectedIndexChanged">
                                         </sg:SgSelector>
                                    </EditItemTemplate>
                                </sg:SgSelectorGridColumn>
                                
                                <sg:SgSelectorGridColumn PropertyName="TeacherTitle" HeaderText="مدرس">
                                    <EditItemTemplate>
                                        <sg:SgSelector runat="server" ComponentName="SystemGroup.General.PartyManagement"
                                            EntityName="Party" ViewName="AllPartiesOfTypePersonSimple" CbSelectedID="{binding TeacherRef}"
                                            ID="sltTeacher"
                                            CbSelectedText="{binding TeacherTitle}" OnClientSelectedIndexChanged="sltCourse_selectedIndexChanged">
                                         </sg:SgSelector>
                                    </EditItemTemplate>
                                </sg:SgSelectorGridColumn>

                            </Columns>
                        </sg:SgGrid>
                    </sg:SgFieldSet>
                </div>
            </ContentTemplate>
        </sg:SgUpdatePanel>
    </form>
</body>
</html>

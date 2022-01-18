<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
	Inherits="SystemGroup.Retail.StudentManagement.Web.StudentPages.Edit"
	Title="Student_Student" %>

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
						<sg:SgFieldLayout runat="server">
							<sg:SgTableRow runat="server">
								<sg:SgTableCell runat="server">
									<sg:SgFieldLabel runat="server" TextKey="Student_Code" Required="true" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgTextBox runat="server" ID="txtCode" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtCode" ErrorMessage="عنوان را وارد کنید." />
								</sg:SgTableCell>
							</sg:SgTableRow>

							<sg:SgTableRow runat="server">
								<sg:SgTableCell runat="server">
									<sg:SgFieldLabel runat="server" TextKey="Student_FirstName" Required="true" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgTextBox runat="server" ID="txtFisrtName" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtFisrtName" ErrorMessage="عنوان را وارد کنید." />
								</sg:SgTableCell>
							</sg:SgTableRow>

							<sg:SgTableRow runat="server">
								<sg:SgTableCell runat="server">
									<sg:SgFieldLabel runat="server" TextKey="Student_LastName" Required="true" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgTextBox runat="server" ID="txtLastName" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtLastName" ErrorMessage="عنوان را وارد کنید." />
								</sg:SgTableCell>
							</sg:SgTableRow>

							<sg:SgTableRow runat="server">
								<sg:SgTableCell runat="server">
									<sg:SgFieldLabel runat="server" TextKey="Student_BirthDate" Required="true" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgDatePicker runat="server" ID="dtpBirthDate" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgRequiredFieldValidator runat="server" ControlToValidate="txtLastName" ErrorMessage="عنوان را وارد کنید." />
								</sg:SgTableCell>
							</sg:SgTableRow>

							<sg:SgTableRow runat="server">
								<sg:SgTableCell runat="server">
									<sg:SgFieldLabel runat="server" TextKey="Student_Gender" Required="true" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgLookup runat="server" ID="lkpGender" LookupType="StudentGender" />
								</sg:SgTableCell>
								<sg:SgTableCell runat="server">
									<sg:SgRequiredFieldValidator runat="server" ControlToValidate="lkpGender" ErrorMessage="عنوان را وارد کنید." />
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

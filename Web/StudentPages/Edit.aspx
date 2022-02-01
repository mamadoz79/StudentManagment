<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs"
	Inherits="SystemGroup.Retail.StudentManagement.Web.StudentPages.Edit"
	Title="Student_Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>دانشجو</title>
</head>
<body>
	<form id="form1" runat="server">
		<sg:SgScriptManager runat="server" ID="scriptManager">
			<Scripts>
				<asp:ScriptReference Path="StudentEdit.js" />
			</Scripts>
		</sg:SgScriptManager>
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

					 <sg:SgTabStrip ID="tbsTab" runat="server" MultiPageID="mpgMultiPage">
                        <Tabs>
                            <sg:SgTab runat="server" Text="مشخصات" PageViewID="rpvSpec" />                            
                        </Tabs>
                    </sg:SgTabStrip>

                    <sg:SgMultiPage ID="mpgMultiPage" runat="server">
                        <telerik:RadPageView ID="rpvSpec" runat="server">
                             
							<sg:SgGrid runat="server" ID="grdSpecs" GridType="ClientSide" AllowScroll="true"
                                    AllowEdit="true" AllowDelete="true" AllowInsert="true"
	                                Width="780px" DataSourceID="dsSpecs" >
								<Columns>
									<sg:SgTextGridColumn HeaderText="نام مشخصه" PropertyName="Name" AllowEdit="true"></sg:SgTextGridColumn>									
									<sg:SgTextGridColumn HeaderText="مقدار مشخصه" PropertyName="Value" AllowEdit="true"></sg:SgTextGridColumn>
									
									<sg:SgSelectorGridColumn PropertyName="OrganizaionUnitName" 
                                           HeaderText="واحد سازمانی" >
			                               <EditItemTemplate>
			                                    <sg:SgSelector runat="server" ID="sltOrgUnits"
													ComponentName="SystemGroup.Workflow.OrganizationModeling"
													EntityName="OrganizationUnit"
													ViewName="AllOrganizationUnits"
													CbSelectedID="{binding OrganizationUnitRef}"
													OnClientSelectedIndexChanged="sltOrgUnits_selectedIndexChanged"
                                                    OnClientItemsRequesting="sltOrgUnits_itemRequesting"
                                                    OnItemsRequested="sltOrgUnits_ItemsRequested">
			                                    </sg:SgSelector>
											 </EditItemTemplate>
										</sg:SgSelectorGridColumn>
								</Columns>
							</sg:SgGrid>

						</telerik:RadPageView>
					</sg:SgMultiPage>

				</div>
			</ContentTemplate>
		</sg:SgUpdatePanel>
	</form>
</body>
</html>

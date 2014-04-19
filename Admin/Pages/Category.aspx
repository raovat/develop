<%@ Page Title="Quản lý danh mục" Language="C#" MasterPageFile="~/Layout/Admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Admin.Pages.Category" %>

<%@ Register Namespace="LibCore.Helper" Assembly="LibCore" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Quản lý danh mục</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <asp:ScriptManager ID="scriptMN" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="uplPageCategory" runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ID" EnableModelValidation="True" CssClass="table table-bordered table-striped"
                     OnRowDataBound="grvData_RowDataBound" OnRowUpdating="grvData_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="STT" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("row") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên danh mục">
                            <ItemTemplate>
                                <p>
                                    <asp:ImageButton ID="btnToggle" runat="server" CommandName="Update" ImageUrl="/Images/plus.png"
                                      CssClass="toggle"  /><strong><asp:Label ID="Label2" runat="server" Text='<%# Eval("cateName")%>'></asp:Label></strong>
                                </p>
                                <span style="font-size: 10px; line-height: 18px;">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></span>
                                <asp:Repeater ID="rptSubCate" runat="server" OnItemCommand="rptSubCate_ItemCommand">
                                    <ItemTemplate>
                                        <div class="row" style="margin-left: 35px;">
                                            <div class="col-md-5">
                                                <asp:ImageButton ID="btnToggle" runat="server" ImageUrl="/Images/minus.png"
                                                    CssClass="toggle" /><%#Eval("cateName")%>
                                            </div>
                                            <div class="col-md-3">
                                                <a href='Default.aspx?module=Category&ID=<%#Eval("ID") %>'>
                                                    <img src="/Images/edit.png" title="Sửa" /></a>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="/Images/del.png"
                                                    CommandName="Delete" CommandArgument='<%#Eval("ID") %>' ToolTip="Xóa" CausesValidation="false"
                                                    OnClientClick="return confirm('Bạn có muốn xóa danh mục này không?');" />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Order" HeaderText="Thứ tự hiển thị" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sửa" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href='Default.aspx?module=Category&ID=<%#Eval("ID") %>'>
                                    <img src="/Images/edit.png" title="Sửa" /></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Xóa">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("ID") %>'
                                    ImageUrl="/Images/del.png" CausesValidation="False" OnClientClick="return confirm('Bạn có muốn xóa danh mục này không?');" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <cc:Bjzj_2sGroup_Pager ID="pagerCate" runat="server" OnCommand="pagerCate_Command"></cc:Bjzj_2sGroup_Pager>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="pagerCate" EventName="Command" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

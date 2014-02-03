<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfileInfo.aspx.cs" Inherits="WebApplication1.Account.EditProfileInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="row">
        <div class="col-md-12">
            <section id="passwordForm">
                <asp:PlaceHolder runat="server" ID="setPassword" Visible="true">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="firstName" CssClass="col-md-2 control-label">First Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="firstName" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="lastName" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="EditProfile" runat="server" Text="Edit" ValidationGroup="SetPassword" OnClick="EditProfileInfo_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>
        </div>
     </div>

</asp:Content>

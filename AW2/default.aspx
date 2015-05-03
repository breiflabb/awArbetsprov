<%@ Page Title="" Language="C#" MasterPageFile="~/aw2Master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AW2._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row">
            <h1>Message flow</h1>
        </div>
         <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnNew" runat="server" Text="Newest first" CssClass="btn btn-custom" OnClick="btnNew_Click"/>
                <asp:Button ID="btnOld" runat="server" Text="Oldest first" CssClass="btn btn-custom" OnClick="btnOld_Click" />
                <asp:Button ID="btnRnd" runat="server" Text="Random order" CssClass="btn btn-custom" OnClick="btnRnd_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <hr class="ruler" />
    </div>

    
    <asp:Panel ID="panelMessages" runat="server">
     


    </asp:Panel>

</asp:Content>

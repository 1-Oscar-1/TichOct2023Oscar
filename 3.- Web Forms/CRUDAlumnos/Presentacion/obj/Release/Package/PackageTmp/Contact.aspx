<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Presentacion.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Dirección</h3>
        <address>
            Lago Ximilpa 173<br />
            Pensil Norte<br />
            <abbr title="Phone">P:</abbr>
            55-87-16-06-18
        </address>

        <address>
            <strong>Contacto:</strong>   <a href="mailto:contacto@ticapitalhumano.com">contacto@ticapitalhumano.com</a><br />
            <strong>Comercial:</strong> <a href="mailto:comercial@ticapitalhumano.com">comercial@ticapitalhumano.com</a>
        </address>
    </main>
</asp:Content>

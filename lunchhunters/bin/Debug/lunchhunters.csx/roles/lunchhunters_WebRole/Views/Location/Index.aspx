<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lunchhunters.Models.Location.IndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <table>
        <tr>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model.Places)
           { %>
        <tr>
            <th>
                <%= Html.ActionLink(item.Name, MVC.Location.Details(item.ID,false)) %>
            </th>
        </tr>
        <tr>
            <td>
                <%= Html.ActionLink("Edit", MVC.Location.Details(item.ID,true)) %>
                |
            </td>
        </tr>
        <% } %>
        <tr>
            <th>
                <%if (Model.Places.BackAvailable)
                  { %>
                    <a href="javascript:history.go(-1)">Previous Page</a>
                <%} %>
                <%if (Model.Places.BackAvailable && Model.Places.NextAvailable)
                  { %>
                |
                <%} %>
                <%if (Model.Places.NextAvailable)
                  { %>
                <%= Html.ActionLink("Next Page", MVC.Location.Index(10,Model.Places.NextPartition,Model.Places.NextRow)) %>
                <%} %>
            </th>
        </tr>
    </table>
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>

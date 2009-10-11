<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lunchhunters.Models.Location.DetailsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>

    <script type="text/javascript">
        function initialize() {
            var lat = $("#lat").val();
            var lng = $("#lng").val();
            var name = $("#name").val();
            var latlng = new google.maps.LatLng(lat, lng);
            var myOptions = {
                zoom: 16,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            var marker = new google.maps.Marker({
                position: latlng,
                map: map,
                title: name
            });
        }
        $(document).ready(function() { initialize(); });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%=Model.Place.Name %></h2>
    
        <%=Html.Hidden("name",Model.Place.Name) %>
        <%=Html.Hidden("lat",Model.Place.Latitude) %>
        <%=Html.Hidden("lng",Model.Place.Longitude) %>

    <fieldset>
        <legend>Fields</legend>
        <%=Model.Place.Name %>
        <div id="map_canvas" style="width: 300px; height: 300px">
    </div>

    </fieldset>
    
    <p>
        <%=Html.ActionLink("Edit", MVC.Location.Details(Model.Place.ID,true)) %> |
        <%=Html.ActionLink("Back to List", MVC.Location.Index()) %>
    </p>

</asp:Content>


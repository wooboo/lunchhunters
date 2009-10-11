<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<lunchhunters.Models.Location.DetailsViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
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
                title: name,
                draggable: true
            });
            google.maps.event.addListener(marker, 'position_changed', function() {
                var newLngLat = marker.get_position();
                $("#lat").val(newLngLat.lat());
                $("#lng").val(newLngLat.lng());
                
            });
        }
        $(document).ready(function() { initialize(); });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm(MVC.Location.Actions.Save, MVC.Location.Name))
       {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <%=Html.Hidden("id",Model.Place.ID) %>
        </p>
        <%=Html.TextBox("name",Model.Place.Name) %><br />
        <%=Html.Hidden("lat",Model.Place.Latitude) %>
        <%=Html.Hidden("lng",Model.Place.Longitude) %>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <div id="map_canvas" style="width: 300px; height: 300px" >
    </div>
    <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

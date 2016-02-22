$(document).ready(function () {
    Initialize();
    $('#testDBtable').DataTable();
    $('#dropdownTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });
    
})
//This code tells the browser to execute the "Initialize" method only when the complete document model has been loaded.


// Where all the fun happens
function Initialize() {

    // Google has tweaked their interface somewhat - this tells the api to use that new UI
   // google.maps.visualRefresh = true;
    var Athlone = new google.maps.LatLng(53.4232693, -7.9490146);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 8,
        center: Athlone,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    // This shows adding a simple pin "marker" - this happens to be the Tate Gallery in Liverpool!
    var myLatlng = new google.maps.LatLng(53.40091, -2.994464);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Tate Gallery'
    });

    // You can make markers different colors...  google it up!
    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/green-dot.png')

    //// a sample list of JSON encoded data of places to visit in Liverpool, UK
    //// you can either make up a JSON list server side, or call it from a controller using JSONResult
    //var data = [
    //          { "Id": 1, "PlaceName": "Liverpool Museum", "OpeningHours": "9-5, M-F", "GeoLong": "53.410146", "GeoLat": "-2.979919" },
    //          { "Id": 2, "PlaceName": "Merseyside Maritime Museum ", "OpeningHours": "9-1,2-5, M-F", "GeoLong": "53.401217", "GeoLat": "-2.993052" },
    //          { "Id": 3, "PlaceName": "Walker Art Gallery", "OpeningHours": "9-7, M-F", "GeoLong": "53.409839", "GeoLat": "-2.979447" },
    //          { "Id": 4, "PlaceName": "National Conservation Centre", "OpeningHours": "10-6, M-F", "GeoLong": "53.407511", "GeoLat": "-2.984683" }
    //];

    //// Using the JQuery "each" selector to iterate through the JSON list and drop marker pins
    //$.each(data, function (i, item) {
    //    var marker = new google.maps.Marker({
    //        'position': new google.maps.LatLng(item.GeoLong, item.GeoLat),
    //        'map': map,
    //        'title': item.PlaceName
    //    });

    //    // Make the marker-pin blue!
    //    marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

    //    // put in some information about each json object - in this case, the opening hours.
    //    var infowindow = new google.maps.InfoWindow({
    //        content: "<div class='infoDiv'><h2>" + item.PlaceName + "</h2>" + "<div><h4>Opening hours: " + item.OpeningHours + "</h4></div></div>"
    //    });

    //    // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked!
    //    google.maps.event.addListener(marker, 'click', function () {
    //        infowindow.open(map, marker);
    //    });

    //})
}
function PopulateMap() {
    var Athlone = new google.maps.LatLng(53.4232693, -7.9490146);

    // These are options that set initial zoom level, where the map is centered globally to start, and the type of map to show
    var mapOptions = {
        zoom: 8,
        center: Athlone,
        mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
    };

    // This makes the div with id "map_canvas" a google map
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    var n = document.getElementById("textSearch").value;
    alert(n);
    $.ajax({
        type: 'POST',
        url: '/Home/Drop',
        data: { name: n },
        success: function (data) {
            alert("success!!!");
            var items = '';
            $.each(data, function (i, item) {
                alert(item.Lat + "Bollocks");
                var marker = new google.maps.Marker({
                    'position': new google.maps.LatLng(item.Lat, item.Long),
                    'map': map,
                    'title': item.AddressToGeocode
                });

                // Make the marker-pin blue!
                marker.setIcon('http://maps.google.com/mapfiles/ms/icons/blue-dot.png')

                // put in some information about each json object - in this case, the opening hours.
                var infowindow = new google.maps.InfoWindow({
                    content: "<div><h2>" + item.RelationToHeadOfHousehold + "</h2>" + "<div><h4>Occupant: " + item.Forename + " " + item.Surname + "</h4></div></div>"
                });

                // finally hook up an "OnClick" listener to the map so it pops up out info-window when the marker-pin is clicked!
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
            })
        }
    })
}
﻿var map;
function initializeMap(mapsKey) {
    // Initialize the Azure Maps
    atlas.setSubscriptionKey(mapsKey);
    // Create the map instance
    map = new atlas.Map("mapDiv", {
        view: "Auto",
        center: [-111.58264854191678, 39.36143191547314],
        zoom: 13
    });

    navigator.geolocation.getCurrentPosition(function (position) {
        var userLocation = [-111.58264854191678, 39.36143191547314];
        map.setCamera({
            center: userLocation,
            zoom: 13
        });
    });
    var marker = new atlas.HtmlMarker({
        color: 'DodgerBlue',
        text: 'O',
        position: [- 111.583795, 39.360108],
        popup: new atlas.Popup({
            content: `<div style="padding:10px">You Are Here =)</div>`,
            pixelOffset: [0, -30]
        })
    });
    map.markers.add(marker);
    map.events.add('click', marker, () => {
        marker.togglePopup();
    });
}
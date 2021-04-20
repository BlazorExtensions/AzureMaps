let link,script;

window.blazorExtensionsAzureMaps = (() => {
    let dataSource = new atlas.source.DataSource();
    let map;
    let data;
    let currentLat;
    let currentLon;

    const setCssAndJs = version => {
        if (link === undefined) {
            link = document.createElement('link');
            document.head.insertBefore(link, document.head.firstChild);
            link.type = "text/css";
            link.rel = "stylesheet";
        }
        link.href = `https://atlas.microsoft.com/sdk/javascript/mapcontrol/${version}/atlas.min.css`;
        if (script === undefined) {
            script = document.createElement("script");
            document.head.insertAdjacentElement("beforeend",script);
        }
        script.src = `https://atlas.microsoft.com/sdk/javascript/mapcontrol/${version}/atlas.min.js`;
        return true;
    }

    const init = (mapName, subscriptionKey) => {

        atlas.setSubscriptionKey(subscriptionKey);

        if (map != null) map.dispose();
        map = new atlas.Map(mapName);
    };

    const setupMap = (subscriptionKey, latitude, longitude) => {

        init("map", subscriptionKey);
        map = new atlas.Map("map", {
            center: [longitude, latitude],
            zoom: zoom,
            language: "en-US"
        });

        map.events.add("ready", () => {

            point = new atlas.Shape(new atlas.data.Point([longitude, latitude]));

            //Create a HTML marker and add it to the map.
            var marker = new atlas.HtmlMarker({
                color: "DodgerBlue",
                text: "",
                position: [longitude, latitude],
                popup: new atlas.Popup({
                    content: `<a href="#" class="btn btn-primary"></a >`,
                    pixelOffset: [0, -30]
                })
            });

            map.markers.add(marker);

            //Add a click event to toggle the popup.
            map.events.add("click", marker, () => {
                marker.togglePopup();
            });
        });
    };

    const setLocation = async (subscriptionKey, searchAddress) => {

        const subscriptionKeyCredential = new atlas.service.SubscriptionKeyCredential(subscriptionKey);
        // Use subscriptionKeyCredential to create a pipeline
        const pipeline = atlas.service.MapsURL.newPipeline(subscriptionKeyCredential);

        // Construct the SearchURL object
        const searchUrl = new atlas.service.SearchURL(pipeline);
        await searchUrl.searchAddress(atlas.service.Aborter.timeout(10000), searchAddress)
            .then(response => {

                data = response.geojson.getFeatures();
                dataSource.add(data);

                const position = response.results[0].position;
                currentLat = response.results[0].position.lat;
                currentLon = response.results[0].position.lon;

            });

        setupMap(subscriptionKey, currentLat, currentLon);

    };

    const showPopup = (long, lat, text) => new atlas.data.Feature(
        new atlas.data.Point([long, lat]),
        {
            name: `[${text}]`
        });

    return {
        setCssAndJs,
        init,
        setupMap,
        setLocation,
        showPopup
    }
})();
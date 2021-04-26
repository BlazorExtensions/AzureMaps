import * as atlas from "azure-maps-control";
import * as mapsRest from "azure-maps-rest";


export class BlazorExtensionsAzureMaps {
  static link: any;
  static script:any;
  static dataSource:atlas.source.DataSource;
  static map: atlas.Map;
  static data: any;
  static zoom:number;
  static currentLat:number;
  static currentLon: number;

  static init(mapName:string, subscriptionKey:string) {

    atlas.setSubscriptionKey(subscriptionKey);

    if (this.map != null) this.map.dispose();
    this.map = new atlas.Map(mapName, {});
  };

  static setupMap(subscriptionKey: string, latitude: number, longitude: number) {

    this.init("map", subscriptionKey);
    this.map = new atlas.Map("map", {
      center: [longitude, latitude],
      zoom: this.zoom,
      language: "en-US"
    });

    this.map.events.add("ready", () => {

      const point = new atlas.Shape(new atlas.data.Point([longitude, latitude]));

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

      this.map.markers.add(marker);

      //Add a click event to toggle the popup.
      this.map.events.add("click", marker, () => {
        marker.togglePopup();
      });
    });
  };

  static async setLocation(subscriptionKey:string, searchAddress:string) {

    const subscriptionKeyCredential = new mapsRest.SubscriptionKeyCredential(subscriptionKey);
    // Use subscriptionKeyCredential to create a pipeline
    const pipeline = mapsRest.MapsURL.newPipeline(subscriptionKeyCredential);

    // Construct the SearchURL object
    const searchUrl = new mapsRest.SearchURL(pipeline);
    await searchUrl.searchAddress(mapsRest.Aborter.timeout(10000), searchAddress)
      .then((response:any) => {

        this.data = response.geojson.getFeatures();
        this.dataSource.add(this.data);

        const position = response.results[0].position;
        this.currentLat = response.results[0].position.lat;
        this.currentLon = response.results[0].position.lon;

      });

    this.setupMap(subscriptionKey, this.currentLat, this.currentLon);

  };

  static showPopup(long: number, lat: number, text:string) {
    const feature = new atlas.data.Feature(
      new atlas.data.Point([long, lat]),
      {
        name: `[${text}]`
      });
  } 
}

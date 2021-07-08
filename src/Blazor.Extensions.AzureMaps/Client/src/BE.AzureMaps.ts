import "../node_modules/azure-maps-control/dist/atlas.min.css";
import "../node_modules/azure-maps-drawing-tools/dist/atlas-drawing.min.css";
import * as atlas from "azure-maps-control";
import * as dtools from "azure-maps-drawing-tools";
// import * as mapsRest from "azure-maps-rest";

interface IDrawingManagerOptions extends dtools.DrawingManagerOptions {
  toolbar?: any;
  latitude: number;
  longitude: number;
  radius: number;
}

export class BEAzureMaps {
  private static _map: atlas.Map;
  private static _drawingManager: dtools.drawing.DrawingManager;
  private static _dataSource: atlas.source.DataSource;
  private static _tilesDataSource: atlas.source.DataSource;
  private static _polygonLayer: atlas.layer.PolygonLayer;

  static injectCss(css): void {
    /* create the link element */
    const linkElement = document.createElement("link");
    /* add attributes */
    linkElement.setAttribute("rel", "stylesheet");
    linkElement.setAttribute("href", css);
    /* attach to the document head */
    document.getElementsByTagName("head")[0].appendChild(linkElement);
  }

  static setSubscriptionKey(key: string): void {
    atlas.setSubscriptionKey(key);
  };

  static createMap(
    mapId: string,
    options: atlas.ServiceOptions &
    atlas.StyleOptions &
    atlas.UserInteractionOptions &
    (atlas.CameraOptions | atlas.CameraBoundsOptions)
  ): atlas.Map {
    this._map = new atlas.Map(mapId, options);
    return this._map;
  };

  static setCamera(options: atlas.CameraOptions):void {
    this._map.setCamera(options);
  }

  static addShape(
    options: IDrawingManagerOptions,
    id?: string,
    properties?: any
    ) {
    const shape = new atlas.Shape(new atlas.data.Point([options.longitude, options.latitude]), id, properties);

    this._drawingManager = new dtools.drawing.DrawingManager(this._map, options);

    this._dataSource = this._drawingManager.getSource();

    //Add shapes to the datasource.
    this._dataSource.add(shape);
  }

  static clearShapes() {
    if (this._dataSource) {
      this._dataSource.clear();
    }
    if (this._tilesDataSource) {
      this._tilesDataSource.clear();
    }
  }

  static clearTiles() {
    if (this._tilesDataSource) {
      this._tilesDataSource.clear();
    }
  }

  static getTiles() {
    if (this._drawingManager) {
      const source = this._drawingManager.getSource();
      const shapes = source.getShapes().filter(x => x.isCircle());
      if (shapes.length) {
        const coordinates = shapes[0].getCircleCoordinates();
        const tiles = [];
        coordinates.forEach(c => {
          tiles.push(this.getTile(c[0], c[1], 22));
        });
        if (tiles.length) {
          return tiles.map(cur => JSON.stringify(cur))
            .filter((cur, index, self) => self.indexOf(cur) == index)
            .map(cur => JSON.parse(cur));
        }
      }
    }
    return [];
  }

  static getTile(longitude:number, latitude:number, zoom:number) {
    const x = Math.floor((longitude + 180.0) / 360.0 * Math.pow(2.0, zoom));
    const y = Math.floor((1.0 - Math.log(Math.tan(latitude * Math.PI / 180.0) + 1.0 / Math.cos(latitude * Math.PI / 180.0)) / Math.PI) / 2.0 * Math.pow(2.0, zoom));
    return [x, y];
  }

  static addDrawingTools (
    map: atlas.Map,
    options: IDrawingManagerOptions
  ): void {
    if (options.toolbar) {
      options.toolbar = new dtools.control.DrawingToolbar(options.toolbar.options);
    }
    this._map.events.add("ready", () => new dtools.drawing.DrawingManager(this._map, options));
  };

  static addPolygon(datasourceId:string, coordinates: any, id:string, properties:any) {
    this._tilesDataSource = <atlas.source.DataSource>(this._map.sources.getById(datasourceId));
    if (!this._tilesDataSource) {
      this._tilesDataSource = new atlas.source.DataSource(datasourceId);
      this._map.sources.add(this._tilesDataSource);
    }
    
    //Create a polygon and add it to the data source.
    this._tilesDataSource.add(new atlas.Shape(
      new atlas.data.Feature(
        new atlas.data.Polygon([coordinates])
    )));

    //Create a polygon layer to render the filled in area of the polygon.
    this._polygonLayer = new atlas.layer.PolygonLayer(this._tilesDataSource, id, properties);

    //Add all layers to the map.
    this._map.layers.add([this._polygonLayer]);
  }
}

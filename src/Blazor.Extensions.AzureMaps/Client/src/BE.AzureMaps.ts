import * as atlas from "azure-maps-control";
import * as dtools from "azure-maps-drawing-tools";
// import * as mapsRest from "azure-maps-rest";

interface AzureMapsDrawingToolbar extends dtools.DrawingManagerOptions {
  toolbar?: any;
}

export class BEAzureMaps {
  private static _map: atlas.Map;

  static init(subscriptionKey: string): void {
    atlas.setSubscriptionKey(subscriptionKey);
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

  static addDrawingTools (
    map: atlas.Map,
    options: AzureMapsDrawingToolbar
  ): void {
    if (options.toolbar) {
      options.toolbar = new dtools.control.DrawingToolbar(options.toolbar.options);
    }
    this._map.events.add("ready", () => new dtools.drawing.DrawingManager(BEAzureMaps._map, options));
  };
}

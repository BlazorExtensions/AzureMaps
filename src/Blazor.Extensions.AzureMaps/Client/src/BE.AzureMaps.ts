import * as atlas from "azure-maps-control";
import * as dtools from "azure-maps-drawing-tools";
// import * as mapsRest from "azure-maps-rest";

const init = (subscriptionKey: string) => {
  atlas.setSubscriptionKey(subscriptionKey);
};

const createMap = (
  mapId: string,
  options: atlas.ServiceOptions &
    atlas.StyleOptions &
    atlas.UserInteractionOptions &
    (atlas.CameraOptions | atlas.CameraBoundsOptions)
): atlas.Map => {
  return new atlas.Map(mapId, options);
};

const addDrawingTools = (
  map: atlas.Map,
  options: dtools.DrawingManagerOptions
): dtools.drawing.DrawingManager => {
  return new dtools.drawing.DrawingManager(map, options);
};

export { init, createMap, addDrawingTools };

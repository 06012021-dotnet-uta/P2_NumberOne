import {Component, Output, OnInit, Input } from '@angular/core';
import Map from 'ol/Map';
import View from 'ol/View';
import OSM from 'ol/source/OSM';
import * as olProj from 'ol/proj';
import TileLayer from 'ol/layer/Tile';
import {defaults as defaultControls, MousePosition} from 'ol/control';
import { createStringXY } from 'ol/coordinate';
import Feature from 'ol/Feature';
import Circle from 'ol/geom/Circle';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import Style from 'ol/style/Style';

/*

Still a work in progress here

*/

@Component({
  selector: 'app-ol-coord-map',
  templateUrl: './ol-coord-map.component.html',
  styleUrls: ['./ol-coord-map.component.css']
})
export class OlCoordMapComponent implements OnInit {

  constructor() { }

  @Input() interactable: boolean = true;
  map: Map | null = null;
  radius: number = 10;
  @Output() selectedCoords: number[] = [];

  circleFeature = new Feature({
    geometry: new Circle([12127398.797692968, 4063894.123105166], 50),
  });

  mousePositionControl = new MousePosition({
    coordinateFormat: createStringXY(4),
    projection: 'EPSG:4326'
  })

  ngOnInit(){    
    this.circleFeature.setStyle(
      new Style({
        renderer(coordinates: any, state) {
          const [[x, y], [x1, y1]] = coordinates;
          const ctx = state.context;
          const dx = x1 - x;
          const dy = y1 - y;
          const radius = Math.sqrt(dx * dx + dy * dy);
    
          const innerRadius = 0;
          const outerRadius = radius * 1.4;
    
          const gradient = ctx.createRadialGradient(
            x,
            y,
            innerRadius,
            x,
            y,
            outerRadius
          );
          gradient.addColorStop(0, 'rgba(255,0,0,0)');
          gradient.addColorStop(0.6, 'rgba(255,0,0,0.2)');
          gradient.addColorStop(1, 'rgba(255,0,0,0.8)');
          ctx.beginPath();
          ctx.arc(x, y, radius, 0, 2 * Math.PI, true);
          ctx.fillStyle = gradient;
          ctx.fill();
    
          ctx.arc(x, y, radius, 0, 2 * Math.PI, true);
          ctx.strokeStyle = 'rgba(255,0,0,1)';
          ctx.stroke();
        },
      })
    );

    this.map = new Map({
      controls: defaultControls().extend([this.mousePositionControl]),
      target: 'local_map',
      layers: [
        new TileLayer({
          source: new OSM()
        }),
        new VectorLayer({
          source: new VectorSource({
            features: [this.circleFeature]
          })
        })
      ],
      view: new View({
        center: olProj.fromLonLat([-100, 40]),
        zoom: 4
      })
    });

    this.map.on('click', (e) => {
      let coord = olProj.transform(e.coordinate, "EPSG:3857", "EPSG:4326");

      let newGeometry = new Circle(e.coordinate, 1000);

      this.circleFeature.setGeometry(newGeometry)
      console.log(coord);
    });
  }

}

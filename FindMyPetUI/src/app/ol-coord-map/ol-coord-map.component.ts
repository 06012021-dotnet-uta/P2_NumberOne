import {Component, Output, OnInit, Input, EventEmitter } from '@angular/core';
import Map from 'ol/Map';
import View from 'ol/View';
import OSM from 'ol/source/OSM';
import * as olProj from 'ol/proj';
import TileLayer from 'ol/layer/Tile';
import {defaults as defaultControls, MousePosition} from 'ol/control';
import { createStringXY } from 'ol/coordinate';
import Feature from 'ol/Feature';
import Circle from 'ol/geom/Circle';
import Point from 'ol/geom/Point';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import Style from 'ol/style/Style';

@Component({
  selector: 'app-ol-coord-map',
  templateUrl: './ol-coord-map.component.html',
  styleUrls: ['./ol-coord-map.component.css']
})

export class OlCoordMapComponent implements OnInit {

  constructor() { }

  @Input() interactableCircle: boolean = false;     //Allows user input to set a circle with {{circleRadius}} as radius
  @Input() interactablePoint: boolean = false;      //Allows user input to set a point on mouseclick
  @Input() showPoints: boolean = false;             //Show points flag
  @Input() showCircle: boolean = false;             //Show circle flag
  @Input() points: number[][] = [];                 //2d array of lat and long coordinates - I may have lat and long order backwards but whatever peeps are gonna have to deal
  @Input() circleCenter: number[] = [];             //Circle center
  @Input() circleRadius: number = 1000;             //Circle radius
  @Input() viewZoom: number = 4;                    //Sets the initial zoom
  @Input() viewCenter: number[] = [-100, 40];       //Sets the initial view of the map

  @Output() selectedCoordsEmitter = new EventEmitter<number[]>(); //Emits coordinates of mouse on map on mouseClick - Must have one of the interactable flags set to true

  map: Map | null = null;


  //This is gross don't look at it
  ngOnInit(){

    let coord = olProj.transform(this.circleCenter, "EPSG:4326", "EPSG:3857"); //This is stupid and I feel stupid
    
    let mousePositionControl = new MousePosition({
      coordinateFormat: createStringXY(4),
      projection: 'EPSG:4326'
    });

    let circleFeature = new Feature({
      geometry: new Circle(coord, this.circleRadius)
    });

    circleFeature.setStyle(
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

    let pointFeature = new Feature({
    });

    

    let controls = defaultControls();

    if(this.interactableCircle || this.interactablePoint) controls = controls.extend([mousePositionControl]);

    let features = [];

    if(this.showCircle)
      features.push(circleFeature);
    if(this.showPoints)
    {
      features.push(pointFeature);
      for(let i = 0; i < this.points.length; i++)
      {
        if(this.points[i][0] !== 0 && this.points[i][1] !== 0){
          features.push(new Feature({
            geometry: new Point(olProj.transform(this.points[i], "EPSG:4326", "EPSG:3857"))
          }));
        }
      }
    }
    
    this.map = new Map({
      controls: controls,
      target: 'local_map',
      layers: [
        new TileLayer({
          source: new OSM()
        }),
        new VectorLayer({
          source: new VectorSource({
            features: features
          })
        })
      ],
      view: new View({
        center: olProj.fromLonLat(this.viewCenter), // center on USA
        zoom: this.viewZoom
      })
    });

    if(this.interactableCircle || this.interactablePoint){
      this.map.on('click', (e) => {
        let coord = olProj.transform(e.coordinate, "EPSG:3857", "EPSG:4326");

        let newGeometry: Circle | Point | undefined = undefined;
        
        if(this.interactableCircle){
          newGeometry = new Circle(e.coordinate, this.circleRadius);
          circleFeature.setGeometry(newGeometry);
        }
        if(this.interactablePoint){
          newGeometry = new Point(e.coordinate);
          pointFeature.setGeometry(newGeometry);
        }

        this.selectedCoordsEmitter.emit(coord);
      });
    }
  }
  //I'm so ashamed

}

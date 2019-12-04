import { Component, OnInit,NgZone } from '@angular/core';
import { SignalRService } from '../signal-r.service';

@Component({
  selector: 'app-circles',
  templateUrl: './circles.component.html',
  styleUrls: ['./circles.component.css']
})
export class CirclesComponent implements OnInit {
  
  private _colors:any[] =[];
  constructor(private _signalRService: SignalRService, private _ngZone: NgZone) { }

  ngOnInit() {


      this._signalRService.connectionEstablished.subscribe(() => {  
        //Do something when connection is established        
      });  

      this._signalRService.messageReceived.subscribe((message: any) => {  
      
        this._ngZone.run(() => {  
            this._colors.push(message);            
        });  
    }); 
  }

}

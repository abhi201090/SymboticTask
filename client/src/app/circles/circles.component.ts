import { Component, OnInit,NgZone } from '@angular/core';
import { ColorService} from '../color.service';

@Component({
  selector: 'app-circles',
  templateUrl: './circles.component.html',
  styleUrls: ['./circles.component.css']
})
export class CirclesComponent implements OnInit {
  
  private _colors:any[] =[];
  constructor(private _colorService: ColorService) { }

  ngOnInit() {
      this._colorService.getServerSentEvent("http://localhost:57034/api/SSE/Color").subscribe(message => {
          this._colors.push(JSON.parse(message.data));
        }
      );
  }

}

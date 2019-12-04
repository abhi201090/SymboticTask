import { Injectable, EventEmitter } from '@angular/core';

declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  private _proxy: any; 
  private _proxyName: string = 'connectionHub';
  private _connection: any;  
  public _messageReceived: EventEmitter<any>  ;  
  
  constructor() {   
        this._messageReceived = new EventEmitter<any>();  
        // create hub connection  
        this._connection = $.hubConnection("http://localhost:57034/connectionHub");  
        // create new proxy as name 
        this._proxy = this._connection.createHubProxy(this._proxyName);  
        // register on server events  
        this.registerOnServerEvents();  
        // call the connecion start method to start the connection to send and receive events.  
        this.startConnection({ transport: 'webSockets' });  

  }

  private startConnection(transport): void {  
    this._connection.start(transport).done((data: any) => {  
        //Do something on success
    }).fail((error: any) => {  
        //Do something on 
    }); 
  } 

  private registerOnServerEvents(): void {      
    this._proxy.on('message', (data: any) => {          
        this._messageReceived.emit(data);  
    });  
  }  
}

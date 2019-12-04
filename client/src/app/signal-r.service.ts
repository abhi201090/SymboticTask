import { Injectable, EventEmitter } from '@angular/core';

declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  private proxy: any; 
  private proxyName: string = 'connectionHub';
  private connection: any;  
  public messageReceived: EventEmitter<any>  ;  
  public connectionEstablished: EventEmitter<Boolean>;
  public connectionExists: Boolean;  

  constructor() { 
    this.connectionEstablished = new EventEmitter();  
        this.messageReceived = new EventEmitter<any>();  
        this.connectionExists = false;  
        // create hub connection  
        this.connection = $.hubConnection("http://localhost:57034/connectionHub");  
        // create new proxy as name 
        this.proxy = this.connection.createHubProxy(this.proxyName);  
        // register on server events  
        this.registerOnServerEvents();  
        // call the connecion start method to start the connection to send and receive events.  
        this.startConnection({ transport: 'webSockets' });  

  }

  private startConnection(transport): void {  
    this.connection.start(transport).done((data: any) => {  
        //Do something on success
    }).fail((error: any) => {  
        //Do something on failure
    }); 
  } 

  private registerOnServerEvents(): void {      
    this.proxy.on('message', (data: any) => {          
        this.messageReceived.emit(data);  
    });  
  }  
}
